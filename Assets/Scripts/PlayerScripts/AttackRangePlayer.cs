using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    bool isCanPunch = false;

    private void Update()
    {
        if (CheckHitboxTriggerEnemy.isDeadEnemy == true)
            FightNonactive();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            isCanPunch = true;

            if (Input.GetMouseButtonDown(0) && isCanPunch == true)
                Punch();

            //playerAnimator.SetBool("isRunningMouseInput", false);
            //playerAnimator.SetBool("isRunningKeyboardInput", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FightNonactive();
        }
    }

    private void Punch()
    {
        playerAnimator.SetBool("isBattleReady", true);
        playerAnimator.SetBool("isPunching", true);
    }

    public void FightNonactive() 
    {
        isCanPunch = false;

        //playerAnimator.SetBool("isRunningMouseInput", true);
        //playerAnimator.SetBool("isRunningKeyboardInput", true);

        playerAnimator.SetBool("isBattleReady", false);
        playerAnimator.SetBool("isPunching", false);
    }
}
