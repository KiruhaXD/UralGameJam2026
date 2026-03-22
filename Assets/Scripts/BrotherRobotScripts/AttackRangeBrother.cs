using UnityEngine;

public class AttackRangeBrother : MonoBehaviour
{
    [SerializeField] Animator brotherAnimator;

    public bool isCanPunch = false;

    [Header("Brother Rotation")]
    [SerializeField] Transform brotherRotation;

    [Header("Enemys Position")]
    [SerializeField] Transform[] enemysPosition;

    [SerializeField] ChoiseEffectAttack choiseEffectAttack;

    private void Update()
    {
        if (CheckHitboxTriggerEnemy.isDeadEnemy == true)
        {
            isCanPunch = false;
        }
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
            RotateBodyToEnemys();

            //brotherAnimator.SetBool("isRunningMouseInput", false);
            //brotherAnimator.SetBool("isRunningKeyboardInput", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") || (other.gameObject.activeSelf == false && other.CompareTag("Enemy")))
        {
            isCanPunch = false;

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
        //brotherAnimator.SetBool("isRunningMouseInput", true);
        //brotherAnimator.SetBool("isRunningKeyboardInput", true);

        brotherAnimator.SetBool("isBattleReady", false);
        brotherAnimator.SetBool("isPunching", false);
    }

    public void RotateBodyToEnemys()
    {
        for (int i = 0; i < enemysPosition.Length; i++)
            brotherRotation.LookAt(enemysPosition[i].position);

    }
}
