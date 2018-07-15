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
    [SerializeField] int humanPopulation = 100; // we have the people of course
    [SerializeField] int floraPopulation = 100; // plants
    [SerializeField] int faunaPopulation = 100; // animals
    [SerializeField] string regionName;
    [SerializeField] int health;
    [SerializeField] EnvironmentType type = EnvironmentType.WILDERNESS;
    private TileStatus status = TileStatus.OPTIMAL;

    public string GetEnvironmentStats()
    {
        string output = string.Format("Type: {0}\nHuman Pop: {1}\nFlora Pop: {2}\nFauna Pop: {3}\nHealth Status: {4}", type.ToString(),
                                                                                                                 humanPopulation,
                                                                                                                 floraPopulation,
                                                                                                                 faunaPopulation,
                                                                                                                 status.ToString());
        return output;
    }
}
