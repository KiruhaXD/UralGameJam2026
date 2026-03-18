using UnityEngine;
using UnityEngine.AI;

enum EnemyType 
{
    AttackEnemy,
    BossEnemy
}

public class Enemy : MonoBehaviour
{
    //[SerializeField] EnemyType enemyType = EnemyType.AttackEnemy;

    [Header("Settings")]
    public float speedEnemy = 0.2f;

    /*[Header("Nav Mesh Agent")]
    [SerializeField] NavMeshAgent currentAgent;

    [Header("Player Position")]
    [SerializeField] Transform playerPosition;

    public void EnemyRay() 
    {
        NavMeshHit navMeshHit;

        if (currentAgent.Raycast(playerPosition.position, out navMeshHit)) 
        {
            if (navMeshHit.position == playerPosition.position) 
            {
                currentAgent.Move(playerPosition.position * speedEnemy);
            }
        }
    }
    */
}
