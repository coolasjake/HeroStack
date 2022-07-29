using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitName", menuName = "GameData/Unit", order = 1)]
public class UnitScriptable : ScriptableObject
{
    //Filename is used as unit name in-game.

    [Header("Gameplay")]
    public int health = 1;
    public List<Ability> abilities;

    [Header("Assets")]
    public Sprite image;
    //Sounds
}
