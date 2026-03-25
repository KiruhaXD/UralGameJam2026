using UnityEngine;

public class SpawnEffectsManager : MonoBehaviour
{

    /// <summary>
    /// FIRST wave - ice effect,
    /// SECOND wave - shock effect,
    /// THIRD wave - fire effect,
    /// </summary>
    [SerializeField] Transform[] enemysEffects;

    [SerializeField] ChoiseEffectController choiseEffectController;

    [SerializeField] Transform childSpawnPointEffectPosition;

    [SerializeField] Transform parentSpawnEffectPosition;

    //[SerializeField] ParticleSystem[] spawnEffects;

    public void SpawnEffectIce() 
    {
        enemysEffects[0].transform.position = childSpawnPointEffectPosition.position;

        enemysEffects[0].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[0].transform;

        if (choiseEffectController.isPickUpEffectIce == true) 
        {
            //spawnEffects[0].Stop();
            enemysEffects[0].gameObject.SetActive(false);
        }

    }

    public void SpawnEffectShock() 
    {
        enemysEffects[1].transform.position = childSpawnPointEffectPosition.position;

        enemysEffects[1].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[1].transform;

        if (choiseEffectController.isPickUpEffectShock == true) 
        {
            //spawnEffects[1].Stop();
            enemysEffects[1].gameObject.SetActive(false);

        }

    }

    public void SpawnEffectFire() 
    {
        enemysEffects[2].transform.position = childSpawnPointEffectPosition.position;

        enemysEffects[2].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[2].transform;

        if (choiseEffectController.isPickUpEffectFire == true) 
        {
            //spawnEffects[2].Stop();
            enemysEffects[2].gameObject.SetActive(false);
        }

    } 
}
