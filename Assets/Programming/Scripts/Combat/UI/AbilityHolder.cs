using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AbilityHolder : MonoBehaviour
{
    public Unit testTarget;

    [Header("Ally/Enemy Toggle:")]
    public bool usedForAllies = true;

    private Unit _unit;
    [Header("UI References")]
    public RectTransform rectTransform;
    public Text abilityName;
    public Text abilityDescription;
    public List<EventTrigger> abilitySlots = new List<EventTrigger>();
    private List<AbilityScriptable> _abilities = new List<AbilityScriptable>();
    private int _selectedAbility = -1;

    public virtual void Initialize(Unit unit, Canvas mainCanvas)
    {
        _unit = unit;

        int i = 0;
        foreach (AbilityScriptable ability in unit.data.abilities)
        {
            if (i < 4)
            {
                Debug.Log("Loading abilities, Index = " + i + ", ability name = " + ability.name);
                abilitySlots[i].GetComponent<Image>().sprite = ability.image;
                _abilities.Add(ability);

                int tempIndex = i;
                EventTrigger.Entry pDownEntry = new EventTrigger.Entry();
                pDownEntry.eventID = EventTriggerType.PointerDown;
                pDownEntry.callback.AddListener((data) => { SelectAbility(tempIndex); });
                abilitySlots[i].triggers.Add(pDownEntry);

                if (usedForAllies)
                {
                    EventTrigger.Entry dragEntry = new EventTrigger.Entry();
                    dragEntry.eventID = EventTriggerType.BeginDrag;
                    dragEntry.callback.AddListener((data) => { CreateStackAbility(tempIndex); });
                    abilitySlots[i].triggers.Add(dragEntry);
                }
            }
            ++i;
        }

        SelectAbility(0);

        rectTransform.SetParent(mainCanvas.transform);
    }

    public void SelectAbility(int index)
    {
        if (_abilities.Count > index)
        {
            _selectedAbility = index;
            abilityName.text = _abilities[index].name;
            abilityDescription.text = _abilities[index].GenerateText();
        }
    }

    public void CreateStackAbility(int index)
    {
        if (_abilities.Count > index)
        {
            StackedAbility SA = new StackedAbility();
            SA.ability = _abilities[index];
            SA.caster = _unit;
            CombatController.singleton.HoldAbility(SA);
        }
    }

    public void TestExecute(int index)
    {
        Debug.Log("Executing index: " + index);
        if (_abilities.Count > index)
        {
            Debug.Log("AbilityName = " + _abilities[index].name);
            _abilities[index].Execute(_unit, testTarget);
        }
    }
}
