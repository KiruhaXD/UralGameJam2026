using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RepairRobotBrotherController : MonoBehaviour, IInteract
{
    [SerializeField] TMP_Text textInteract;
    [SerializeField] Image imageInteract;

    public void Interact() 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            imageInteract.gameObject.SetActive(false);
        }

    }

    public void Description() => textInteract.text = "REPAIR";
}
