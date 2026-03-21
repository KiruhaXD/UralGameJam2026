using System.Collections;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] AttackRangeEnemy attackRangeEnemy;
    [SerializeField] FollowRange followRange;

    public IEnumerator DeathCoroutine() 
    {
        attackRangeEnemy.enabled = false;
        followRange.enabled = false;

        yield return new WaitForSeconds(.5f);
        this.gameObject.SetActive(false);
    }
}
