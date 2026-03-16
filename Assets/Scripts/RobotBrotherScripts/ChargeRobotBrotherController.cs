using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChargeRobotBrotherController : MonoBehaviour, IInteract
{
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;

    public void Interact() 
    {
        imageInteract.gameObject.SetActive(false);
    }

    public void Description() => textInteract.text = "CHARGE";
}
