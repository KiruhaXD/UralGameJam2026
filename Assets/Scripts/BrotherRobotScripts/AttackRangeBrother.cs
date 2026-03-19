using UnityEngine;

public class AttackRangeBrother : MonoBehaviour
{
    [SerializeField] Animator brotherAnimator;

    bool isCanPunch = false;

    [Header("Brother Rotation")]
    [SerializeField] Transform brotherRotation;

    [Header("Enemys Position")]
    [SerializeField] Transform[] enemysPosition;

    private void Update()
    {
        if (CheckHitboxTriggerEnemy.isDeadEnemy == true)
            FightNonactive();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            RotateBodyToEnemys();

            isCanPunch = true;

            if (Input.GetMouseButtonDown(0) && isCanPunch == true)
                Punch();

            //brotherAnimator.SetBool("isRunningMouseInput", false);
            //brotherAnimator.SetBool("isRunningKeyboardInput", false);
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
        brotherAnimator.SetBool("isBattleReady", true);
        brotherAnimator.SetBool("isPunching", true);
    }

    public void FightNonactive()
    {
        isCanPunch = false;

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
