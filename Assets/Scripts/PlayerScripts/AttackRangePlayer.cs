using System.Collections;
using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    [SerializeField] CheckNotactiveEnemys checkNotactiveEnemys;

    [SerializeField] Animator brotherAnimator;
    [SerializeField] Animator playerAnimator;

    [SerializeField] GameObject brotherModel;

    [SerializeField] AttackRangeBrother attackRangeBrother;

    public bool isCanPunchPlayer = false;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanPunchPlayer == true && attackRangeBrother.isCanPunchBrother == true)
        {
            Punch();

            if (brotherModel.activeSelf == true)
                attackRangeBrother.PunchBrother();
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Punching") &&
playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9f)
        {
            playerAnimator.SetBool("isPunching", false);
        }

        if (brotherModel.activeSelf == true) 
        {
            if (brotherAnimator.GetCurrentAnimatorStateInfo(0).IsName("Punching") &&
brotherAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .9f)
            {

                brotherAnimator.SetBool("isPunching", false);
            }
        }


        checkNotactiveEnemys.CheckDisableEnemyFirstWave();
        checkNotactiveEnemys.CheckDisableEnemySecondWave();
        checkNotactiveEnemys.CheckDisableEnemyThirdWave();
        checkNotactiveEnemys.CheckDisableEnemyFourthWave();

        if (isCanPunchPlayer == false && attackRangeBrother.isCanPunchBrother == false) 
        {
            FightNonactive();

            if (brotherModel.activeSelf == true)
                attackRangeBrother.FightNonactiveBrother();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunchPlayer = true;

            attackRangeBrother.isCanPunchBrother = true;

            if (brotherModel.activeSelf == true)
                brotherAnimator.SetBool("isBattleReady", true);

            attackRangeBrother.RotateBodyToEnemys();

            playerAnimator.SetBool("isBattleReady", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunchPlayer = false;
            attackRangeBrother.isCanPunchBrother = false;

            FightNonactive();

            if (brotherModel.activeSelf == true)
                attackRangeBrother.FightNonactiveBrother();
        }
    }

    private void Punch()
    {
        playerAnimator.SetBool("isPunching", true);
        choiseEffectAttack.EffectsAttack(choiseEffectAttack.currentEffect);
    }

    public void FightNonactive()
    {
        playerAnimator.SetBool("isPunching", false);
        playerAnimator.SetBool("isBattleReady", false);
    }
}
