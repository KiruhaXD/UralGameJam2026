using UnityEngine;

public class AttackRangeBrother : MonoBehaviour
{
    [SerializeField] Animator brotherAnimator;

    public bool isCanPunchBrother = false;

    [Header("Brother Rotation")]
    [SerializeField] Transform brotherRotation;

    [Header("Enemys Position")]
    [SerializeField] Transform[] enemysPosition;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;

    public void PunchBrother()
    {
        brotherAnimator.SetBool("isPunching", true);

        choiseEffectAttack.EffectsAttack(choiseEffectAttack.currentEffect);
    }

    public void FightNonactiveBrother()
    {
        brotherAnimator.SetBool("isBattleReady", false);
        brotherAnimator.SetBool("isPunching", false);
    }

    public void RotateBodyToEnemys()
    {
        for (int i = 0; i < enemysPosition.Length; i++)
            brotherRotation.LookAt(enemysPosition[i].position);

    }
}
