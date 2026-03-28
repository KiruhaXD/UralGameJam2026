using UnityEngine;

public class BrotherRobotController : MonoBehaviour
{
    [SerializeField] AttackRangeBrother attackRangeBrother;

    [SerializeField] MenuPause menuPause;

    [Header("Audio")]
    [SerializeField] AudioSource audioRun;

    [Header("Animator")]
    public Animator brotherAnimator;

    [Header("Settings")]
    [SerializeField] float speedRun = 6f;

    [Header("Brother Character Contoller")]
    [SerializeField] CharacterController brotherCharacterController;

    [Header("Brother Rotation")]
    [SerializeField] Transform brotherRotation;

    [Header("Follow Point to Player")]
    [SerializeField] Transform followPointPlayer;

    [Header("Target")]
    [SerializeField] Transform targetPosition;

    public float horizontalDirectional;
    public float verticalDirectional;

    Vector3 moveDirectional;

    private void Update()
    {
        if (menuPause.countPressKeyEscape == 1)
        {
            horizontalDirectional = 0;
            verticalDirectional = 0;
        }

        else if(attackRangeBrother.isPunch == false)
        {
            Run();

            FollowToPlayerPoint();
        }

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

            if (audioRun.isPlaying) return;
            audioRun.Play();
        }
        else
        {
            brotherAnimator.SetBool("isRunningKeyboardInput", false);
            audioRun.Stop();
        }


    }

    public void FollowToPlayerPoint() 
    {
        Vector3 moveToFollowPoint = (followPointPlayer.position - transform.position) / 2f;

        brotherCharacterController.Move(moveToFollowPoint * speedRun * Time.deltaTime);

        RotateToSideDirectionForward();

        if (audioRun.isPlaying) return;
        audioRun.PlayDelayed(0.1f);
    }

    public void RotateToSideDirectionForward() 
    {
        brotherRotation.LookAt(targetPosition.position);
    }


}
