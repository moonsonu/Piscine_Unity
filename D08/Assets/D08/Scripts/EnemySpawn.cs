using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemy;
    private GameObject currentEnemy;
    private bool isSpawn = false;

    void Start()
    {
        currentEnemy = Instantiate(enemy[Random.Range(0, 2)], transform.position, Quaternion.identity);
        currentEnemy.transform.parent = transform;
    }

    void Update()
    {
        if (currentEnemy == null && !isSpawn)
        {
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
}
