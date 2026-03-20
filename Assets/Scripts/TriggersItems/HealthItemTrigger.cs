using UnityEngine;

public class HealthItemTrigger : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] BrotherRobotHealth brotherRobotHealth;

    [SerializeField] float countIncrementHealth = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (playerHealth.sliderHealth.value < 100 && playerHealth.sliderHealth.value != 0) 
            {
                playerHealth.fillSliderHealth.gameObject.SetActive(true);

                playerHealth.sliderHealth.value += countIncrementHealth;
                this.gameObject.SetActive(false);
            }
        }

        if (other.CompareTag("BrotherRobot")) 
        {
            if (brotherRobotHealth.sliderHealth.value < 100 && brotherRobotHealth.sliderHealth.value != 0)
            {
                brotherRobotHealth.fillSliderHealth.gameObject.SetActive(true);

                brotherRobotHealth.sliderHealth.value += countIncrementHealth;
                this.gameObject.SetActive(false);
            }
        }
    }
}
