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

    float xRotationLimitEnemy;

    private void Update()
    {
        if (isFollowing == true) 
        {
            MoveEnemy();
            RotateEnemy();
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
        Vector3 move = ((enemyPosition.position - playerPosition.position) / 3f) * Time.deltaTime;

        enemyContoller.Move(-move * enemy.speedEnemy);

    }

    public void RotateEnemy() 
    {
        xRotationLimitEnemy = enemyRotation.rotation.y / playerPosition.position.x;

        //enemyRotation.localRotation = Quaternion.Euler(0, xRotationLimitEnemy, 0);

        enemyRotation.Rotate(new Vector3(0f, xRotationLimitEnemy * Time.deltaTime, 0f));
    }
}
