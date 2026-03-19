using UnityEngine;

public class ChoiseEffectAttack : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] ParticleSystem[] particleSystemsAttack;

    public int currentEffect = 0;

    public void EffectsAttack(int currentEffect)
    {
        switch (currentEffect)
        {
            case 0:
                particleSystemsAttack[currentEffect].Play();
                break;

            case 1:
                particleSystemsAttack[currentEffect].Play();
                break;

            case 2:
                particleSystemsAttack[currentEffect].Play();
                break;
        }
    }
}
