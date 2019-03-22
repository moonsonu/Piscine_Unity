using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    Movement movement;
    public Stat myStats;
    public EnemyController target;
    public GameObject currentEnemy;
    public float range;
    public bool isAttack;
    public bool isDead;
    public int maxHp;
    public int baseDamage;
    public int finalDamage;

    private void Start()
    {
        isAttack = false;
        cam = Camera.main;
        movement = GetComponent<Movement>();
        myStats.InitStat();
        baseDamage = myStats.getMinDamage;
    }

    private void Update()
    {
        if (myStats.getHp > maxHp)
        {
            //level up
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("enemy clicked");
                    currentEnemy = hit.transform.gameObject;
                    //range = Vector3.Distance(transform.position, currentEnemy.transform.position);
                    isAttack = true;
                    StartCoroutine(Attack());
                }
                else
                {
                    isAttack = false;
                    movement.MoveToPoint(hit.point);
                    currentEnemy = null;
                }
            }
        }

        if (isDead)
        {
            //StartCoroutine(GameOver());
        }
    }

    IEnumerator Attack()
    {
        float chance = Random.value;
        target = currentEnemy.GetComponent<EnemyController>();
        finalDamage = baseDamage * (1 - (target.myStats.getAGI / 200));
        if (chance > myStats.getHitChance(target.myStats.getAGI))
            target.myStats.getDamaged(finalDamage);
        yield return new WaitForSeconds(1f);
    }

    //IEnumerator GameOver()
    //{
    //    yield return new WaitForSeconds(2f);
    //    transform.Translate(Vector3.down * Time.deltaTime * shrinkSpeed);
    //    if (transform.position.y < 0)
    //    {
    //        Debug.Log("Game Over");
    //        //gameover GUI;
    //    }
    //}
}



//Camera cam;
//Movement movement;

//public GameObject enemy;
//public EnemyController ec;

//public int hp;
//public int damage;

//public bool isAttack;
//public bool isDead;

//void Start()
//{
//    hp = 30;
//    damage = 5;
//    cam = Camera.main;
//    movement = GetComponent<Movement>();
//}

//void Update()
//{
//    Vector3 offset = enemy.transform.position - transform.position;
//    if (Input.GetMouseButtonDown(0))
//    {
//        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//        if (Physics.Raycast(ray, out hit))
//        {
//            movement.MoveToPoint(hit.point);
//        }
//    }
//    if (Input.GetMouseButtonDown(1))
//    {
//        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//        if (Physics.Raycast(ray, out hit, 100))
//        {
//            Debug.Log(hit.collider.tag);
//            if (hit.collider.tag == "Enemy")
//            {
//                isAttack = true;
//                StartCoroutine(Attack(hit.collider.gameObject));
//            }
//        }
//    }
//}

//IEnumerator Attack(GameObject enemy)
//{
//    ec.GetDamage(enemy);
//    yield return new WaitForSeconds(2f);
//    isAttack = false;
//}

//public void GetDamage(int damage)
//{
//    if (hp > 0)
//    {
//        hp -= damage;
//        if (hp <= 0)
//            isDead = true;
//    }
//}

//{
//    yield return new WaitForSeconds(2.0f);
//    navMeshAgent.enabled = false;
//    enemyState = State.SINKING;
//    yield return new WaitForSeconds(3.0f);
//    GameObject potionPre = null;
//    if (Random.value <= 0.5f)
//    {
//        potionPre = Instantiate(potion);
//        potionPre.transform.position = new Vector3(transform.position.x, transform.position.y + 7.0f, transform.position.z);
//    }
//    yield return new WaitForSeconds(2.0f);
//    Destroy(gameObject);
//}