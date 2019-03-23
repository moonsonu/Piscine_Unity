using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject currentEnemy;
    public bool isSpawn = false;

    void Start()
    {
        currentEnemy = Instantiate(enemy[Random.Range(0, 2)], transform.position, Quaternion.identity);
        currentEnemy.transform.parent = transform;
    }

    void Update()
    {
        if (currentEnemy == null && !isSpawn)
        {
            Debug.Log("1");
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        isSpawn = true;
        yield return new WaitForSeconds(15);
        Debug.Log("Spawing new enemy at " + transform.position);
        currentEnemy = Instantiate(enemy[Random.Range(0, 2)], transform.position, Quaternion.identity);
        isSpawn = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * 15);
    }

    //private PlayerController playerController;
    //public GameObject[] enemies;
    //private GameObject enemy;
    //private EnemyController enemyController;
    //private bool noRepeat;

    //private void Start()
    //{
    //    int type = Random.Range(0, 2);
    //    enemy = (GameObject)Instantiate(enemies[type], transform);
    //    enemyController = enemy.GetComponent<EnemyController>();
    //    playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    //}

    //private void Update()
    //{
    //    if (!noRepeat && enemyController.enemyState == EnemyController.State.DYING && playerController.curHealth > 0)
    //        StartCoroutine(SpawnNewEnemy());
    //}

    //private IEnumerator SpawnNewEnemy()
    //{
    //    noRepeat = true;
    //    yield return new WaitForSeconds(15.0f);
    //    int type = Random.Range(0, 2);
    //    enemy = (GameObject)Instantiate(enemies[type], transform);
    //    enemyController = enemy.GetComponent<EnemyController>();
    //    noRepeat = false;
    //}
}
