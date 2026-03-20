using System;
using UnityEngine;
using System.Collections;

public class CheckHitboxTriggerEnemy : MonoBehaviour
{
    [Header("Spawn Items")]
    [SerializeField] SpawnItems spawnItems;

    [Header("Animator")]
    [SerializeField] Animator enemyAnimator;

    [Header("Enemy Prefab")]
    [SerializeField] GameObject enemyObject;

    [Header("Enemy Scripts")]
    [SerializeField] Enemy enemy;
    [SerializeField] EnemyHealth enemyHealth;

    [Header("Settings")]
    [SerializeField] int damageCountToEnemy = 10;
    [SerializeField] int currentNumberEnemy = 0;
    public static bool isDeadEnemy = false;

    public void ApplyDamageEnemy(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (enemyHealth.sliderHealth.value > 0)
        {
            enemyHealth.sliderHealth.value -= damage;

            TakeHit();

            if (enemyHealth.sliderHealth.value <= 0)
            {
                enemyHealth.sliderHealth.value = 0;

                isDeadEnemy = true;
                enemyObject.gameObject.SetActive(false);

                spawnItems.Spawn();
            }

        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitboxAttackPlayer") || other.CompareTag("HitboxAttackBrother") && enemy.currentNumberEnemy == currentNumberEnemy) 
            ApplyDamageEnemy(damageCountToEnemy);
        
    }

    public void TakeHit()
    {
        enemyAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.5f);
        enemyAnimator.SetBool("isHit", false);
    }
}
