using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Instigates all elements of combat, including creating the managers, giving them commands and controlling combat turns.  </summary>
public class CombatController : MonoBehaviour
{
    //Only public for testing - managers should use or be resources and be instantiated.
    public UnitFactory _unitFactory;
    public StackManager _stackManager;
    public UIManager _UIManager;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform allyRT = _unitFactory.FabricateAlly();
        _UIManager.PlaceAlly(allyRT);
        allyRT = _unitFactory.FabricateAlly();
        _UIManager.PlaceAlly(allyRT);
        allyRT = _unitFactory.FabricateAlly();
        _UIManager.PlaceAlly(allyRT);

        RectTransform enemyRT = _unitFactory.FabricateEnemy();
        _UIManager.PlaceEnemy(enemyRT);
        enemyRT = _unitFactory.FabricateEnemy();
        _UIManager.PlaceEnemy(enemyRT);
        enemyRT = _unitFactory.FabricateEnemy();
        _UIManager.PlaceEnemy(enemyRT);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
