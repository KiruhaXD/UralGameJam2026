using System.Collections;
using UnityEngine;

public class FollowRange : MonoBehaviour
{
    [SerializeField] CheckHitboxTriggerEnemy checkHitboxTriggerEnemy;
    [SerializeField] TimerEndEffect timerEndEffect;
    [SerializeField] ParticleSystem iceEffect;

    [Header("Settings")]
    [SerializeField] float slowlySpeed = 1f;
    [SerializeField] int timer = 5;

    [Header("Enemy")]
    [SerializeField] CharacterController enemyContoller;
    [SerializeField] Enemy enemy;

    [SerializeField] Transform enemyPosition;
    [SerializeField] Transform enemyRotation;

    [SerializeField] Animator animatorEnemy;

    [Header("Player")]
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform playerRotation;

    public bool isFollowing = false;

    private void Update()
    {
        if (isFollowing == true) 
        {
            if (checkHitboxTriggerEnemy.isTakeHitEffectIce == false)
                MoveEnemy();

            if (checkHitboxTriggerEnemy.isTakeHitEffectIce == true)
            {
                SlowlyMoveEnemy();

                if (timer == 0)
                {
                    iceEffect.Stop();

                    checkHitboxTriggerEnemy.isTakeHitEffectIce = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animatorEnemy.SetBool("isRunning", true);
            isFollowing = true;
        }
    }

    public void MoveEnemy()
    {
        Vector3 moveEnemyToPlayer = (playerPosition.position - enemyPosition.position) / enemy.speedEnemy * Time.deltaTime;

        enemyContoller.Move(moveEnemyToPlayer * enemy.speedEnemy);

        RotateEnemy();

    }

    public void SlowlyMoveEnemy() 
    {
        iceEffect.Play();

        Vector3 moveEnemyToPlayer = (playerPosition.position - enemyPosition.position) / slowlySpeed * Time.deltaTime;

        enemyContoller.Move(moveEnemyToPlayer * slowlySpeed);

        RotateEnemy();

        StartCoroutine(timerEndEffect.Timer(timer));
    }


    public void RotateEnemy()
    {
        enemyRotation.LookAt(playerRotation.position);
    }

}
