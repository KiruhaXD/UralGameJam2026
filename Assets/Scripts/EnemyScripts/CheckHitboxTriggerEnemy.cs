using System;
using UnityEngine;
using System.Collections;
using Assets.Scripts.PlayerScripts;

/// <summary>
/// Your summary
/// </summary>
public class CheckHitboxTriggerEnemy : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioSource audioRun;

    [Header("Player")]
    [SerializeField] AttackRangePlayer attackRangePlayer;

    [Header("Brother")]
    [SerializeField] AttackRangeBrother attackRangeBrother;

    [Header("Effects")]
    [SerializeField] ParticleSystem[] effectsTakeHit;
    [SerializeField] ChoiseEffectAttackPlayer choiseEffectAttackPlayer;
    [SerializeField] ChoiseEffectAttackBrother choiseEffectAttackBrother;

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

    public bool isDeadEnemy = false;

    public bool isTakeHit = false;

    public string hitboxTagName = string.Empty;

    public bool isTakeHitEffectIce, isTakeHitEffectShock, isTakeHitEffectFire = false;

    [Header("Ice Effect")]
    [SerializeField] ParticleSystem iceEffect;
    [SerializeField] float slowlySpeed = 1f;
    [SerializeField] int timeIceEffect = 10;

    [Header("Fire Effect")]
    [SerializeField] ParticleSystem effectFire;
    public float damageFire = 1;
    public int timeFireEffect = 10;

    public void ApplyDamageEnemy(int damage, string hitboxTagName) // вызывать у хитбокса руки в анимации через триггеры
    {
        if (enemyHealth.sliderHealth.value > 0)
        {
            enemyHealth.sliderHealth.value -= damage;

            this.hitboxTagName = hitboxTagName;

            if (this.hitboxTagName == "HitboxAttackPlayer" && choiseEffectAttackPlayer.currentNamePerson == "Player")
            {
                PlayEffectHit(choiseEffectAttackPlayer.currentEffect);
            }

            if (this.hitboxTagName == "HitboxAttackBrother" && choiseEffectAttackBrother.currentNamePerson == "Brother")
            {
                PlayEffectHit(choiseEffectAttackBrother.currentEffect);
            }


            TakeHit();

            Death();

        }

        if (damage < 0)
            throw new ArgumentOutOfRangeException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HitboxAttackPlayer") || other.CompareTag("HitboxAttackBrother") && enemy.currentNumberEnemy == currentNumberEnemy) 
        {
            ApplyDamageEnemy(damageCountToEnemy, other.tag);

            // Effect Hit Fire
            if (isTakeHitEffectFire == true)
            {
                //effectFire.Play();
                effectFire.gameObject.SetActive(true);

                Debug.Log(enemyHealth.sliderHealth.value);

                //timerEndEffect.StartCoroutine(timerEndEffect.Timer(timeFireEffect));

                StartCoroutine(TimerForFireEffect(timeFireEffect));
            }

            if (isTakeHitEffectIce == true) 
            {
                iceEffect.gameObject.SetActive(true);

                StartCoroutine(TimerForIceEffect(timeIceEffect));
            }
        } 

        
    }

    public void TakeHit()
    {
        isTakeHit = true;

        enemyAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.3f);
        enemyAnimator.SetBool("isHit", false);

        isTakeHit = false;

        StartCoroutine(ChoiseStopEffectHit());
    }

    IEnumerator ChoiseStopEffectHit() 
    {
        yield return new WaitForSeconds(.5f);

        if (this.hitboxTagName == "HitboxAttackPlayer" && choiseEffectAttackPlayer.currentNamePerson == "Player")
        {
            StopEffectHit(choiseEffectAttackPlayer.currentEffect);
        }

        if (this.hitboxTagName == "HitboxAttackBrother" && choiseEffectAttackBrother.currentNamePerson == "Brother")
        {
            StopEffectHit(choiseEffectAttackBrother.currentEffect);
        }
    }

    public void PlayEffectHit(int currentEffect) 
    {
        switch (currentEffect)
        {
            case 1:
                effectsTakeHit[0].gameObject.SetActive(true);
                effectsTakeHit[0].Play();

                isTakeHitEffectIce = true;
                break;

            case 2:
                effectsTakeHit[1].gameObject.SetActive(true);
                effectsTakeHit[1].Play();

                isTakeHitEffectShock = true;
                break;

            case 3:
                effectsTakeHit[2].gameObject.SetActive(true);
                effectsTakeHit[2].Play();

                isTakeHitEffectFire = true;
                break;
        }
    }

    public void StopEffectHit(int currentEffect) 
    {
        switch (currentEffect)
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

    public IEnumerator TimerForFireEffect(int startTime)
    {
        while (startTime > 0)
        {
            yield return new WaitForSeconds(1);
            startTime--;

            enemyHealth.sliderHealth.value -= damageFire;

            if (startTime <= 0)
                startTime = 0;

            if (enemyHealth.sliderHealth.value == 0)
            {
                isTakeHitEffectFire = false;
                //effectFire.Stop();
                effectFire.gameObject.SetActive(false);

                Death();
            }

        }

        yield return new WaitForSeconds(1);
    }

    public IEnumerator TimerForIceEffect(int startTime)
    {
        while (startTime > 0)
        {
            yield return new WaitForSeconds(1);
            startTime--;

            //enemyHealth.sliderHealth.value -= damageFire;

            if (startTime <= 0)
                startTime = 0;

            /*if (enemyHealth.sliderHealth.value == 0)
            {
                isTakeHitEffectFire = false;
                //effectFire.Stop();
                effectFire.gameObject.SetActive(false);

                Death();
            }*/

        }

        yield return new WaitForSeconds(1);
    }

    public void Death() 
    {
        if (enemyHealth.sliderHealth.value <= 0)
        {
            enemyHealth.sliderHealth.value = 0;

            isDeadEnemy = true;

            enemyDeath.StartCoroutine(enemyDeath.DeathCoroutine());
            //enemyObject.gameObject.SetActive(false);

            attackRangePlayer.isCanPunchPlayer = false;

            attackRangePlayer.FightNonactive();
            attackRangeBrother.FightNonactiveBrother();

            audioRun.Stop();

            // анимация смерти
            spawnItems.Spawn();
        }
    }
}
