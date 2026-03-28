using UnityEngine;

public class CheckNotactiveEnemys : MonoBehaviour
{
    [SerializeField] AttackRangePlayer attackRangePlayer;
    [SerializeField] AttackRangeBrother attackRangeBrother;
    [SerializeField] GameObject brotherModel;

    [Header("First Wave")]
    [SerializeField] GameObject[] enemysFirstWave;

    [Header("Second Wave")]
    [SerializeField] GameObject[] enemysSecondWave;

    [Header("Third Wave")]
    [SerializeField] GameObject[] enemysThirdWave;

    [Header("Fourth Wave")]
    [SerializeField] GameObject[] enemysFourthWave;
    [SerializeField] GameObject enemyBossFourthWave;

    public bool checkNotactiveEnemysFirstWave = false, checkNotactiveEnemysSecondWave = false, 
        checkNotactiveEnemysThirdWave = false, checkNotactiveEnemysFourthWave = false;

    public void CheckDisableEnemyFirstWave()
    {
        if (checkNotactiveEnemysFirstWave == false) 
        {
            if (enemysFirstWave[0].activeSelf == false || enemysFirstWave[1].activeSelf == false
    || enemysFirstWave[2].activeSelf == false || enemysFirstWave[3].activeSelf == false)
            {
                //attackRangePlayer.isCanPunchPlayer = false;
                //attackRangeBrother.isCanPunchBrother = false;

                checkNotactiveEnemysFirstWave = true;
            }
        }

        CheckPunch();
    }

    public void CheckDisableEnemySecondWave()
    {
        if (checkNotactiveEnemysSecondWave == false)
        {
            if (enemysSecondWave[0].activeSelf == false || enemysSecondWave[1].activeSelf == false
            || enemysSecondWave[2].activeSelf == false || enemysSecondWave[3].activeSelf == false)
            {
                //attackRangePlayer.isCanPunchPlayer = false;
                //attackRangeBrother.isCanPunchBrother = false;

                checkNotactiveEnemysSecondWave = true;
            }
        }

        CheckPunch();
    }

    public void CheckDisableEnemyThirdWave()
    {
        if (checkNotactiveEnemysThirdWave == false)
        {
            if (enemysThirdWave[0].activeSelf == false || enemysThirdWave[1].activeSelf == false
            || enemysThirdWave[2].activeSelf == false || enemysThirdWave[3].activeSelf == false)
            {
                //attackRangePlayer.isCanPunchPlayer = false;
                //attackRangeBrother.isCanPunchBrother = false;

                checkNotactiveEnemysThirdWave = true;
            }
        }

        CheckPunch();
    }

    public void CheckDisableEnemyFourthWave()
    {
        if (checkNotactiveEnemysFourthWave == false)
        {
            if (enemyBossFourthWave.activeSelf == false || enemysFourthWave[0].activeSelf == false || enemysFourthWave[1].activeSelf == false
            || enemysFourthWave[2].activeSelf == false || enemysFourthWave[3].activeSelf == false)
            {
                //attackRangePlayer.isCanPunchPlayer = false;
                //attackRangeBrother.isCanPunchBrother = false;

                checkNotactiveEnemysFourthWave = true;
            }
        }

        CheckPunch();
    }

    public void CheckPunch() 
    {
        /*if (attackRangePlayer.isCanPunchPlayer == false && attackRangeBrother.isCanPunchBrother == false)
        {
            attackRangePlayer.FightNonactive();

            if (brotherModel.activeSelf == true)
                attackRangeBrother.FightNonactiveBrother();
        }*/
    }
}
