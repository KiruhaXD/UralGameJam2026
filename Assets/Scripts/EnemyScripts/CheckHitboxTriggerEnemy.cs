using System;
using UnityEngine;
using System.Collections;

public class CheckHitboxTriggerEnemy : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] ParticleSystem[] effectsTakeHit;
    [SerializeField] ChoiseEffectAttack[] choiseEffectAttack;

    [Header("Spawn Items")]
    [SerializeField] SpawnItems spawnItems;

    [Header("Animator")]
    [SerializeField] Animator enemyAnimator;

    [Header("Enemy Prefab")]
    [SerializeField] GameObject enemyObject;

    [Header("Enemy Scripts")]
    [SerializeField] Enemy enemy;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] EnemyDeath enemyDeath;

    [Header("Settings")]
    [SerializeField] int damageCountToEnemy = 10;
    [SerializeField] int currentNumberEnemy = 0;
    public static bool isDeadEnemy = false;

    public bool isTakeHit = false;

    public void ApplyDamageEnemy(int damage) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (enemyHealth.sliderHealth.value > 0)
        {
            enemyHealth.sliderHealth.value -= damage;

            PlayEffectHit();

            TakeHit();

            if (enemyHealth.sliderHealth.value <= 0)
            {
                enemyHealth.sliderHealth.value = 0;

                isDeadEnemy = true;

                enemyDeath.StartCoroutine(enemyDeath.DeathCoroutine());
                //enemyObject.gameObject.SetActive(false);
                // анимация смерти
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
        isTakeHit = true;

        StartCoroutine(StopEffectHit());

        enemyAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.3f);
        enemyAnimator.SetBool("isHit", false);

        isTakeHit = false;
    }

    public void PlayEffectHit() 
    {
        for (int i = 0; i < choiseEffectAttack.Length; i++)
        {
            switch (choiseEffectAttack[i].currentEffect)
            {
                case 1:
                    effectsTakeHit[0].gameObject.SetActive(true);
                    effectsTakeHit[0].Play();
                    break;

                case 2:
                    effectsTakeHit[1].gameObject.SetActive(true);
                    effectsTakeHit[1].Play();
                    break;

                case 3:
                    effectsTakeHit[2].gameObject.SetActive(true);
                    effectsTakeHit[2].Play();
                    break;
            }

        }
    }

    IEnumerator StopEffectHit() 
    {
        yield return new WaitForSeconds(.5f);

        for (int i = 0; i < choiseEffectAttack.Length; i++)
        {
            switch (choiseEffectAttack[i].currentEffect)
            {
                case 1:
                    effectsTakeHit[0].Stop();
                    effectsTakeHit[0].gameObject.SetActive(false);
                    break;

                case 2:
                    effectsTakeHit[1].Stop();
                    effectsTakeHit[1].gameObject.SetActive(false);
                    break;

                case 3:
                    effectsTakeHit[2].Stop();
                    effectsTakeHit[2].gameObject.SetActive(false);
                    break;
            }
        }
    }

}
