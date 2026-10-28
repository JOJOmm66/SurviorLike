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
    public PlayerState state;
    //状态机
    public enum PlayerState
    {
        IdleOrRun,
        Hit,
        Dead
    }
    public void EnterState(PlayerState next)
    {
        if (state == next) return;
        ExitState(state);
        state = next;
        ChangeState(state);
    }
    public void ChangeState(PlayerState next)
    {
        switch (state)
        {
            case PlayerState.Hit:
                PlayerAudio.playerAudio.playerTakeHitAduio();
                EnterState(PlayerState.IdleOrRun);
                break;
            case PlayerState.Dead:
                anim.SetTrigger("Die");
                Invoke("DeadToGameOver", 1.5f);
                PlayerAudio.playerAudio.playerLoseAudio();
                break;
        }
    }
    //目前退出状态不需要任何执行，但需保留
    public void ExitState(PlayerState next)
    {     
    }
    //玩家运动
    public void move()
    {
        float horizontalValue = Input.GetAxis("Horizontal");
        float verticalValue = Input.GetAxis("Vertical");
        if (horizontalValue <0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        Vector3 moveDirection = new Vector3(horizontalValue, verticalValue).normalized;
        this.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", moveDirection.magnitude);
    }
    //玩家受伤
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarSlider.value = currentHealth / maxHealth;
        if (currentHealth > 0)
        {
            EnterState(PlayerState.Hit);
        }
        else
        {
            EnterState(PlayerState.Dead);
        }
    }
    //玩家死亡，结束游戏
    public void DeadToGameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        imageLose.gameObject.SetActive(true);
    }
    //
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
        switch (state)
        {
            case PlayerState.IdleOrRun:
                move();
                break;
            case PlayerState.Dead:
                return;
        }
    }
}
