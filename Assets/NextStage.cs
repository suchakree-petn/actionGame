using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextStage : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextStage();
        }
    }
    void LoadNextStage()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
