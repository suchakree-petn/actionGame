
using UnityEngine;

public class enemy_movement : MonoBehaviour
{

    enemy_attack_1 enemy_Attack_1;
    public Enemy enemy;
    [SerializeField] private float distance = 0f;
    [SerializeField] private float enemy_move_speed = 1f;
    [SerializeField] private Transform target;
    void Start()
    {
        enemy_Attack_1 = GetComponent<enemy_attack_1>();
        target = enemy.player.transform;
    }
    void Update()
    {

    }
    void FixedUpdate()
    {

        enemy.check_atk_range(
                            Vector3.Distance(
                                            transform.position,
                                            enemy.player.transform.position
                                            ),
                            enemy_Attack_1.atk_range
                            );
        float currentDistance = calcDistance();
        //Debug.DrawRay(this_Pos, direction, Color.green);

        if (enemy.animator.GetBool("Is_attack") == false && currentDistance >= enemy_Attack_1.atk_range)
        {

            move_toward_player(transform.position);

        }

    }

    void move_toward_player(Vector3 this_Pos)
    {
        transform.position = Vector2.MoveTowards(this_Pos, target.position, enemy_move_speed * Time.deltaTime);

    }

    public float calcDistance()
    {
        distance = Vector2.Distance(transform.position, target.position);
        return distance;
    }


}
