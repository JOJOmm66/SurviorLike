using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int moveSpeed;
    public Transform playerTransform;

    public EnemyTakeDamage enemyTakeDamage;
    private SpriteRenderer spriteRenderer;

    //产生碰撞后调用player身上的受伤方法
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (collision.gameObject != null&&enemyTakeDamage.currentHealth>0)
            {
                playerController.takeDamage(5);
                //Debug.Log(playerController.currentHealth);
            }
        }
    }
    void Start()
    {
        playerTransform= PlayerController.instance.transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyTakeDamage = GetComponent<EnemyTakeDamage>();
    }

    void Update()
    {
        Vector3 movePosition = (playerTransform.position-this.transform.position).normalized;
        if (playerTransform.position.x < this.transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        this.transform.Translate(movePosition * moveSpeed * Time.deltaTime);
    }
}
