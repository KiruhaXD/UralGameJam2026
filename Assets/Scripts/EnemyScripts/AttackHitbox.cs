using System;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{    
    [SerializeField] PlayerHealth playerHealth;

    public void ApplyDamage(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (playerHealth.healthCount > 0)
        {
            playerHealth.healthCount -= damage;

            if (playerHealth.healthCount <= 0) 
            {
                playerHealth.healthCount = 0;
                // влючить меню для перезапуса игры
            }


            playerHealth.textHealth.text = playerHealth.healthCount.ToString();
        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();

    }
}
