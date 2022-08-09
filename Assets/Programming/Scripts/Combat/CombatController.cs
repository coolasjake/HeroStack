using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Instigates all elements of combat, including creating the managers, giving them commands and controlling combat turns.  </summary>
public class CombatController : MonoBehaviour
{
    public static CombatController singleton;

    public UnitScriptable allyTestData;
    public UnitScriptable enemyTestData;

    //Only public for testing - managers should use or be resources and be instantiated.
    public UnitFactory _unitFactory;
    public StackManager _stackManager;
    public UIManager _UIManager;

    public StackedAbility heldAbility;

    void Awake()
    {
        if (singleton != null)
            Debug.LogError("Multiple CombatControllers");

        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _unitFactory.FabricateAlly(allyTestData, _UIManager);
        _unitFactory.FabricateAlly(allyTestData, _UIManager);
        _unitFactory.FabricateAlly(allyTestData, _UIManager);

        _unitFactory.FabricateEnemy(enemyTestData, _UIManager);
        _unitFactory.FabricateEnemy(enemyTestData, _UIManager);
        _unitFactory.FabricateEnemy(enemyTestData, _UIManager);
    }

    public void HoldAbility(StackedAbility SA)
    {
        heldAbility = SA;
        Debug.Log("Now holding ability: " + SA.ability.name);
    }
}
