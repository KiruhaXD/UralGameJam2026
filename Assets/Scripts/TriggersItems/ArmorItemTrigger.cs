using UnityEngine;

public class ArmorItemTrigger : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] BrotherRobotHealth brotherRobotHealth;

    [SerializeField] float countIncrementArmor = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth.sliderArmor.value < 50)
            {
                playerHealth.fillSliderArmor.gameObject.SetActive(true);

                playerHealth.sliderArmor.value += countIncrementArmor;
                this.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("BrotherRobot"))
        {
            if (brotherRobotHealth.sliderArmor.value < 50)
            {
                brotherRobotHealth.fillSliderArmor.gameObject.SetActive(true);

                brotherRobotHealth.sliderArmor.value += countIncrementArmor;
                this.gameObject.SetActive(false);
            }
        }
    }
}
