using UnityEngine;

public class ChoiseEffectAttack : MonoBehaviour
{
    [Header("Effects")]
    public ParticleSystem[] particleSystemsAttack;

    public int currentEffect = 0;

    public string currentNamePerson;

    private void Awake()
    {
        currentNamePerson = this.name;
    }

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

            case 3:
                particleSystemsAttack[currentEffect].Play();
                break;
        }
    }
}
