using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject Skeleton;
    public float spawnInterval;
    public void enemyRandomSpawner()
    {
        float x = Random.Range(-11f, 26f);
        float y = Random.Range(-13f, 12f);
        Vector3 vector3 = new Vector3(x, y, 0);
        Instantiate(Zombie, vector3,Quaternion.identity);
        Instantiate(Skeleton, vector3, Quaternion.identity);
    }
    void Start()
    {
        InvokeRepeating("enemyRandomSpawner", 0f, spawnInterval);
    }
    void Update()
    {

    }
}
