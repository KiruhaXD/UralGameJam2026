using Assets.Scripts.PlayerScripts;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class RepairRobotBrotherController : MonoBehaviour, IInteract
{
    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraController cameraController;

    [Header("Outline")]
    [SerializeField] Outline[] outlines;

    [Header("Animator")]
    [SerializeField] Animator playerAnimator;

    [Header("UI")]
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;
    [SerializeField] GameObject fixButtons;

    [Header("Player Camera")]
    [SerializeField] CinemachineCamera playerCamera;

    [Header("Camera Check Broken Robot")]
    [SerializeField] CinemachineCamera cinemachineCameraCheckBrokenRobot;

    public int isHappenPressToggle = 0;

    private void Update()
    {
        if (isHappenPressToggle == 6) // enable six toggle (fix all part in broken robot)
            EnablePlayerCamera();
    }

    public void Interact() 
    {
        playerAnimator.enabled = false;

        PlayerInteraction.hitSomething = false;
        PlayerInteraction.isEnableRay = false;
        EnableCameraCheckBrokenRobot();
    }

    public void Description() 
    {
        textInteract.text = "CHECK";
    }

    private void EnableCameraCheckBrokenRobot() 
    {
        playerCamera.enabled = false;
        cinemachineCameraCheckBrokenRobot.enabled = true;

        DisableScripts();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        imageInteract.gameObject.SetActive(false);

        fixButtons.SetActive(true);
    }

    private void EnablePlayerCamera() 
    {
        playerCamera.enabled = true;
        cinemachineCameraCheckBrokenRobot.enabled = false;

        EnableScripts();

        playerAnimator.enabled = true;

        for (int i = 0; i < outlines.Length; i++)
            outlines[i].enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fixButtons.SetActive(false);
    }

    private void EnableScripts() 
    {
        playerController.enabled = true;
        cameraController.enabled = true;
    }

    private void DisableScripts() 
    {
        playerController.enabled = false;
        cameraController.enabled = false;
    }
}
