using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject ResultUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnStageOver()
    {
        Time.timeScale = 0;
        ResultUI.SetActive(true);
        ResultUI.transform.GetChild(1).GetComponent<TMP_Text>().text = "Game Over";
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
}
