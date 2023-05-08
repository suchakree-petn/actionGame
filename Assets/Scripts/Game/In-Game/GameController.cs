using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    [SerializeField] private int fps = 144;
    [SerializeField] private int enemyAmount;
    [SerializeField] private int skeletonAmount;
    [SerializeField] private int enemyAmount_temp;
    [SerializeField] private int skeletonAmount_temp;
    private Vector3 Player_Hp_Bar_Pos;
    [SerializeField] private Vector3 Enemy_Hp_Bar_Pos_Offset;
    [SerializeField] private Vector2 Enemy_SpawnPoint;
    [SerializeField] private Player player;
    [SerializeField] private GameObject EnemyGroup;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject Skeleton;
    [SerializeField] private GameObject Hp_Bar;
    [SerializeField] private GameObject Player_Hp_Bar;
    public TMP_Text Coin_txt;
    public TMP_Text Objective_txt;
    public int Objective_amount;
    public int Coin;
    public List<GameObject> EnemyList;
    public GameObject NextStagePortal;



    void Awake()
    {
        enemyAmount_temp = enemyAmount;
        skeletonAmount_temp = skeletonAmount;
    }
    void Start()
    {
        Application.targetFrameRate = fps;
        Player_Hp_Bar.GetComponent<Slider>().maxValue = player.hp;
        Player_Hp_Bar.GetComponent<Slider>().value = player.hp;
        NextStagePortal.SetActive(false);
    }
    void Update()
    {
        if (EnemyList.Count < enemyAmount_temp + skeletonAmount_temp && Objective_amount >= 0)
        {
            int rand = Random.Range(1, 3);
            Debug.Log(rand + "   Random");
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
            NextStagePortal.SetActive(true);
        }
    }
    void SpawnEnemy(GameObject enemy, ref int enemyAmount)
    {
        if (enemyAmount > 0)
        {
            float angle = Random.Range(0, 360);
            float radias = 8f;
            float x = Mathf.Cos(angle) * radias;
            float y = Mathf.Sin(angle) * radias;
            Enemy_SpawnPoint = new Vector2(x + player.transform.position.x, y + player.transform.position.y);
            InstantiateEnemy(Enemy_SpawnPoint, enemy);
            enemyAmount--;
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
                            Enemy_SpawnPoint,
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
        Objective_txt.text = Objective_amount.ToString() + "Enemy eliminate to next floor.";

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
