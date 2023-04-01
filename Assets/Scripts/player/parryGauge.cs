using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parryGauge : MonoBehaviour
{
    public GameObject[] parryGaugeArr;
    public int parryCount;
    public int gaugeCount;
    public float increaseAtkSpd;
    public Button button;
    public Camera cam;
    public bool Is_SuccessParry;

    void Start()
    {
        DeactiveAllGauge();
        gaugeCount = parryGaugeArr.Length;
        SetActiveButton(parryCount);
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void DeactiveGauge()
    {
        if (parryCount > 0)
        {
            Debug.Log(gaugeCount);
            parryCount--;
            parryGaugeArr[parryCount].SetActive(false);
            SetActiveButton(parryCount);
        }
        else
        {
            //Debug.Log(parryCount);
        }
    }
    public void ActiveGauge()
    {
        if (parryCount < 3)
        {
            parryGaugeArr[parryCount].SetActive(true);
            parryCount++;
            SetActiveButton(parryCount);
        }
        else
        {
            //Debug.Log(parryCount);

        }
    }
    public void DeactiveAllGauge()
    {
        foreach (GameObject go in parryGaugeArr)
        {
            go.SetActive(false);
        }
    }
    void SetActiveButton(int parryCount)
    {
        if (parryCount == gaugeCount)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void OnSuccesParry()
    {
        StartCoroutine(DelayRestoreCamSize());

    }
    IEnumerator DelayRestoreCamSize()
    {
        cam.orthographicSize = 5f;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(.7f);
        Time.timeScale = 1f;
        cam.orthographicSize = 6.5f;
    }
}
