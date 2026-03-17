using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    bool isCanPunch = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanPunch == true)
            Punch();

        if (AttackHitboxEnemy.isDead == true)
            FightNonactive();
    }

    private void Punch() 
    {
        playerAnimator.SetBool("isBattleReady", true);
        playerAnimator.SetBool("isPunching", true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            isCanPunch = true;

            playerAnimator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FightNonactive();
        }
    }

    public void FightNonactive() 
    {
        isCanPunch = false;

        playerAnimator.SetBool("isRunning", true);

        playerAnimator.SetBool("isBattleReady", false);
        playerAnimator.SetBool("isPunching", false);
    }
}
