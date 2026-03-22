using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    [Header("First Wave")]
    [SerializeField] EnemyHealth[] enemysHealthFirstWave;

    [Header("Second Wave")]
    [SerializeField] EnemyHealth[] enemysHealthSecondWave;

    [Header("Third Wave")]
    [SerializeField] EnemyHealth[] enemysHealthThirdWave;

    /// <summary>
    /// FIRST wave - ice effect,
    /// SECOND wave - shock effect,
    /// THIRD wave - fire effect,
    /// </summary>
    [SerializeField] Transform[] enemysEffects;

    private void Update()
    {
        Spawn();
    }

    public void Spawn() 
    {
        for (int i = 0; i < enemysHealthFirstWave.Length; i++)
        {
            if (enemysHealthFirstWave[i].sliderHealth.value == 0)
            {
                enemysEffects[0].gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < enemysHealthSecondWave.Length; i++)
        {
            if (enemysHealthFirstWave[i].sliderHealth.value == 0)
            {
                enemysEffects[1].gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < enemysHealthThirdWave.Length; i++)
        {
            if (enemysHealthFirstWave[i].sliderHealth.value == 0)
            {
                enemysEffects[2].gameObject.SetActive(true);
            }
        }
    }
}
