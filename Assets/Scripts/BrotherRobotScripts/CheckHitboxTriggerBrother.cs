using System;
using UnityEngine;

public class CheckHitboxTriggerBrother : MonoBehaviour
{
    [SerializeField] BrotherRobotHealth brotherHealth;

    [SerializeField] int damageCountToBrother = 10;

    public void ApplyDamageBrotherRobot(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (brotherHealth.sliderHealth.value > 0)
        {
            brotherHealth.sliderHealth.value -= damage;

            brotherHealth.TakeHit();

            if (brotherHealth.sliderHealth.value <= 0)
            {
                brotherHealth.sliderHealth.value = 0;
                // влючить меню для перезапуса игры
            }

        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitboxAttackEnemy"))
            ApplyDamageBrotherRobot(damageCountToBrother);
    }
}
