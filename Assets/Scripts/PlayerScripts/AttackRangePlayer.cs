using System.Collections;
using Assets.Scripts.PlayerScripts;
using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    [SerializeField] CheckNotactiveEnemys checkNotactiveEnemys;

    [SerializeField] Animator brotherAnimator;
    [SerializeField] Animator playerAnimator;

    [SerializeField] GameObject brotherModel;

    [SerializeField] PlayerController playerController;
    [SerializeField] BrotherRobotController brotherRobotController;
    [SerializeField] MenuPause menuPause;

    [SerializeField] AttackRangeBrother attackRangeBrother;

    [SerializeField] RepairRobotBrotherController repairRobotBrother;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;
    [SerializeField] ChoiseEffectController choiseEffectController;

    public bool isPunch = false;

    private void Update()
    {
        if (menuPause.pauseMenuActive == false && choiseEffectController.menuChoiseEffectActive == false) 
        {
            if (Input.GetMouseButtonDown(0) && repairRobotBrother.isCheckBrokenRobot == false /*&& isCanPunchPlayer == true && attackRangeBrother.isCanPunchBrother == true*/)
            {

                Punch();

                if (brotherModel.activeSelf == true)
                    attackRangeBrother.PunchBrother();
            }
        }

        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Punching") &&
playerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .7f)
        {
            playerAnimator.SetBool("isPunching", false);

            isPunch = false;
        }

        if (brotherModel.activeSelf == true) 
        {
            if (brotherAnimator.GetCurrentAnimatorStateInfo(0).IsName("Punching") &&
brotherAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .7f)
            {
                brotherAnimator.SetBool("isPunching", false);

                attackRangeBrother.isPunch = false;
            }
        }


        checkNotactiveEnemys.CheckDisableEnemyFirstWave();
        checkNotactiveEnemys.CheckDisableEnemySecondWave();
        checkNotactiveEnemys.CheckDisableEnemyThirdWave();
        checkNotactiveEnemys.CheckDisableEnemyFourthWave();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //isCanPunchPlayer = true;

            //attackRangeBrother.isCanPunchBrother = true;

            if (brotherModel.activeSelf == true)
                brotherAnimator.SetBool("isBattleReady", true);

            //attackRangeBrother.RotateBodyToEnemys();

            playerAnimator.SetBool("isBattleReady", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //isCanPunchPlayer = false;
            //attackRangeBrother.isCanPunchBrother = false;

            FightNonactive();

            if (brotherModel.activeSelf == true)
                attackRangeBrother.FightNonactiveBrother();
        }
    }

    private void Punch()
    {
        isPunch = true;

        playerAnimator.SetBool("isRunningKeyboardInput", false);

        playerAnimator.SetBool("isPunching", true);
        choiseEffectAttack.EffectsAttack(choiseEffectAttack.currentEffect);
    }

    public void FightNonactive()
    {
        playerAnimator.SetBool("isPunching", false);
        //playerAnimator.SetBool("isBattleReady", false);

        isPunch = false;
    }
}
