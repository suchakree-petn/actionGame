using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameControllerSpecialStage : MonoBehaviour
{
    public Logic_Minimax logic_Minimax;
    public PlayerInputActions playerInputAction;
    public GameObject selectedPlatform;
    public GameObject selectedUI;
    public GameObject selectedUI_Prefab;
    public List<int> selected;
    public GameObject Skeleton;
    public GameObject Player;
    public SetPosition setPosition;
    public bool Is_firstTurn;
    public stage_stage stage_Stage;

    void Awake()
    {
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        playerInputAction = new PlayerInputActions();
        selectedUI = Instantiate(selectedUI_Prefab);
    }

    void Start()
    {
        Is_firstTurn = true;
        selectedUI.SetActive(false);
        //stage_Stage.DisableSlection();
        //Canvas.SetActive(false);
    }
    void Update()
    {
        if (logic_Minimax.currentPlayer == 'X' && Is_firstTurn)
        {
            int[] StartMove = { Random.Range(0, 3), Random.Range(0, 3) };
            logic_Minimax.move(StartMove[0], StartMove[1]);
            logic_Minimax.board[logic_Minimax.Move[0], logic_Minimax.Move[1]] = logic_Minimax.ai;
            int startSelect = logic_Minimax.ConvertMoveToInt(logic_Minimax.Move);
            EnemyTurn(startSelect);
            logic_Minimax.currentPlayer = logic_Minimax.human;
        }
        else if (logic_Minimax.currentPlayer == 'X' && stage_Stage.state == 2)
        {
            EnemyTurn(logic_Minimax.bestMove());
        }
        // if (Is_Skeleton_Die())
        // {
        // }
    }
    bool Is_Skeleton_Die()
    {
        EnemyState enemyState = Skeleton.GetComponent<EnemyState>();
        if (enemyState.hp <= 0f)
        {
            return true;
        }

        return false;
    }
    public void On_Skeleton_Die()
    {
        stage_Stage.fight_time_temp = 0;
        logic_Minimax.Remove(ConvertIntToMove(int.Parse(Skeleton.transform.parent.gameObject.name)));

    }
    public void PlayerTurn(int move)
    {
        int[] i = ConvertIntToMove(move);
        logic_Minimax.move(i[0], i[1]);
        logic_Minimax.PlayerMove(i[0], i[1]);
        SetPosition setPosition = selectedPlatform.GetComponent<SetPosition>();
        setPosition.SetPos(Player);
        setPosition.SetPos(InstantiateMarkPlatform(Color.blue));
        logic_Minimax.WriteResult();
    }
    public void EnemyTurn(int move)
    {
        foreach (int i in selected)
        {
            if (i == move)
            {
                Debug.Log("Already use: " + i);
                return;
            }
        }
        foreach (Transform child in stage_Stage.platforms.transform)
        {
            if (child.gameObject.name == move.ToString())
            {
                setPosition = child.GetComponent<SetPosition>();
                if (setPosition != null)
                {
                    selected.Add(move);
                    setPosition.SetPos(Skeleton);
                    setPosition.SetPos(InstantiateMarkPlatform(Color.red));
                    EnemyState enemyState = Skeleton.GetComponent<EnemyState>();
                    if (enemyState.animator.GetBool("Dead") == true)
                    {
                        enemyState.animator.SetBool("Dead", false);
                        enemyState.hp = enemyState.Enemy_Hp.GetComponent<Slider>().maxValue;
                        enemyState.SetHp();
                    }
                }
                else
                {
                    Debug.Log("setPosition is null");
                }
            }
        }
    }
    GameObject InstantiateMarkPlatform(Color color)
    {
        GameObject mark = Instantiate(selectedUI_Prefab);
        mark.GetComponent<SpriteRenderer>().color = color;
        return mark;
    }
    int[] ConvertIntToMove(int move)
    {
        int[] i = new int[2];
        switch (move)
        {
            case 1:
                i[0] = 2;
                i[1] = 0;
                return i;
            case 2:
                i[0] = 2;
                i[1] = 1;
                return i;
            case 3:
                i[0] = 2;
                i[1] = 2;
                return i;
            case 4:
                i[0] = 1;
                i[1] = 2;
                return i;
            case 5:
                i[0] = 1;
                i[1] = 1;
                return i;
            case 6:
                i[0] = 1;
                i[1] = 0;
                return i;
            case 7:
                i[0] = 0;
                i[1] = 0;
                return i;
            case 8:
                i[0] = 0;
                i[1] = 1;
                return i;
            case 9:
                i[0] = 0;
                i[1] = 2;
                return i;
        }
        return null;
    }


}
