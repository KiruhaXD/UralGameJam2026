using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [Header("Parent Object")]
    [SerializeField] Transform enemyParentObject;

    [SerializeField] Transform spawnPointHP, spawnPointArmor;

    [Header("HP_DROP_Prefab")]
    [SerializeField] GameObject hpDropPrefab;
    [Header("ARMOR_DROP_Prefab")]
    [SerializeField] GameObject armorDropPrefab;

    public void Spawn() 
    {
        spawnPointHP.parent = enemyParentObject;
        spawnPointArmor.parent = enemyParentObject;

        hpDropPrefab.transform.position = spawnPointHP.position;
        armorDropPrefab.transform.position = spawnPointArmor.position;

        hpDropPrefab.SetActive(true);
        armorDropPrefab.SetActive(true);
    }
}
