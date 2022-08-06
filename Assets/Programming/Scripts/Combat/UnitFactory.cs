using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Create units from prefabs (or scriptables) on behalf of the GameController, and stores references that scripts can access to interact with units. </summary>
public class UnitFactory : MonoBehaviour
{
    public GameObject testEnemyPre;
    public GameObject testAllyPre;

    //public string enemyDirectory;
    private List<Unit> enemies = new List<Unit>();
    private List<Unit> allies = new List<Unit>();

    public RectTransform FabricateAlly()
    {
        GameObject GO = Instantiate(testAllyPre);
        allies.Add(GO.GetComponent<Unit>());
        return GO.GetComponent<RectTransform>();
    }

    public RectTransform FabricateEnemy()
    {
        GameObject GO = Instantiate(testEnemyPre);
        enemies.Add(GO.GetComponent<Unit>());
        return GO.GetComponent<RectTransform>();
    }
}
