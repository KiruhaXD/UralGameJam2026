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

        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
