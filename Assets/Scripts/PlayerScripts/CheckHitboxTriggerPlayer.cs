using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.PlayerScripts;

public class CheckHitboxTriggerPlayer : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] PlayerController playerController;

    [SerializeField] int damageCountToPlayer = 10;

    [SerializeField] Animator playerAnimator;

    [SerializeField] MenuPause menuPause;

    public void ApplyDamagePlayer(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (playerHealth.sliderArmor.value > 0)
        {
            playerHealth.sliderArmor.value -= damage;

            TakeHit();

            if (playerHealth.sliderArmor.value <= 0) 
            {
                playerHealth.sliderArmor.value = 0;
                playerHealth.fillSliderArmor.gameObject.SetActive(false);
            }

            
        }

        if (playerHealth.sliderArmor.value == 0 && playerHealth.sliderHealth.value > 0)
        {
            playerHealth.sliderHealth.value -= damage;

            TakeHit();

            if (playerHealth.sliderHealth.value <= 0)
            {
                playerHealth.sliderHealth.value = 0;
                playerHealth.fillSliderHealth.gameObject.SetActive(false);
                playerController.enabled = false;
                menuPause.Pause();
                // влючить меню для перезапуса игры
            }
        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitboxAttackEnemy"))
            ApplyDamagePlayer(damageCountToPlayer);
    }


    public void TakeHit()
    {
        playerAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.5f);
        playerAnimator.SetBool("isHit", false);
    }
}
