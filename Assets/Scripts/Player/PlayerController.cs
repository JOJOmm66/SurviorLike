using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public int moveSpeed = 10;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public float maxHealth = 20f;
    public float currentHealth;

    public Slider healthBarSlider;

    public GameObject gameOverCanvas;
    public Image imageLose;
    public bool isDead;
    //游戏结束语句
    public void DeadToGameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        imageLose.gameObject.SetActive(true);
        PlayerAudio.playerAudio.playerLoseAudio();
    }
    //玩家受伤
    public void takeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;
        PlayerAudio.playerAudio.playerTakeHitAduio();
        healthBarSlider.value = currentHealth/maxHealth;
        if (currentHealth <= 0)
        {
            isDead = true;
            anim.SetTrigger("Die");
            Invoke("DeadToGameOver", 1.5f);
        }
    }
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue=Input.GetAxis("Vertical");
        if (horizontalValue < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalValue > 0) 
        {
            spriteRenderer.flipX= false;
        }
        Vector3 moveDirection = new Vector3(horizontalValue,verticalValue).normalized;
        this.transform.Translate(moveDirection*moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", moveDirection.magnitude);
    }

}
