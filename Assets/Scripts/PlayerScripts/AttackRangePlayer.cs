using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    [SerializeField] AttackRangeBrother attackRangeBrother;

    public bool isCanPunch = false;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanPunch == true) 
        {
            Punch();
            attackRangeBrother.PunchBrother();
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCanPunch = false;

            FightNonactive();
            attackRangeBrother.FightNonactiveBrother();
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
        playerAnimator.SetBool("isBattleReady", false);
        playerAnimator.SetBool("isPunching", false);
    }
}
