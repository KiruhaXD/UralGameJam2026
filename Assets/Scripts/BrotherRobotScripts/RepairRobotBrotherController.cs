using System.Collections;
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
    [SerializeField] GameObject barBrother;

    [Header("Player Camera")]
    [SerializeField] CinemachineCamera playerCamera;

    [Header("Camera Check Broken Robot")]
    [SerializeField] CinemachineCamera cinemachineCameraCheckBrokenRobot;

    public int isHappenPressToggle = 0;

    [Header("Charge Broken Robot")]
    [SerializeField] GameObject chargeBrokenRobot;

    [Header("Settings")]
    [SerializeField] float timeForShowNextModelRobot = 3f;

    private void Update()
    {
        if (isHappenPressToggle == 6) // enable six toggle (fix all part in broken robot)                              
        {
            EnablePlayerCamera();
            // create method for call animation (repair) and effects

            StartCoroutine(ShowRobotForCharge());

            // after repair need charge our brother robot
        }
    }

    public void Interact() 
    {
        playerAnimator.SetBool("isRunningKeyboardInput", false);
        playerAnimator.SetBool("isRunningMouseInput", false);

        imageInteract.gameObject.SetActive(false);

        PlayerInteraction.isActiveRay = false;

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

        barBrother.gameObject.SetActive(false);
    }

    private void EnablePlayerCamera() 
    {
        PlayerInteraction.isActiveRay = true;

        playerCamera.enabled = true;
        cinemachineCameraCheckBrokenRobot.enabled = false;

        DisableScripts();

        for (int i = 0; i < outlines.Length; i++)
            outlines[i].enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fixButtons.SetActive(false);

        barBrother.gameObject.SetActive(true);
    }

    private void DisableScripts() 
    {
        playerController.enabled = false;
        cameraController.enabled = false;
    }

    public IEnumerator ShowRobotForCharge() 
    {
        yield return new WaitForSeconds(timeForShowNextModelRobot);

        this.gameObject.SetActive(false); // off current model (repair broken robot)
        chargeBrokenRobot.SetActive(true);
    }
}
