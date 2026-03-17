using UnityEngine;

enum EnemyType 
{
    AttackEnemy,
    BossEnemy
}

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyType enemyType = EnemyType.AttackEnemy;

    public float speedEnemy = 0.2f;
}
