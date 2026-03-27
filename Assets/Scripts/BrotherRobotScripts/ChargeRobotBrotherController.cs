using System.Collections;
using Assets.Scripts.PlayerScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// скрипт отвечающих за зарядку нашего брата робота
public class ChargeRobotBrotherController : MonoBehaviour, IInteract
{
    [Header("Audio")]
    [SerializeField] AudioSource audioRepair;

    [Header("Battery Prefab")]
    [SerializeField] GameObject batteryPlayer;

    [Header("Effects")]
    [SerializeField] ParticleSystem fixEffect;

    [Header("References")]
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraController cameraController;
    [SerializeField] ShowEnemysWaves waves;

    [Header("UI")]
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;
    [SerializeField] Slider sliderBrotherHealth;

    [Header("Animator")]
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator brotherAnimator;

    [Header("Normal Charged Robot")]
    [SerializeField] GameObject normalChargedRobot;

    [Header("Settings")]
    [SerializeField] float timeForShowNextModelRobot = 3f;

    // происходит анимация починки
    // заетм происходят эффект телепорта батареи
    // и затем он должен как бы включиться и встать

    private void Awake()
    {
        brotherAnimator.enabled = false;
    }

    public void Interact() 
    {
        playerAnimator.SetBool("isRunningKeyboardInput", false);
        playerAnimator.SetBool("isRunningMouseInput", false);

        playerAnimator.SetBool("isFix", true);

        imageInteract.gameObject.SetActive(false);

        PlayerInteraction.isActiveRay = false;

        fixEffect.gameObject.SetActive(true);

        audioRepair.Play();

        StartCoroutine(ShowNormalRobot());
    }


    public void Description() => textInteract.text = "CHARGE";

    public IEnumerator ShowNormalRobot() 
    {
        yield return new WaitForSeconds(timeForShowNextModelRobot);

        fixEffect.gameObject.SetActive(false);

        brotherAnimator.enabled = true;

        audioRepair.Stop();

        this.gameObject.SetActive(false);
        normalChargedRobot.SetActive(true);

        sliderBrotherHealth.gameObject.SetActive(true);

        playerAnimator.SetBool("isFix", false);

        batteryPlayer.SetActive(false);

        EnableScripts();

        waves.ShowFirstWave();
    }

    private void EnableScripts()
    {
        playerController.enabled = true;
        cameraController.enabled = true;
    }
}
