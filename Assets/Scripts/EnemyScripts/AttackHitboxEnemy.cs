using System;
using UnityEngine;

public class AttackHitboxEnemy : MonoBehaviour
{    
    [SerializeField] EnemyHealth enemyHealth;

    public static bool isDead = false;

    public void ApplyDamage(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (enemyHealth.sliderHealth.value > 0)
        {
            enemyHealth.sliderHealth.value -= damage;

            enemyHealth.TakeHit();

            if (enemyHealth.sliderHealth.value <= 0) 
            {
                enemyHealth.sliderHealth.value = 0;
                this.gameObject.SetActive(false); // смерть врага

                isDead = true;
                // влючить меню для перезапуса игры
            }
        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();

    }
}
