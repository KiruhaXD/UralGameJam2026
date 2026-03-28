using UnityEngine;
using UnityEngine.UI;

public class FixButtonRobot : MonoBehaviour
{
    [SerializeField] RepairRobotBrotherController repairRobotBrotherController;

    [Header("UI")]
    [SerializeField] Toggle currentToggle;

    [Header("Outline")]
    [SerializeField] Outline outline;

    [SerializeField] Button currentButton;

    public void FixPartClickBtn() 
    {
        switch (currentToggle.name)
        {
            case "Toggle (FixHead)":
            case "Toggle (FixBody)":
            case "Toggle (FixLeftArm)":
            case "Toggle (FixRightArm)":
            case "Toggle (FixLeftLeg)":
            case "Toggle (FixRightLeg)":
                currentToggle.isOn = true;
                currentButton.interactable = false;
                break;
        }

        repairRobotBrotherController.isHappenPressToggle++;
    }

    public void MouseEnter() => outline.enabled = true;

    public void MouseExit() => outline.enabled = false;


}
