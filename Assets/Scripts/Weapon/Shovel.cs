using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private bool isPlayerInRange=false;
    private GameObject player;

    private bool isEnemyInRange=false;
    private GameObject enemy;

    public bool isShovelRotate;
  

    //检测玩家碰撞
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = collision.gameObject;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            isEnemyInRange = true;
            enemy = collision.gameObject;
        }
        else
        {
            
        }           
    }
    //检测怪物碰撞
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            isEnemyInRange = false;
            enemy = null;
        }
        else
        {

        }
    }
    void Start()
    {
    }
    void Update()
    { 
        //玩家碰到铲子
        if (player != null && isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {

            PlayerAudio.playerAudio.playerPcikAduio();
            PlayerPickEquip playerPickEquip = player.GetComponent<PlayerPickEquip>();
            if (playerPickEquip!=null)
            {
                playerPickEquip.pickEquip(gameObject);
            }
        }
        //怪物碰到铲子
        if (isEnemyInRange && enemy != null&&isShovelRotate)
        {
            EnemyTakeDamage enemyTakeDamage = enemy.GetComponent<EnemyTakeDamage>();
            enemyTakeDamage.takeDamage(5);
            //Debug.Log("怪物受伤一次");
        }
     
    }
}
