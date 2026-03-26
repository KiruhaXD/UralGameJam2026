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

        childSpawnPointEffectPosition.parent = enemysEffects[0];

        if (choiseEffectController.isPickUpEffectIce == true) 
        {
            enemysEffects[0].gameObject.SetActive(false);

            childSpawnPointEffectPosition.parent = parentSpawnEffectPosition;
        }
    }

    public void SpawnEffectShock() 
    {
        enemysEffects[1].transform.position = childSpawnPointEffectPosition.position;

        enemysEffects[1].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[1];

        if (choiseEffectController.isPickUpEffectShock == true)
        {
            enemysEffects[1].gameObject.SetActive(false);

            childSpawnPointEffectPosition.parent = parentSpawnEffectPosition;

            //childSpawnPointEffectPosition.position = parentSpawnEffectPosition.position;
        }

    }

    public void SpawnEffectFire() 
    {
        enemysEffects[2].transform.position = childSpawnPointEffectPosition.position;

        enemysEffects[2].gameObject.SetActive(true);

        //childSpawnPointEffectPosition.parent = enemysEffectsCanvas[2];

        if (choiseEffectController.isPickUpEffectFire == true)
        {
            enemysEffects[2].gameObject.SetActive(false);

            //childSpawnPointEffectPosition.parent = parentSpawnEffectPosition;

            //childSpawnPointEffectPosition.position = parentSpawnEffectPosition.position;
        }

    } 
}
