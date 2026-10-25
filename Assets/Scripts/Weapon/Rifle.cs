using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rifle : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private GameObject player;

    private int maxBulletCount=5;
    public int currentBulletCount;

    //玩家拾取触发检测
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            player = collision.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            player = null;
        }
    }
    void Start()
    {
        currentBulletCount = maxBulletCount;
    }
    void Update()
    {
        //玩家碰到冲锋枪
        if (player != null && isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            WeaponManager.weaponManager.BulletCountText.text = string.Format("/{0}", currentBulletCount);
            PlayerAudio.playerAudio.playerPcikAduio();
            PlayerPickEquip playerPickEquip = player.GetComponent<PlayerPickEquip>();
            if (playerPickEquip != null)
            {
                playerPickEquip.pickEquip(gameObject);
            }
        }
    }
}
