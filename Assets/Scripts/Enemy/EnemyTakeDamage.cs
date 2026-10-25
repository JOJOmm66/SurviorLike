using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyTakeDamage : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public float lastTakeDamageTime;

    public SpriteRenderer spriteRenderer;
    public Sprite hitSprite;

    public Sprite deadSprite;

    public Animator animator;

    public EnemyController enemyController;

    public EnemyAudio enemyAudio;
    //怪物受伤（协程）
    public IEnumerator HitFlash ()
    {
        animator.enabled = false;
        spriteRenderer.sprite = hitSprite;
        yield return new WaitForSeconds(0.1f);
        animator.enabled = true;
    }
    //怪物死亡（协程）
    public IEnumerator DeadToDisappear()
    {
        yield return new WaitForSeconds(0.1f);
        animator.enabled = false;
        spriteRenderer.sprite = deadSprite;
        enemyController.enabled = false;
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
    //
    public void takeDamage(int damage)
    {
        if (currentHealth <= 0) return;
        if (Time.time - lastTakeDamageTime > 0.4f)
        {
            lastTakeDamageTime = Time.time;
            currentHealth -= damage;
            enemyAudio.enemyTakeHitAudio();
            if (currentHealth <= 0)
            {
                StartCoroutine(HitFlash());
                StartCoroutine(DeadToDisappear());
                KillCount.currentKillCount += 1;
                return;
            }
            StartCoroutine(HitFlash());
        }
    }
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
        enemyAudio = GetComponent<EnemyAudio>();
    }
    void Update()
    {
        
    }
}
