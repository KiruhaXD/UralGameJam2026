using UnityEngine;

public class SpawnEffects : MonoBehaviour
{
    [Header("First Wave")]
    [SerializeField] EnemyHealth[] enemysHealthFirstWave;

    [Header("Second Wave")]
    [SerializeField] EnemyHealth[] enemysHealthSecondWave;

    [Header("Third Wave")]
    [SerializeField] EnemyHealth[] enemysHealthThirdWave;

    [SerializeField] Transform[] enemysEffects;

    private void Update()
    {
        
    }
}
