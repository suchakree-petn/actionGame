using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AbilityHolderRepeat : MonoBehaviour
{
    public Ability ability;
    [SerializeField] private GameObject SamplePrefab;
    [SerializeField] private GameObject sampleArea;
    private float cd_time;
    private float active_time;
    [SerializeField] private int repeat;
    private float repeat_time;
    [SerializeField] private List<Vector2> targetPos;
    [SerializeField] private List<GameObject> targetSampleList;
    [SerializeField] private Camera cam;
    [SerializeField] private bool Is_selecting = false;
    [SerializeField] private KeyCode key;
    [SerializeField] private player_attack player_Attack;
    [SerializeField] private player_movement player_Movement;
    [SerializeField] private bool Is_performed;
    [SerializeField] private GameObject StickLeft;
    [SerializeField] private GameObject StickRight;
    public Player_Mana player_Mana;
    public Button button;



    public enum AbilityState
    {
        ready,
        active,
        cd
    }
    public AbilityState state = AbilityState.ready;

    void Start()
    {
        cam = Camera.main;
        InitialSample();

    }
    void Update()
    {

        Vector2 mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        if (Is_selecting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //UpdateSamplePos(mousePos);
                GameObject targetSample = Instantiate(SamplePrefab, mousePos, Quaternion.identity);
                targetSample.name = "TS" + (targetSampleList.Count + 1).ToString();
                targetSampleList.Add(targetSample);
                targetPos.Add(mousePos);
                if (targetPos.Count == repeat)
                {
                    Finish_Selecting();
                    foreach (GameObject go in targetSampleList)
                    {
                        Destroy(go);
                    }
                    targetSampleList.Clear();
                    StartCoroutine(waitForInput());
                    state = AbilityState.active;
                    active_time = ability.active_time;
                }
            }

        }



        switch (state)
        {
            case AbilityState.ready:
                repeat = ability.repeat;
                repeat_time = ability.active_time;
                if (Is_performed && player_Mana.mana >= 40f)
                {
                    player_Mana.mana -= 40f;
                    Is_performed = false;
                    Selecting();
                    button.interactable = false;

                }else{
                    Is_performed =false;
                }
                break;
            case AbilityState.active:
                if (active_time > 0)
                {
                    active_time -= Time.deltaTime;
                }
                else
                {
                    //ability.BeginCooldown(gameObject);
                    state = AbilityState.cd;
                    cd_time = ability.cd_time;
                }
                break;
            case AbilityState.cd:
                if (cd_time > 0)
                {
                    cd_time -= Time.deltaTime;
                }
                else
                {
                    targetPos.Clear();
                    state = AbilityState.ready;
                    button.interactable = true;
                }
                break;
        }

        if (Is_selecting)
        {
            sampleArea.transform.position = mousePos;
        }
    }
    public void Is_Performed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Is_performed = true;
        }
        else if (context.canceled)
        {
            Is_performed = false;
        }
    }
    public void Is_Performed()
    {
        Is_performed = true;
    }
    public void Selecting()
    {
        StickLeft.SetActive(false);
        StickRight.SetActive(false);
        player_Attack.Is_charge = true;
        Time.timeScale = 0.3f;
        Is_selecting = true;

    }
    private void Finish_Selecting()
    {
        StickLeft.SetActive(true);
        StickRight.SetActive(true);
        Is_selecting = false;
        player_Attack.Is_charge = false;
        sampleArea.SetActive(false);
    }
    private void InitialSample()
    {
        sampleArea = Instantiate(SamplePrefab);
        sampleArea.SetActive(false);
    }
    private void UpdateSamplePos(Vector2 mousePos)
    {
        sampleArea.SetActive(true);
        sampleArea.transform.position = mousePos;
    }
    private IEnumerator delayRepeat(int repeat, float repeat_time)
    {
        ability.ActivateRepeat(targetPos);
        if (repeat > 1)
        {
            repeat--;
            yield return new WaitForSeconds(repeat_time);
            StartCoroutine(delayRepeat(repeat, repeat_time));
        }
    }
    private IEnumerator waitForInput()
    {
        yield return new WaitUntil(() => targetPos.Count == repeat);
        Time.timeScale = 1f;
        StartCoroutine(delayRepeat(repeat, repeat_time));

    }
}
