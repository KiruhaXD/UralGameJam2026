 using UnityEngine;

public class SpawnEffectsManager : MonoBehaviour
{

    /// <summary>
    /// FIRST wave - ice effect,
    /// SECOND wave - shock effect,
    /// THIRD wave - fire effect,
    /// </summary>
    [SerializeField] RectTransform[] enemysEffects;

    [SerializeField] ChoiseEffectController choiseEffectController;

    [SerializeField] Transform childSpawnPointEffectPosition;

    [SerializeField] Transform parentSpawnEffectPosition;

    //[SerializeField] ParticleSystem[] spawnEffects;

    public void SpawnEffectIce() 
    {
        enemysEffects[0].position = childSpawnPointEffectPosition.position;

        enemysEffects[0].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[0];

        if (choiseEffectController.isPickUpEffectIce == true) 
        {
            enemysEffects[0].gameObject.SetActive(false);

            childSpawnPointEffectPosition.parent = parentSpawnEffectPosition;

            childSpawnPointEffectPosition.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

    public void SpawnEffectShock() 
    {
        enemysEffects[1].position = childSpawnPointEffectPosition.position;

        enemysEffects[1].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[1];

        if (choiseEffectController.isPickUpEffectShock == true)
        {
            enemysEffects[1].gameObject.SetActive(false);

            childSpawnPointEffectPosition.parent = parentSpawnEffectPosition;

            childSpawnPointEffectPosition.localPosition = new Vector3(0f, 0f, 0f);
        }

    }

    public void SpawnEffectFire() 
    {
        enemysEffects[2].position = childSpawnPointEffectPosition.position;

        enemysEffects[2].gameObject.SetActive(true);

        childSpawnPointEffectPosition.parent = enemysEffects[2];

        if (choiseEffectController.isPickUpEffectFire == true)
        {
            enemysEffects[2].gameObject.SetActive(false);

            childSpawnPointEffectPosition.parent = parentSpawnEffectPosition;

            childSpawnPointEffectPosition.localPosition = new Vector3(0f, 0f, 0f);
        }

    } 
}
