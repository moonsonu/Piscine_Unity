using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //public int HP = 100;
    public float lookRadius = 1000f;
    //public bool isDead;
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private Animator anim;
    //public Tank tank;
    //public int damage = 5;
    //public GameObject shootPoint;
    //public ParticleSystem gunPart;
    //public ParticleSystem damagePart;
    //public bool isReadytoShoot;
    //public AudioClip aGun;
    //public AudioClip aDead;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        //isDead = false;
        //isReadytoShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        agent.SetDestination(target.position);
        anim.SetBool("isWalk", true);

        if (distance <= lookRadius)
        {

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
            //Attack();
        }

        //if (isDead)
            //StartCoroutine(Die());
    }

    //IEnumerator Die()
    //{

    //    yield return new WaitForSeconds(0.5f);
    //    SoundManager.instance.PlaySingle(aDead);
    //    Destroy(gameObject);
    //}

    //void Attack()
    //{
    //    Debug.Log("Attackkkkk");
    //    RaycastHit hit;
    //    if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.forward, out hit))
    //    {
    //        Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.forward * hit.distance, Color.black);
    //        Debug.Log(hit.transform.name);
    //        if (hit.transform.tag == "Player")
    //        {
    //            if (isReadytoShoot)
    //                StartCoroutine(Shoot());

    //        }
    //    }
    //}

    //IEnumerator Shoot()
    //{
    //    isReadytoShoot = false;
    //    gunPart.Play();
    //    SoundManager.instance.PlaySingle(aGun);
    //    tank.GetDamage(damage);
    //    yield return new WaitForSeconds(7f);
    //    isReadytoShoot = true;
    //}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //public void GetDamage(int damage)
    //{
    //    if (HP > 0)
    //    {
    //        HP -= damage;
    //        Debug.Log("Attacked Enemy! Damaged: " + damage + " HP left : " + HP);
    //        if (HP <= 0)
    //        {
    //            damagePart.Play();
    //            isDead = true;
    //        }
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
