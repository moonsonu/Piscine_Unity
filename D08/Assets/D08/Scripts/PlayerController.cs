using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
   
    //public Stat myStats;

    public UIController ui;
    public GameObject enemyUI;
    //public float range;
    //public bool isAttack;
    //public bool isDead;
    //public int maxHp = 100;
    //public int baseDamage;
    //public int finalDamage;

    Camera cam;
    Movement movement;
    public EnemyController target;
    public GameObject currentEnemy;
    public Stat playerStat;
    public enum PlayerState { Free, Attack, Dead };
    public PlayerState ps;
    public float attackRange = 2.0f;
    public bool isAttack;
    public bool isDead;
    public float maxXP;
    public float maxHP;

    private void Start()
    {
        cam = Camera.main;
        movement = GetComponent<Movement>();
        isAttack = false;
        isDead = false;
        playerStat.InitStat();
        maxXP = 400;
        maxHP = playerStat.getHp;
        //baseDamage = myStats.getMinDamage;
        //isAttack = false;
    }

    private void Update()
    {
        if (currentEnemy)
            enemyUI.SetActive(true);
        else if (!currentEnemy)
            enemyUI.SetActive(false);
        if (playerStat.getXp > maxXP)
        {
            playerStat.setLevel = playerStat.getLevel + 1;
            //reload Scene;
        }

        switch (ps)
        {
            case PlayerState.Free:
                Move();
                break;
            case PlayerState.Attack:
                Attack();
                break;
            case PlayerState.Dead:
                StartCoroutine(Dead());
                break;
        }
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    currentEnemy = hit.transform.gameObject;
                    ps = PlayerState.Attack;
                }
                else
                {
                    movement.MoveToPoint(hit.point);
                    currentEnemy = null;
                }
            }
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(transform.position, currentEnemy.transform.position);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy" && currentEnemy)
                {
                    if (distance < attackRange)
                    {
                        isAttack = true;
                        StartCoroutine(Attacking());
                    }
                    else
                    {
                        isAttack = false;
                        movement.MoveToPoint(hit.point);
                    }
                }
                else
                {
                    currentEnemy = null;
                    isAttack = false;
                    movement.MoveToPoint(hit.point);
                    ps = PlayerState.Free;
                }
            }
        }
    }

    IEnumerator Attacking()
    {
        float chance = Random.value;
        target = currentEnemy.GetComponent<EnemyController>();
        int baseDamage = playerStat.getBaseDamage();
        int finalDamage = playerStat.getFinalDamage(baseDamage, target.enemyStats.getAGI);

        if (chance > playerStat.getHitChance(target.enemyStats.getAGI))
        {
            if (target.es != EnemyController.EnemyState.Dead)
            {
                target.Damaged(finalDamage);
            }
        }
        yield return new WaitForSeconds(1f);
        isAttack = false;
    }

    IEnumerator Dead()
    {
        isDead = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Player Dead");

    }

    public void Damaged(int damage)
    {
        if (playerStat.getHp > 0)
        {
            playerStat.setHp = playerStat.getHp - damage;
            Debug.Log("Player hp : " + playerStat.getHp);

            if (playerStat.getHp <= 0)
                ps = PlayerState.Dead;
        }
    }
}
    














    //private void Update()
    //{
    //    ui.SetHPbar();
    //    ui.SetXPbar();
    //    if (myStats.getHp > maxHp)
    //    {
    //        //level up
    //    }

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.collider.tag == "Enemy")
    //            {
    //                Debug.Log("enemy clicked");
    //                currentEnemy = hit.transform.gameObject;
    //                range = Vector3.Distance(transform.position, currentEnemy.transform.position);
    //                if (range < 2)
    //                {
    //                    isAttack = true;
    //                    Attack();
    //                }
    //                //StartCoroutine(Attack());
    //            }
    //            else
    //            {
    //                isAttack = false;
    //                movement.MoveToPoint(hit.point);
    //                currentEnemy = null;
    //            }
    //        }
    //    }

    //    if (isDead)
    //    {
    //        //StartCoroutine(GameOver());
    //    }
    //}

    //void Attack()
    //{
    //    float chance = Random.value;
    //    target = currentEnemy.GetComponent<EnemyController>();
    //    finalDamage = baseDamage * (1 - (target.myStats.getAGI / 200));
    //    if (chance > myStats.getHitChance(target.myStats.getAGI))
    //    {
    //        if (myStats.getHp > 0)
    //            target.myStats.getDamaged(finalDamage);
    //        else if (myStats.getHp <= 0)
    //        {
    //            target.Dead();
    //            myStats.setXp = 160 + myStats.getXp;
    //        }
    //    }
    //    //yield return new WaitForSeconds(1f);
    //}

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