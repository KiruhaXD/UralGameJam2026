using System;
using UnityEngine;

public class CheckHitboxTriggerEnemy : MonoBehaviour
{
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

            enemyHealth.TakeHit();

            if (enemyHealth.sliderHealth.value <= 0)
            {
                enemyHealth.sliderHealth.value = 0;

                isDeadEnemy = true;
                enemyObject.gameObject.SetActive(false);
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
}
