using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minDistance = .2f;
    [SerializeField]
    private float maxTime = 1f;

    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    public RobotControllerScript robotControllerScript;
    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.onStartTouch += SwipeStart;
        inputManager.onEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.onStartTouch -= SwipeStart;
        inputManager.onEndTouch -= SwipeEnd;

    }
    public GameObject trail;
    private Coroutine coroutine;
    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        //trail.transform.position = position;
        //trail.SetActive(true);
        //coroutine = StartCoroutine(Trail());
    }
    private IEnumerator Trail()
    {
        while (true)
        {
            trail.transform.position = inputManager.PrimaryPosition();
            yield return null;
        }
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        //trail.SetActive(false);
        StopCoroutine(Trail());
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minDistance &&
            (endTime - startTime) <= maxTime)
        {
            //Debug.Log("Swipe Detected");
            Debug.DrawLine(startPosition, endPosition, Color.cyan, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 dir = direction.normalized;
            //SwipeDirection(dir);
        }
    }

    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = 0.9f;
    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            robotControllerScript.SwipeToJump(true);
            StartCoroutine(waitToStopJump(0.1f));

        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            robotControllerScript.SwipeToWalk(-1);
            StartCoroutine(waitToStopWalk(0.5f));
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            robotControllerScript.SwipeToWalk(1);
            StartCoroutine(waitToStopWalk(0.5f));
        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            robotControllerScript.SwipeToJump(false);
        }
    }
    IEnumerator waitToStopWalk(float sec){
        yield return new WaitForSeconds(sec);
        robotControllerScript.SwipeToWalk(0);
    }
    IEnumerator waitToStopJump(float sec){
        yield return new WaitForSeconds(sec);
        robotControllerScript.SwipeToJump(false);
    }
}
