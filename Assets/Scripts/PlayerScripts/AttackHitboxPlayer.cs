using System;
using UnityEngine;

public class AttackHitboxPlayer : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;

    public void ApplyDamage(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (playerHealth.sliderHealth.value > 0)
        {
            playerHealth.sliderHealth.value -= damage;

            playerHealth.TakeHit();

            if (playerHealth.sliderHealth.value <= 0)
            {
                playerHealth.sliderHealth.value = 0;
                // влючить меню для перезапуса игры
            }

        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();

    }
}
