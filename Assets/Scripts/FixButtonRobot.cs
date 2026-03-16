using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FixButtonRobot : MonoBehaviour
{
    [SerializeField] RepairRobotBrotherController repairRobotBrotherController;

    [Header("UI")]
    [SerializeField] TMP_Text currentText;
    [SerializeField] Toggle currentToggle;

    [Header("Outline")]
    [SerializeField] Outline outline;

    private void OnMouseDown()
    {
        currentToggle.isOn = true;
        repairRobotBrotherController.isHappenPressToggle++;
    }

    private void OnMouseEnter()
    {
        switch (currentText.text) 
        {
            case "FIX HEAD":
            case "FIX BODY":
            case "FIX LEFT ARM":
            case "FIX RIGHT ARM":
            case "FIX LEFT LEG":
            case "FIX RIGHT LEG":
                outline.enabled = true;
                break;
        } 
    }

    private void OnMouseExit()
    {
        switch (currentText.text)
        {
            case "FIX HEAD":
            case "FIX BODY":
            case "FIX LEFT ARM":
            case "FIX RIGHT ARM":
            case "FIX LEFT LEG":
            case "FIX RIGHT LEG":
                outline.enabled = false;
                break;
        }
    }


}
