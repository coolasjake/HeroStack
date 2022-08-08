using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Holds any UI not directly owned by a unit (e.g. end turn button) and manages interaction with them (e.g. disable during animations). </summary>
public class UIManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public RectTransform AllySpace;
    public RectTransform EnemySpace;
    public RectTransform StackSpace;

    private List<RectTransform> EnemyCards = new List<RectTransform>();
    private List<RectTransform> AllyCards = new List<RectTransform>();
}
