using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject ResultUI;

    public void OnStageOver()
    {
        Time.timeScale = 0;
        ResultUI.SetActive(true);
        ResultUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "Game Over";
    }
    public void OnStageWin_SpecialStage()
    {
        Time.timeScale = 0;
        ResultUI.SetActive(true);
        ResultUI.transform.GetChild(4).gameObject.SetActive(false);
        ResultUI.transform.GetChild(3).gameObject.SetActive(false);
        ResultUI.transform.GetChild(2).gameObject.SetActive(false);
        ResultUI.transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = "You Win!";

    }
    public void OnStageOver_SpecialStage()
    {
        Time.timeScale = 0;
        ResultUI.SetActive(true);
        ResultUI.transform.GetChild(4).gameObject.SetActive(false);
        ResultUI.transform.GetChild(3).gameObject.SetActive(false);
        ResultUI.transform.GetChild(2).gameObject.SetActive(false);
        ResultUI.transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = "You Lose!";

    }
    public void OnStageTie_SpecialStage()
    {
        Time.timeScale = 0;
        ResultUI.SetActive(true);
        ResultUI.transform.GetChild(4).gameObject.SetActive(false);
        ResultUI.transform.GetChild(3).gameObject.SetActive(false);
        ResultUI.transform.GetChild(2).gameObject.SetActive(false);
        ResultUI.transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = "Tie!";
    }
    public void OnClickRewardedAd()
    {

    }
    public void OnClickExit()
    {
        ResultUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnClickPause()
    {
        ResultUI.SetActive(true);
        Time.timeScale = 0;
        ResultUI.transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = "Pause";
    }
    public void OnClickContinue()
    {
        ResultUI.SetActive(false);
        Time.timeScale = 1;
    }
}

