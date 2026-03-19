using UnityEngine;

public class EffectAttackEnemyBoss : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] ParticleSystem particleSystemAttack;

    public void EffectsAttack() => particleSystemAttack.Play();
}
