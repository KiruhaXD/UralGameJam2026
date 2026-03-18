using UnityEngine;

public class FollowRange : MonoBehaviour
{
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

    Vector3 moveEnemyToPlayer;

    private void Update()
    {
        if (isFollowing == true) 
        {
            //enemy.EnemyRay();
            MoveEnemy();
            //RotateEnemy();
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
        moveEnemyToPlayer = (playerPosition.position - enemyPosition.position) / enemy.speedEnemy * Time.deltaTime;

        enemyContoller.Move(moveEnemyToPlayer * enemy.speedEnemy);

    }


    public void RotateEnemy()
    {
        //enemyRotation.localRotation = Quaternion.Euler(0, xRotationLimitEnemy, 0);

        transform.Rotate(new Vector3(0f, moveEnemyToPlayer.x, 0f));
    }
}
