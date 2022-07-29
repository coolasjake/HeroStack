using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityName", menuName = "GameData/Ability/Attack", order = 2)]
public class AttackAbility : AbilityScriptable
{
    public int baseDamage = 1;
    private int adjustedDamage = 1;

    public override string GenerateText()
    {
        if (adaptableText)
        {
            string[] splitText = text.Split('#');
            if (splitText.Length == 2)
                return splitText[0] + adjustedDamage.ToString() + splitText[1];
        }

        return text;
    }

    public void damageEnemy(Unit owner, Unit target)
    {
        //owner. play attack animation/sfx()
        //target. take damage (ba
        int newHealth = 1 - baseDamage;
    }
}
