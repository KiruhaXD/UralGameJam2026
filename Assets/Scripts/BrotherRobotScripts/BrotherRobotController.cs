using UnityEngine;

public class BrotherRobotController : MonoBehaviour
{
    [Header("Animator")]
    public Animator brotherAnimator;

    [Header("Settings")]
    [SerializeField] float speedRun = 6f;

    [Header("Brother Character Contoller")]
    [SerializeField] CharacterController brotherCharacterController;

    [Header("Brother Rotation")]
    [SerializeField] Transform brotherRotation;

    [Header("Follow Point to Player")]
    public Transform followPointPlayer;

    public Transform playerPosition;

    public float horizontalDirectional;
    public float verticalDirectional;

    Vector3 moveDirectional;

    private void Update()
    {
        Run();

        FollowToPlayerPoint();
    }

    private void InputKeyboards()
    {
        horizontalDirectional = Input.GetAxis("Horizontal");
        verticalDirectional = Input.GetAxis("Vertical");
    }

    private void Run()
    {
        InputKeyboards();

        if (horizontalDirectional != 0 || verticalDirectional != 0)
        {
            brotherAnimator.SetBool("isRunningKeyboardInput", true);

            moveDirectional = transform.TransformDirection(new Vector3(horizontalDirectional, 0f, verticalDirectional));

            brotherCharacterController.Move(moveDirectional * speedRun * Time.deltaTime);

            brotherRotation.Rotate(new Vector3(0f, horizontalDirectional, 0f));
        }

        else
            brotherAnimator.SetBool("isRunningKeyboardInput", false);

    }

    public void FollowToPlayerPoint() 
    {
        Vector3 moveToFollowPoint = (followPointPlayer.position - transform.position) / 2f;

        brotherCharacterController.Move(moveToFollowPoint * speedRun * Time.deltaTime);

        //RotateBodyToEnemys();
    }

    /*public void RotateBodyToEnemys() 
    {
        brotherRotation.Rotate(new Vector3(0f, playerPosition.position.x, 0f));
    }*/
}
