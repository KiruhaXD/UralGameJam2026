using Assets.Scripts.PlayerScripts;
using UnityEngine;

public class FollowPointTrigger : MonoBehaviour
{
    [SerializeField] Animator brotherAnimator;

    [SerializeField] PlayerController playerController;
    [SerializeField] BrotherRobotController brotherRobotController;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BrotherRobot") && (playerController.horizontalDirectional == 0 || playerController.verticalDirectional == 0) && 
            (brotherRobotController.horizontalDirectional == 0 || brotherRobotController.verticalDirectional == 0)) 
        {
            brotherAnimator.SetBool("isRunningKeyboardInput", false);
        }
    }*/
}
