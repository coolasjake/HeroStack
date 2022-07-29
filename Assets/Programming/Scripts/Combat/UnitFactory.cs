using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Create units from prefabs (or scriptables) on behalf of the GameController, and stores references that scripts can access to interact with units. </summary>
public class UnitFactory : MonoBehaviour
{
    public string enemyDirectory;
    private List<Unit> enemies = new List<Unit>();
    private List<Unit> heroes = new List<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
