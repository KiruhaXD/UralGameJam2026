using UnityEngine;

public class AttackRangeEnemy : MonoBehaviour
{ 
    public Animator animatorEnemy;
    public FollowRange followRange;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("BrotherRobot")) 
        {
            followRange.isFollowing = false;

            animatorEnemy.SetBool("isRunning", false);

            animatorEnemy.SetBool("isBattleReady", true);
            animatorEnemy.SetBool("isPunching", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("BrotherRobot"))
        {
            followRange.isFollowing = true;

            animatorEnemy.SetBool("isRunning", true);

            animatorEnemy.SetBool("isBattleReady", false);
            animatorEnemy.SetBool("isPunching", false);
        }
    }

}
