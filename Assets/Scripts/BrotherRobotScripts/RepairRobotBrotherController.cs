using System.Collections;
using Assets.Scripts.PlayerScripts;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class RepairRobotBrotherController : MonoBehaviour, IInteract
{
    [Header("Audio")]
    [SerializeField] AudioSource audioRepair;

    [Header("Border Collider")]
    [SerializeField] GameObject border;

    [Header("Effects")]
    [SerializeField] ParticleSystem fixEffect;

    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraController cameraController;
    [SerializeField] MenuPause menuPause;

    [Header("Outline")]
    [SerializeField] Outline[] outlines;

    [Header("Animator")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator brotherAnimator;

    [Header("UI")]
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;
    [SerializeField] GameObject fixButtons;
    [SerializeField] GameObject barBrother;
    [SerializeField] Image imageEvent;

    [Header("Player Camera")]
    [SerializeField] CinemachineCamera playerCamera;

    [Header("Camera Check Broken Robot")]
    [SerializeField] CinemachineCamera cinemachineCameraCheckBrokenRobot;

    public int isHappenPressToggle = 0;

    [Header("Charge Broken Robot")]
    [SerializeField] GameObject chargeBrokenRobot;

    [Header("Settings")]
    [SerializeField] float timeForShowNextModelRobot = 3f;

    public bool isCheckBrokenRobot = false;
    public bool isSwitchToPlayerCamera = false;

    private void Awake()
    {
        brotherAnimator.enabled = false;
    }

    private void Update()
    {
        if (isHappenPressToggle == 6) // enable six toggle (fix all part in broken robot)                              
        {
            EnablePlayerCamera();

            StartCoroutine(ShowRobotForCharge());
        }
    }

    public void Interact() 
    {
        playerAnimator.SetBool("isRunningKeyboardInput", false);
        playerAnimator.SetBool("isRunningMouseInput", false);

        imageInteract.gameObject.SetActive(false);

        PlayerInteraction.isActiveRay = false;

        imageEvent.gameObject.SetActive(false);
        border.gameObject.SetActive(false);

        EnableCameraCheckBrokenRobot();
    }

    public void Description() => textInteract.text = "CHECK";
    

    private void EnableCameraCheckBrokenRobot() 
    {
        playerCamera.enabled = false;
        cinemachineCameraCheckBrokenRobot.enabled = true;

        DisableScripts();

        menuPause.ShowCursor();

        imageInteract.gameObject.SetActive(false);

        fixButtons.SetActive(true);

        barBrother.gameObject.SetActive(false);

        isCheckBrokenRobot = true;
    }

    private void EnablePlayerCamera() 
    {
        PlayerInteraction.isActiveRay = true;

        playerCamera.enabled = true;
        cinemachineCameraCheckBrokenRobot.enabled = false;

        DisableScripts();

        playerAnimator.SetBool("isFix", true);

        for (int i = 0; i < outlines.Length; i++)
            outlines[i].enabled = false;

        menuPause.MenuPauseActive();

        fixEffect.gameObject.SetActive(true);

        if (audioRepair.isPlaying) return;
        audioRepair.Play();

        fixButtons.SetActive(false);

        barBrother.gameObject.SetActive(true);

        isSwitchToPlayerCamera = true;
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

        fixEffect.gameObject.SetActive(false);

        audioRepair.Stop();

        playerAnimator.SetBool("isFix", false);
    }
}
