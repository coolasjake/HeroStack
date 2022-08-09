using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "AbilityName", menuName = "GameData/Ability", order = 2)]
public abstract class AbilityScriptable : ScriptableObject
{
    [Header("Gameplay")]
    [Tooltip("Smaller numbers are faster. Should be in 1-10 range, but any number including negatives will work.")]
    public int speed = 5;
    public bool adaptableText = false;
    public string text = "Do Nothing.";

    [Header("Assets")]
    public Sprite image;

    //public GameObject animation;
    public bool canTargetFriendly = false;
    public bool canTargetEnemy = true;

    public virtual string GenerateText()
    {
        return text;
    }

    public virtual void Execute(Unit caster, Unit target)
    {
        if (target != null)
        {
            Debug.Log("Did nothing to " + target.name);
        }
        else
        {
            if (canTargetEnemy && canTargetFriendly)
                Debug.Log("Did nothing to everyone");
            else if (canTargetEnemy)
                Debug.Log("Did nothing to enemies");
            else if(canTargetFriendly)
                Debug.Log("Did nothing to allies");
            else
                Debug.Log("Did nothing to nobody");
        }
    }
}
