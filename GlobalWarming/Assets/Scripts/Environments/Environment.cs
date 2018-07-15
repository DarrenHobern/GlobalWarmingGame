using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileStatus
{
    OPTIMAL,
    FUNCTIONAL,
    DAMAGED,
    DESTROYED
}

public enum EnvironmentType
{
    URBAN,
    RURAL,
    WILDERNESS
}

public class Environment : MonoBehaviour {

    Dictionary<Element, float> ElemResistance;
    [SerializeField] int population;
    [SerializeField] string regionName;
    [SerializeField] int health;
    [SerializeField] EnvironmentType type = EnvironmentType.WILDERNESS;
    private TileStatus status = TileStatus.OPTIMAL;

    public string GetEnvironmentType()
    {
        return type.ToString();
    }
}
