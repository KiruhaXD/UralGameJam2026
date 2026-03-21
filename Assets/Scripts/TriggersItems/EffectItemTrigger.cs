using Assets.Scripts.PlayerScripts;
using UnityEngine;

public class EffectItemTrigger : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BrotherRobotController brotherRobotController;
    [SerializeField] CameraController cameraController;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator brotherAnimator;

    [SerializeField] GameObject choiseEffectAttackWindow;

    public string tagCurrentEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("BrotherRobot"))
        {
            choiseEffectAttackWindow.SetActive(true);

            DisableScriptsAndShowCursor();

            this.gameObject.SetActive(false);

            tagCurrentEffect = this.gameObject.tag;
        }
    }

    public void DisableScriptsAndShowCursor() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        playerController.enabled = false;
        brotherRobotController.enabled = false;
        cameraController.enabled = false;
        playerAnimator.enabled = false;
        brotherAnimator.enabled = false;
    }
}
