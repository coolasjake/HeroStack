using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackedAbility : MonoBehaviour
{
    public AbilityScriptable ability;
    public RectTransform card;
    public Unit caster;
    public Unit target;

    public void Initialize(AbilityScriptable Ability, Unit Caster, Unit Target)
    {
        ability = Ability;
        caster = Caster;
        target = Target;
    }

    public void Execute()
    {
        ability.Execute(caster, target);
    }

    public int CompareTo(StackedAbility other)
    {
        if (other == null)
            return 1;

        if (other.ability.speed > ability.speed)
            return -1;
        else if (other.ability.speed < ability.speed)
            return 1;

        return 0;
    }
}
