using System;
using UnityEngine;
using System.Collections;

public class CheckHitboxTriggerBrother : MonoBehaviour
{
    [SerializeField] BrotherRobotHealth brotherHealth;
    [SerializeField] BrotherRobotController brotherController;

    [SerializeField] int damageCountToBrother = 10;

    [SerializeField] Animator brotherAnimator;

    public void ApplyDamageBrotherRobot(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (brotherHealth.sliderArmor.value > 0)
        {
            brotherHealth.sliderArmor.value -= damage;

            TakeHit();

            if (brotherHealth.sliderArmor.value <= 0) 
            {
                brotherHealth.sliderArmor.value = 0;
                brotherHealth.fillSliderArmor.gameObject.SetActive(false);
            }


        }

        if (brotherHealth.sliderArmor.value == 0 && brotherHealth.sliderHealth.value > 0) 
        {
            brotherHealth.sliderHealth.value -= damage;

            TakeHit();

            if (brotherHealth.sliderHealth.value <= 0) 
            {
                brotherHealth.sliderHealth.value = 0;
                brotherHealth.fillSliderHealth.gameObject.SetActive(false);
                //brotherController.enabled = false;
                // анимация смерти и отключить скрипты чтоб он не двигался
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

    public void TakeHit()
    {
        brotherAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.5f);
        brotherAnimator.SetBool("isHit", false);
    }
}
