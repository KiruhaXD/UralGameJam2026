using UnityEngine;

public class ShowEnemysWaves : MonoBehaviour
{
    [SerializeField] GameObject firstWave, secondWave, thirdWave, fourthWave;

    [SerializeField] SpawnEffectsManager spawnEffectsManager;

    [Header("First Wave")]
    [SerializeField] CheckHitboxTriggerEnemy[] enemysFirstWave;

    [Header("Second Wave")]
    [SerializeField] CheckHitboxTriggerEnemy[] enemysSecondWave;

    [Header("Third Wave")]
    [SerializeField] CheckHitboxTriggerEnemy[] enemysThirdWave;

    [Header("Fourth Wave")]
    [SerializeField] CheckHitboxTriggerEnemy[] enemysFourthWave;
    [SerializeField] CheckHitboxTriggerEnemy enemyBossFourthWave;

    [Header("End Game Trigger")]
    [SerializeField] GameObject endGameTrigger;

    private void Update()
    {
        for (int i = 0; i < enemysFirstWave.Length; i++)
        {
            if (enemysFirstWave[0].isDeadEnemy == true && enemysFirstWave[1].isDeadEnemy == true &&
                enemysFirstWave[2].isDeadEnemy == true && enemysFirstWave[3].isDeadEnemy == true) 
            {
                spawnEffectsManager.SpawnEffectIce();
                ShowSecondWave();
            }
        }

        for (int i = 0; i < enemysSecondWave.Length; i++) 
        {
            if (enemysSecondWave[0].isDeadEnemy == true && enemysSecondWave[1].isDeadEnemy == true &&
                enemysSecondWave[2].isDeadEnemy == true && enemysSecondWave[3].isDeadEnemy == true)
            {
                spawnEffectsManager.SpawnEffectShock();
                ShowThirdWave();
            }
        }

        for (int i = 0; i < enemysThirdWave.Length; i++)
        {
            if (enemysThirdWave[0].isDeadEnemy == true && enemysThirdWave[1].isDeadEnemy == true &&
                enemysThirdWave[2].isDeadEnemy == true && enemysThirdWave[3].isDeadEnemy == true)
            {
                spawnEffectsManager.SpawnEffectFire();
                ShowFourthWave();
            }
            
        }

        for (int i = 0; i < enemysFourthWave.Length; i++)
        {
            if (enemysFourthWave[0].isDeadEnemy == true && enemysFourthWave[1].isDeadEnemy == true &&
                enemysFourthWave[2].isDeadEnemy == true && enemysFourthWave[3].isDeadEnemy == true && enemyBossFourthWave.isDeadEnemy == true)
            {
                endGameTrigger.SetActive(true);
                // Конец игры!
            }

        }
    }

    public void ShowFirstWave() => firstWave.SetActive(true); // включать после починки собрата

    public void ShowSecondWave() => secondWave.SetActive(true); // включать после победы над первой волной врагов

    public void ShowThirdWave() => thirdWave.SetActive(true); // включать после победы над второй волной врагов

    public void ShowFourthWave() => fourthWave.SetActive(true); // включать после победы над третьей волной врагов

}
