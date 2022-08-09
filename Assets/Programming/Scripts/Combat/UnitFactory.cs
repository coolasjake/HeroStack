using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Create units from prefabs (or scriptables) on behalf of the GameController, and stores references that scripts can access to interact with units. </summary>
public class UnitFactory : MonoBehaviour
{
    public GameObject testEnemyPre;
    public GameObject testAllyPre;
    public GameObject allyAbilityHolder;
    public GameObject enemyAbilityHolder;

    //public string enemyDirectory;
    private List<Unit> enemies = new List<Unit>();
    private List<Unit> allies = new List<Unit>();

    public void FabricateAlly(UnitScriptable data, UIManager _UIManager)
    {
        GameObject GO = Instantiate(testAllyPre);
        Unit ally = GO.GetComponent<Unit>();
        ally.data = data;
        RectTransform allyRT = GO.GetComponent<RectTransform>();
        allyRT.SetParent(_UIManager.AllySpace);
        allyRT.anchoredPosition = new Vector2(50 + 150 * allies.Count, 0);
        allies.Add(ally);

        AbilityHolder abilityHolder = Instantiate(allyAbilityHolder, allyRT).GetComponent<AbilityHolder>();
        abilityHolder.Initialize(ally, _UIManager.mainCanvas);

        ally.Initialize(abilityHolder);
    }

    public void FabricateEnemy(UnitScriptable data, UIManager _UIManager)
    {
        GameObject GO = Instantiate(testEnemyPre);
        Unit enemy = GO.GetComponent<Unit>();
        enemy.data = data;
        RectTransform enemyRT = GO.GetComponent<RectTransform>();
        enemyRT.SetParent(_UIManager.EnemySpace);
        enemyRT.anchoredPosition = new Vector2(-50 - 150 * enemies.Count, 0);
        enemies.Add(enemy);
        
        AbilityHolder abilityHolder = Instantiate(enemyAbilityHolder, enemyRT).GetComponent<AbilityHolder>();
        abilityHolder.Initialize(enemy, _UIManager.mainCanvas);

        enemy.Initialize(abilityHolder);
    }

    public void CloseAllAbilityHolders()
    {
        foreach (Unit unit in allies)
            unit.CloseAbilityHolder();
        foreach (Unit unit in enemies)
            unit.CloseAbilityHolder();
    }
}
