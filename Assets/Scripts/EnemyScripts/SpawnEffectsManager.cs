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

    public void SpawnEffectIce() 
    {
        enemysEffects[0].gameObject.SetActive(true);

        if (choiseEffectController.isPickUpEffectIce == true)
            enemysEffects[0].gameObject.SetActive(false);
    }

    public void SpawnEffectShock() 
    {
        enemysEffects[1].gameObject.SetActive(true);

        if (choiseEffectController.isPickUpEffectShock == true)
            enemysEffects[1].gameObject.SetActive(false);
    }

    public void SpawnEffectFire() 
    {
        enemysEffects[2].gameObject.SetActive(true);

        if(choiseEffectController.isPickUpEffectFire == true)
            enemysEffects[2].gameObject.SetActive(false);
    } 
}
