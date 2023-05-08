using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    PlayerInputActions playerInputActions;
    Camera cam;
    public delegate void StartTouch(Vector2 position, float time);
    public delegate void EndTouch(Vector2 position, float time);
    public StartTouch onStartTouch;
    public EndTouch onEndTouch;

    void MyStartTouch(Vector2 positon, float t)
    {
        Debug.Log("MyStartTouch: " + positon.ToString() + "," + t);
    }
    void MyEndTouch(Vector2 positon, float t)
    {
        Debug.Log("MyEndTouch: " + positon.ToString() + "," + t);
    }

    void Awake()
    {
        playerInputActions = new PlayerInputActions();

    }
    void OnEnable()
    {
        playerInputActions.Enable();
    }
    void OnDisable()
    {
        playerInputActions.Disable();
    }
    void Start()
    {
        playerInputActions.Player.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerInputActions.Player.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        cam = Camera.main;

    }
    public Vector3 PrimaryPosition()
    {
        Vector2 input2 = playerInputActions.Player.PrimaryPosition.ReadValue<Vector2>();
        Vector3 input3 = ScreenWorld(cam, input2);
        return input3;
    }
    void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        Vector3 touchPos = playerInputActions.Player.PrimaryPosition.ReadValue<Vector2>();
        Vector3 pos = ScreenWorld(cam, touchPos);
        //Debug.Log("Start Touch: " + pos);
    }
    void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        Vector3 touchPos = playerInputActions.Player.PrimaryPosition.ReadValue<Vector2>();
    }
    Vector3 ScreenWorld(Camera cam, Vector3 pos)
    {
        pos.z = cam.nearClipPlane;
        return cam.ScreenToWorldPoint(pos);
    }

}
