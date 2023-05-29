using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class applySelection : MonoBehaviour
{
    public GameControllerSpecialStage gameControllerSpecialStage;

    public void Apply()
    {
        if (gameControllerSpecialStage.selectedPlatform != null)
        {
            foreach (int i in gameControllerSpecialStage.selected)
            {
                if (gameControllerSpecialStage.selectedPlatform.name == i.ToString())
                {
                    Debug.Log("Not empty");
                    return;
                }
            }
            if (gameControllerSpecialStage.Is_firstTurn == true)
            {
                gameControllerSpecialStage.Is_firstTurn = false;
            }
            
            gameControllerSpecialStage.stage_Stage.fight_time_temp = gameControllerSpecialStage.stage_Stage.fight_time;

            gameControllerSpecialStage.stage_Stage.state = 1;
            Time.timeScale = 1;

            gameControllerSpecialStage.PlayerTurn(int.Parse(gameControllerSpecialStage.selectedPlatform.name));
            gameControllerSpecialStage.selected.Add(int.Parse(gameControllerSpecialStage.selectedPlatform.name));
        }
    }
}
