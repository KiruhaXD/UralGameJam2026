using TMPro;
using UnityEngine;
using UnityEngine.UI;

// скрипт отвечающих за зарядку нашего брата робота
public class ChargeRobotBrotherController : MonoBehaviour, IInteract
{
    [Header("UI")]
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;

    [Header("Animator")]
    [SerializeField] Animator playerAnimator;

    public void Interact() 
    {
        playerAnimator.SetBool("isRunningKeyboardInput", false);
        playerAnimator.SetBool("isRunningMouseInput", false);

        PlayerInteraction.hitSomething = false;
        PlayerInteraction.isEnableRay = false;
    }

    public void Description() => textInteract.text = "CHARGE";
}
