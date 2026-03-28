using UnityEngine;

public class ChoiseEffectAttackPlayer : ChoiseEffectAttack
{
    public string currentNamePerson;

    private void Awake()
    {
        currentNamePerson = this.name;
    }
}
