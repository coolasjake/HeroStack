using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Instigates all elements of combat, including creating the managers, giving them commands and controlling combat turns.  </summary>
public class CombatController : MonoBehaviour
{
    public UnitScriptable allyTestData;
    public UnitScriptable enemyTestData;

    //Only public for testing - managers should use or be resources and be instantiated.
    public UnitFactory _unitFactory;
    public StackManager _stackManager;
    public UIManager _UIManager;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
