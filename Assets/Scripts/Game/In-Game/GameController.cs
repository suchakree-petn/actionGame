using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField] private int fps = 144;
    public int enemyAmount;
    public int skeletonAmount;
    public int enemyAmount_temp;
    public int skeletonAmount_temp;
    private Vector3 Player_Hp_Bar_Pos;
    [SerializeField] private Vector3 Enemy_Hp_Bar_Pos_Offset;
    [SerializeField] private List<Vector2> Enemy_SpawnPoint;
    public Player player;
    [SerializeField] private GameObject EnemyGroup;
    public GameObject enemy;
    public GameObject Skeleton;
    [SerializeField] private GameObject Hp_Bar;
    [SerializeField] private GameObject Player_Hp_Bar;
    public TMP_Text Coin_txt;
    public TMP_Text Objective_txt;
    public TMP_Text stageLevel_txt;
    public int Objective_amount;
    public int Coin;
    public int floor;
    public List<GameObject> EnemyList;
    public GameObject NextStagePortal;
    public GameObject gate;
    public GameObject Buff;
    public GameObject EnemyHP;

    void Awake()
    {
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        enemyAmount_temp = enemyAmount;
        skeletonAmount_temp = skeletonAmount;
    }
    void Start()
    {
        floor = 1;
        Application.targetFrameRate = fps;
        Player_Hp_Bar.GetComponent<Slider>().maxValue = player.hp;
        Player_Hp_Bar.GetComponent<Slider>().value = player.hp;
        NextStagePortal.SetActive(false);
        AddObjectiveAmount(0);
    }
    void Update()
    {
        if (EnemyList.Count < enemyAmount_temp + skeletonAmount_temp && Objective_amount > 0)
        {
            int rand = Random.Range(1, 3);
            if (rand == 1)
            {
                enemyAmount++;
                SpawnEnemy(enemy, ref enemyAmount);
            }
            else if (rand == 2)
            {
                skeletonAmount++;
                SpawnEnemy(Skeleton, ref skeletonAmount);
            }
        }
        else if (Objective_amount == 0)
        {
            if (EnemyList.Count > 0)
            {
                GameObject target = EnemyList.ElementAt(0);
                try
                {
                    EnemyHP.transform.GetChild(0);
                    Destroy(EnemyHP.transform.GetChild(0).gameObject);
                }
                catch
                {

                }
                Destroy(target);
                EnemyList.Remove(target);

                if (EnemyList.Count == 0)
                {
                    if (floor == 10)
                    {
                        SceneManager.LoadScene(0);
                    }
                    Buff.SetActive(true);
                }
            }
            NextStagePortal.SetActive(true);
            gate.SetActive(false);
        }
    }
    void SpawnEnemy(GameObject enemy, ref int enemyAmount)
    {
        if (enemyAmount > 0)
        {
            if (floor == 10)
            {
                float index = Random.Range(0, Enemy_SpawnPoint.Count - 1);
                GameObject boss = InstantiateEnemy(Enemy_SpawnPoint.ElementAt((int)index), enemy);
                boss.transform.localScale = new Vector2(4f, 4f);
                enemyAmount--;
            }
            else
            {
                float index = Random.Range(0, Enemy_SpawnPoint.Count - 1);
                InstantiateEnemy(Enemy_SpawnPoint.ElementAt((int)index), enemy);
                enemyAmount--;
            }

        }
    }
    GameObject InstantiateEnemy(Vector2 Enemy_SpawnPoint, GameObject enemy)
    {

        GameObject Enemy = Instantiate(enemy,
                            Enemy_SpawnPoint,
                            Quaternion.identity,
                            EnemyGroup.transform
                            );
        if (Enemy.name == "enemy(Clone)")
        {
            Enemy.GetComponent<Enemy>().Enemy_Hp = Instantiate_Hp_Bar(Enemy);
            Enemy.GetComponent<Enemy>().Enemy_Hp.SetActive(false);
            EnemyList.Add(Enemy);
            return Enemy;
        }
        else
        {
            Enemy.GetComponentInChildren<EnemyState>().Enemy_Hp = Instantiate_Hp_Bar(Enemy);
            Enemy.GetComponentInChildren<EnemyState>().Enemy_Hp.SetActive(false);
            EnemyList.Add(Enemy);
            return Enemy;
        }
    }
    GameObject Instantiate_Hp_Bar(GameObject Enemy)
    {
        GameObject hp_Bar = Instantiate(Hp_Bar,
                            Enemy.transform.position,
                            Quaternion.identity,
                            GameObject.Find("Canvas/Enemy_Hp_Bar").transform
                            );
        if (Enemy.name == "enemy(Clone)")
        {
            hp_Bar.GetComponent<Slider>().maxValue = Enemy.GetComponent<Enemy>().hp;
            hp_Bar.GetComponent<Slider>().value = Enemy.GetComponent<Enemy>().hp;
            hp_Bar.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f);
            return hp_Bar;
        }
        else
        {
            hp_Bar.GetComponent<Slider>().maxValue = Enemy.GetComponentInChildren<EnemyState>().hp;
            hp_Bar.GetComponent<Slider>().value = Enemy.GetComponentInChildren<EnemyState>().hp;
            hp_Bar.transform.localScale -= new Vector3(0.7f, 0.7f, 0.7f);
            return hp_Bar;
        }
    }

    public void AddCoin(int value)
    {
        Coin += value;
        UpdateCoin();
    }
    public void UpdateCoin(){
        Coin_txt.text = "Coin: " + Coin.ToString();
    }
    public void AddObjectiveAmount(int value)
    {
        if (Objective_amount == 0)
        {
            Objective_txt.text = "Go to next floor.";
            enemyAmount = 0;
            return;
        }
        Objective_amount -= value;
        Objective_txt.text = Objective_amount.ToString() + " Enemy eliminate to next floor.";

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
