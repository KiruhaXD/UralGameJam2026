using System;
using UnityEngine;

public class AttackHitboxToEnemy : MonoBehaviour
{

    [SerializeField] EnemyHealth[] enemysHealth;

    [SerializeField] int damageCountToEnemy = 10;

    public static bool isDeadEnemy = false;


    public void ApplyDamageEnemy(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        for (int i = 0; i < enemysHealth.Length; i++)
        {
            /*if (enemysHealth[i - enemysHealth[i].currentNumberEnemy].sliderHealth.value > 0)
            {
                enemysHealth[i - enemysHealth[i].currentNumberEnemy].sliderHealth.value -= damage;

                if (enemysHealth[i - enemysHealth[i].currentNumberEnemy].sliderHealth.value <= 0)
                {
                    enemysHealth[i - enemysHealth[i].currentNumberEnemy].sliderHealth.value = 0;

                    isDeadEnemy = true;
                }
            }*/

            if (damage < 0)
                throw new ArgumentOutOfRangeException();
        }

    }
}
