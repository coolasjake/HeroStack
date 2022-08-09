using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityName", menuName = "GameData/Ability/Attack", order = 2)]
public class Ab_Attack : AbilityScriptable
{
    public int damage = 1;

    public override string GenerateText()
    {
        if (adaptableText)
        {
            string[] splitText = text.Split('#');
            if (splitText.Length == 2)
                return splitText[0] + "<color=#ff0000>" + damage.ToString() + "</color>" + splitText[1];
        }

        return text;
    }

    public override void Execute(Unit owner, Unit target)
    {
        //owner. play attack animation/sfx()
        owner.AttackTarget(target, damage);
    }
}

