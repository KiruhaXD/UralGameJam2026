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

    [Header("UI")]
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;

    [Header("Player Camera")]
    [SerializeField] CinemachineCamera playerCamera;

    [Header("Camera Check Broken Robot")]
    [SerializeField] CinemachineCamera cinemachineCameraCheckBrokenRobot;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EnablePlayerCamera();
    }

    public void Interact() 
    {
        imageInteract.gameObject.SetActive(false);

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
    }

    private void EnablePlayerCamera() 
    {

        playerCamera.enabled = true;
        cinemachineCameraCheckBrokenRobot.enabled = false;

        EnableScripts();
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
