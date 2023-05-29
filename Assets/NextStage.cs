using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextStage : MonoBehaviour
{
    public GameObject loadTrans;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LoadNextStage();
        }
    }
    void LoadNextStage()
    {
        // int i = SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene(i++, LoadSceneMode.Single);
        GameObject load = Instantiate(loadTrans, GameObject.Find("Canvas").transform);
        Destroy(load, 5f);
        Invoke(nameof(InitialNextScene), 3.5f);
    }
    void InitialNextScene()
    {
        GameController gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
        gameController.floor++;
        if (gameController.floor == 10)
        {
            gameController.enemy.GetComponent<Enemy>().hp += 1200f;
            gameController.Skeleton.GetComponent<EnemyState>().hp += 1200f;
            gameController.Objective_amount = 1;
            gameController.enemyAmount = 1;
            gameController.enemyAmount_temp = 1;
            gameController.skeletonAmount = 0;
            gameController.skeletonAmount_temp = 0;
            gameController.Objective_txt.text = "Defeat the Boss";
            gameController.Objective_txt.color = Color.red;
        }
        else
        {
            gameController.enemy.GetComponent<Enemy>().hp += 50f;
            gameController.Skeleton.GetComponent<EnemyState>().hp += 50f;
            gameController.Objective_amount = 12;
            gameController.Objective_txt.text = gameController.Objective_amount.ToString() + " Enemy eliminate to next floor.";
        }

        gameController.stageLevel_txt.text = "Stage: 1\nFloor: " + gameController.floor;
        gameController.NextStagePortal.SetActive(false);
        gameController.gate.SetActive(true);
        gameController.player.transform.position = Vector3.zero;

    }

}
