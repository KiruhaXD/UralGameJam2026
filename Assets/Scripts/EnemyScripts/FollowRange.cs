using System.Collections;
using UnityEngine;

public class FollowRange : MonoBehaviour
{
    [SerializeField] MenuPause menuPause;

    [SerializeField] CheckHitboxTriggerEnemy checkHitboxTriggerEnemy;

    [Header("Audio")]
    [SerializeField] AudioSource audioRun;

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

    [Header("Ice Effect")]
    [SerializeField] ParticleSystem iceEffect;
    [SerializeField] float slowlySpeed = 1f;
    [SerializeField] int timeIceEffect = 10;

    private void Update()
    {
        if (isFollowing == true) 
        {
            if (menuPause.countPressKeyEscape == 0 || checkHitboxTriggerEnemy.isTakeHitEffectIce == false) 
                MoveEnemy();
        }

        else
            audioRun.Stop();



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

        if (checkHitboxTriggerEnemy.isTakeHitEffectIce == true)
        {
            iceEffect.gameObject.SetActive(true);

            StartCoroutine(TimerForIceEffect(timeIceEffect));

            enemyContoller.Move(moveEnemyToPlayer * slowlySpeed);
        }

        else
            enemyContoller.Move(moveEnemyToPlayer * enemy.speedEnemy);

        RotateEnemy();

        if (audioRun.isPlaying) return;
        audioRun.Play();

    }

    public void RotateEnemy()
    {
        enemyRotation.LookAt(playerRotation.position);
    }

    public IEnumerator TimerForIceEffect(int startTime)
    {
        while (startTime > 0)
        {
            yield return new WaitForSeconds(1);
            startTime--;

            if (startTime <= 0)
                startTime = 0;

            if (startTime == 0) 
            {
                checkHitboxTriggerEnemy.isTakeHitEffectIce = false;
                iceEffect.gameObject.SetActive(false);
            }

        }

        yield return new WaitForSeconds(1);
    }

}
