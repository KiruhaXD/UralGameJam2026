using UnityEngine;

public class ChoiseEffectAttackBrother : ChoiseEffectAttack
{
    public string currentNamePerson;

    private void Awake()
    {
        currentNamePerson = this.name;
    }
}
