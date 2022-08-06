using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Holds any UI not directly owned by a unit (e.g. end turn button) and manages interaction with them (e.g. disable during animations). </summary>
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform AllySpace;
    [SerializeField]
    private RectTransform EnemySpace;
    [SerializeField]
    private RectTransform StackSpace;

    private List<RectTransform> EnemyCards = new List<RectTransform>();
    private List<RectTransform> AllyCards = new List<RectTransform>();

    public void PlaceEnemy(RectTransform enemyRT)
    {
        enemyRT.SetParent(EnemySpace);
        enemyRT.anchoredPosition = new Vector2(-50 - 150 * EnemyCards.Count, 0);

        EnemyCards.Add(enemyRT);
    }

    public void PlaceAlly(RectTransform allyRT)
    {
        allyRT.SetParent(AllySpace);
        allyRT.anchoredPosition = new Vector2(50 + 150 * AllyCards.Count, 0);

        AllyCards.Add(allyRT);
    }
}
