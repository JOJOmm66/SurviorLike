using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RifleBullet : MonoBehaviour
{
    private int moveSpeed=5;
    private bool isEnemyInRange = false;
    private GameObject enemy;
    //检测怪物碰撞
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            isEnemyInRange = true;
            enemy = collision.gameObject;
        }
    }

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        this.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        //怪物碰到子弹
        if (isEnemyInRange && enemy != null)
        {
            EnemyTakeDamage enemyTakeDamage = enemy.GetComponent<EnemyTakeDamage>();
            enemyTakeDamage.takeDamage(5);
            if (enemyTakeDamage.currentHealth >=0)
            {
                Destroy(gameObject);
            }
            //Debug.Log("怪物受伤一次");
        }
    }
}
