using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public GameControllerSpecialStage gameController;
    float UI_offset = -1f;
    public GameObject UI_Instance;
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerSpecialStage>();
    }
    void Update()
    {
        if (gameController.selectedPlatform == gameObject)
        {
            gameController.selectedUI.SetActive(true);
            gameController.selectedUI.transform.position = new Vector3(transform.position.x + UI_offset, transform.position.y, transform.position.z);
            gameController.selectedUI.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
        if (gameController.stage_Stage.state == 1)
        {
            gameController.selectedUI.SetActive(false);
        }
    }
    public void SetPos(GameObject target)
    {
        this.UI_Instance = target;
        target.transform.position = new Vector3(transform.position.x + UI_offset, transform.position.y, transform.position.z);
        target.transform.parent = gameObject.transform;
    }
    void OnMouseDown()
    {
        gameController.selectedPlatform = gameObject;
    }
}
