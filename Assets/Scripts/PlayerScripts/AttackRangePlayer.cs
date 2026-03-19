using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    public bool isCanPunch = false;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;

    private void Update()
    {
        if (CheckHitboxTriggerEnemy.isDeadEnemy == true)
            FightNonactive();

        if (Input.GetMouseButtonDown(0) && isCanPunch == true)
            Punch();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunch = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            //playerAnimator.SetBool("isRunningMouseInput", false);
            //playerAnimator.SetBool("isRunningKeyboardInput", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunch = false;

            FightNonactive();
        }
    }

    private void Punch()
    {
        playerAnimator.SetBool("isBattleReady", true);
        playerAnimator.SetBool("isPunching", true);

        choiseEffectAttack.EffectsAttack(choiseEffectAttack.currentEffect);
    }

    public void FightNonactive() 
    {
        //playerAnimator.SetBool("isRunningMouseInput", true);
        //playerAnimator.SetBool("isRunningKeyboardInput", true);

        playerAnimator.SetBool("isBattleReady", false);
        playerAnimator.SetBool("isPunching", false);
    }
}
