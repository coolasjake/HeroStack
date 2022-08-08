using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityHolder : MonoBehaviour
{
    private Unit _unit;
    public RectTransform rectTransform;
    public Text abilityName;
    public Text abilityDescription;
    public List<Button> AbilitySlots = new List<Button>();
    public List<AbilityScriptable> Abilities = new List<AbilityScriptable>();
    private int _selectedAbility = 0;

    public virtual void Initialize(Unit unit, Canvas mainCanvas)
    {
        _unit = unit;

        int i = 0;
        foreach (AbilityScriptable ability in unit.data.abilities)
        {
            if (i < 4)
            {
                AbilitySlots[i].image.sprite = ability.image;
                Abilities.Add(ability);
            }
            ++i;
        }

        SelectAbility(0);

        rectTransform.SetParent(mainCanvas.transform);
    }

    public void SelectAbility(int index)
    {
        if (Abilities.Count > index)
        {
            abilityName.text = Abilities[index].name;
            abilityDescription.text = Abilities[index].GenerateText();
        }
    }
}
