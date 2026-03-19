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
            RotateBodyToEnemys();

            //brotherAnimator.SetBool("isRunningMouseInput", false);
            //brotherAnimator.SetBool("isRunningKeyboardInput", false);
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
        brotherAnimator.SetBool("isBattleReady", true);
        brotherAnimator.SetBool("isPunching", true);
    }

    public void FightNonactive()
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
