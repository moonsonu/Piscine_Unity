using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;
    public PlayerController target;
    public enum EnemyState { Free, Attack, Dead };
    public EnemyState es;
    public float lookRadius = 10f;
    public float distance;
    public Stat enemyStats;
    public bool isAttack;
    public bool isShrink;
    public float shrinkSpeed = 0.1f;
    public Text enemyHPtext;
    public Image enemyHPBar;
    public float maxHP;
    public EnemySpawn spawn;

    //public Transform target;
    //public bool isAttack;
    //public bool isDead = false;
    //public int baseDamage;
    //public int finalDamage;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        enemyStats.InitStat();
        isShrink = false;
        maxHP = 40;
        enemyStats.setHp = 40;
    }

    private void Update()
    {
        enemyHPBar.fillAmount = enemyStats.getHp / maxHP;
        enemyHPtext.text = enemyStats.getHp.ToString() + "/" + maxHP;
        distance = Vector3.Distance(target.gameObject.transform.position, transform.position);
        switch (es)
        {
            case EnemyState.Free:
                Move();
                break;
            case EnemyState.Attack:
                Debug.Log("Attack");
                Attack();
                break;
            case EnemyState.Dead:
                Dead();
                break;
        }

        if (isShrink)
        {
            transform.Translate(-Vector3.up * shrinkSpeed * Time.deltaTime);
            if (transform.position.y < -2)
                Destroy(gameObject);
        }
    }

    void Move()
    {
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.transform.position);
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("SpeedPercent", speedPercent);
            if (distance <= agent.stoppingDistance)
            {
                es = EnemyState.Attack;
            }
        }

        else
        {
            animator.SetFloat("SpeedPercent", 0);
        }
    }

    void Attack()
    {
        int baseDamage = enemyStats.getBaseDamage();
        int finalDamage = enemyStats.getFinalDamage(baseDamage, target.playerStat.getAGI);
        if (distance <= agent.stoppingDistance)
        {
            isAttack = true;
            //FaceTarget();
            animator.SetFloat("SpeedPercent", 0);
            //if (isAttack)
                //StartCoroutine(Attacking());
            //target.Damaged(finalDamage);
            if (target.ps == PlayerController.PlayerState.Dead)
                animator.SetBool("isAttack", false);
        }
        else
        {
            es = EnemyState.Free;
            animator.SetBool("isAttack", false);
        }
    }

    IEnumerator Attacking()
    {
        float chance = Random.value;

        if (chance > enemyStats.getHitChance(target.playerStat.getAGI) && isAttack)
        {
            animator.SetBool("isAttack", true);
            yield return new WaitForSeconds(5f);
            if (target.ps != PlayerController.PlayerState.Dead)
            {
                Debug.Log("attacking player");
                isAttack = false;
                yield return new WaitForSeconds(5f);
                animator.SetBool("isAttack", false);
            }
            else
                animator.SetBool("isAttack", false);
        }
    }

    void Dead()
    {
        animator.SetTrigger("isDead");
        isShrink = true;
        spawn.isSpawn = true;
    }

    public void Damaged(int damage)
    {
        if (enemyStats.getHp > 0)
        {
            enemyStats.setHp = enemyStats.getHp - damage;
            Debug.Log("enemy hp : " + enemyStats.getHp);

            if (enemyStats.getHp <= 0)
            {
                es = EnemyState.Dead;
                target.playerStat.setXp = 160 + target.playerStat.getXp;
            }
        }
    }
}










    //void Update()
    //{
    //    float distance = Vector3.Distance(target.position, transform.position);

    //    if (distance <= lookRadius)
    //    {
    //        agent.SetDestination(target.position);
    //        float speedPercent = agent.velocity.magnitude / agent.speed;
    //        animator.SetFloat("SpeedPercent", speedPercent);

    //        if (distance <= agent.stoppingDistance)
    //        {
    //            FaceTarget();
    //            animator.SetBool("isAttack", true);
    //            StartCoroutine(Attack());
    //        }
    //        else
    //            animator.SetBool("isAttack", false);
    //    }
    //    else
    //        animator.SetFloat("SpeedPercent", 0);
    //}

    //IEnumerator Attack()
    //{
    //    float chance = Random.value;
    //    finalDamage = baseDamage * (1 - (targetStat.myStats.getAGI / 200));
    //    if (chance > myStats.getHitChance(targetStat.myStats.getAGI))
    //    {
    //        if (myStats.getHp > 0)
    //            targetStat.myStats.getDamaged(finalDamage);
    //        else if (myStats.getHp <= 0)
    //        {
    //            //Debug.Log("game over, restart the game");
    //        }
    //    }
    //    yield return new WaitForSeconds(1f);
    //}

    //void FaceTarget()
    //{
    //    Vector3 direction = (target.position - transform.position).normalized;
    //    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    //}
    //public void Dead()
    //{
    //    animator.SetTrigger("isDead");
    //    //yield return new WaitForSeconds(2f);

    //    StartCoroutine(Shrink());

    //}

    //IEnumerator Shrink()
    //{
    //    yield return new WaitForSeconds(2f);
    //    transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime;
    //    if (transform.localScale.y < 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
//}

//public float lookRadius = 10f;
//public Transform target;
//public NavMeshAgent agent;
//Movement movement;
//private Animator animator;
//public bool isInRadius;
//public Transform spawnPosition;
//public GameObject[] enemyList;

//public int hp;
//public int damage;
//public bool isDead;

//void Start()
//{
//    hp = 30;
//    damage = 5;
//    isInRadius = false;
//    agent.GetComponent<NavMeshAgent>();
//    movement = GetComponent<Movement>();
//    animator = GetComponent<Animator>();
//}

//void Update()
//{
//    float distance = Vector3.Distance(target.position, transform.position);

//    if (distance <= lookRadius)
//    {
//        movement.MoveToPoint(target.position);
//        //agent.SetDestination(target.position);
//        if (distance <= agent.stoppingDistance)
//        {
//            isInRadius = true;
//            FaceTarget();
//            //Attack();
//        }
//        else
//            isInRadius = false;
//    }
//}

//void SpawnEnemy()
//{
//    GameObject tmp = Instantiate(gameObject, spawnPosition.position, Quaternion.identity) as GameObject;
//}

//void FaceTarget()
//{
//    Vector3 direction = (target.position - transform.position).normalized;
//    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
//}

//public void GetDamage(GameObject currentEnemy)
//{
//    if (hp > 0)
//    {
//        hp -= damage;
//        if (hp <= 0)
//            Dead(currentEnemy);
//    }
//    Debug.Log("ENEMY got damaged! HP left : " + hp);
//}

//void Dead(GameObject currentEnemy)
//{
//    Destroy(currentEnemy);
//    SpawnEnemy();
//}

//private void OnDrawGizmos()
//{
//    Gizmos.color = Color.red;
//    Gizmos.DrawWireSphere(transform.position, lookRadius);
//}