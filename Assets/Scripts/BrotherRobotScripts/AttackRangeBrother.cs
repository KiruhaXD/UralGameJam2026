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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunchBrother = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            RotateBodyToEnemys();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunchBrother = false;

            FightNonactiveBrother();
        }
    }

    public void PunchBrother()
    {
        brotherAnimator.SetBool("isBattleReady", true);
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
