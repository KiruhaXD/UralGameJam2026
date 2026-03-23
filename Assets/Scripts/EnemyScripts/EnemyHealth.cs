using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider sliderHealth;

    [SerializeField] CheckHitboxTriggerEnemy checkHitboxTriggerEnemy;

    [SerializeField] TimerEndEffect timerEndEffect;

    [SerializeField] ParticleSystem effectFire;

    public float damageFire = 1;

    public int timeFireEffect = 5;

    private void Update()
    {
        // Effect Hit Fire
        if (checkHitboxTriggerEnemy.isTakeHitEffectFire == true) 
        {
            effectFire.Play();

            sliderHealth.value -= damageFire;

            Debug.Log(sliderHealth.value);

            timerEndEffect.StartCoroutine(timerEndEffect.Timer(timeFireEffect));

            if (timeFireEffect == 0) 
            {
                checkHitboxTriggerEnemy.isTakeHitEffectFire = false;
                effectFire.Stop();
            }


        }
    }
}
