using UnityEngine;
using System.Collections;

public class AttackRangeBrother : MonoBehaviour
{
    [SerializeField] Animator brotherAnimator;

    [Header("Brother Rotation")]
    [SerializeField] Transform brotherRotation;

    [Header("Enemys Position")]
    [SerializeField] Transform[] enemysPosition;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;

    public bool isPunch = false;

    public void PunchBrother()
    {
        isPunch = true;

        brotherAnimator.SetBool("isRunningKeyboardInput", false);

        brotherAnimator.SetBool("isPunching", true);

        choiseEffectAttack.EffectsAttack(choiseEffectAttack.currentEffect);
    }

    public void FightNonactiveBrother()
    {
        brotherAnimator.SetBool("isPunching", false);
        //brotherAnimator.SetBool("isBattleReady", false);

        isPunch = false;
    }

    /*public void RotateBodyToEnemys()
    {
        for (int i = 0; i < enemysPosition.Length; i++)
            brotherRotation.LookAt(enemysPosition[i].position);

    }*/
}
