using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] AttackRangeEnemy attackRangeEnemy;
    [SerializeField] FollowRange followRange;

    [Header("Audio")]
    [SerializeField] AudioSource audioDeath;

    [Header("Animator")]
    [SerializeField] Animator enemyAnimator;

    public IEnumerator DeathCoroutine() 
    {
        attackRangeEnemy.enabled = false;
        followRange.enabled = false;

        enemyAnimator.SetBool("isPunching", false);
        enemyAnimator.SetBool("isBattleReady", false);
        enemyAnimator.SetBool("isRunning", false);

        // анимация смерти
        enemyAnimator.SetBool("isDie", true);

        audioDeath.Play();

        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }
}
