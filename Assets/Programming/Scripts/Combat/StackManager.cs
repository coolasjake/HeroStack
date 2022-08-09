using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Store which abilities have been added to a stack and sort them by speed. </summary>
public class StackManager : MonoBehaviour
{
    private List<StackedAbility> stack = new List<StackedAbility>();

    public void AddAbilityToStack(StackedAbility ability)
    {
        stack.Add(ability);
    }

    public void RemoveAbilitiesByUnit(Unit caster)
    {
        for (int i = 0; i < stack.Count; ++i)
        {
            if (stack[i].caster == caster)
            {
                Destroy(stack[i].gameObject);
                stack.RemoveAt(i);
                --i;
            }
        }
    }

    public void ExecuteStack()
    {
        foreach (StackedAbility SA in stack)
        {
            SA.Execute();
        }
    }

    private void SortAndArrangeStack()
    {
        stack.Sort((X, Y) => X.ability.speed.CompareTo(Y.ability.speed));

        //Place abilities in scene based on order
    }
}