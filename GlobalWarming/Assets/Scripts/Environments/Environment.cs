using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileStatus
{
    OPTIMAL = 100,
    FUNCTIONAL = 89,
    DAMAGED = 49,
    DESTROYED = 19
}

public enum EnvironmentType
{
    URBAN,
    RURAL,
    WILDERNESS
}

public class Environment : MonoBehaviour {

    //Dictionary<Element, float> ElemResistance;
    [SerializeField] int humanPopulation = 100; // we have the people of course
    [SerializeField] int floraPopulation = 100; // plants
    [SerializeField] int faunaPopulation = 100; // animals
    [SerializeField] string regionName = "";
    [SerializeField] int maxHealth = 1000;
    [SerializeField] EnvironmentType type = EnvironmentType.WILDERNESS;

    private TileStatus status = TileStatus.OPTIMAL;
    private int health;

    public string GetEnvironmentStats()
    {
        string output = string.Format("Type: {0}\nHuman Pop: {1}\nFlora Pop: {2}\nFauna Pop: {3}\nHealth Status: {4}", type.ToString(),
                                      humanPopulation, floraPopulation, faunaPopulation, status.ToString());
        return output;
    }


    public void DealDamage(int amount)
    {
        health -= amount;
        UpdateStatus();
    }

    private void UpdateStatus()
    {
        float hpPercent = health / maxHealth;
        if(hpPercent < (int)TileStatus.DESTROYED/100)
        {
            status = TileStatus.DESTROYED;
        }
        else if(hpPercent < (int)TileStatus.DAMAGED/100)
        {
            status = TileStatus.DAMAGED;
        }
        else if(hpPercent < (int)TileStatus.FUNCTIONAL/100)
        {
            status = TileStatus.FUNCTIONAL;
        }
        else
        {
            status = TileStatus.OPTIMAL;
        }
    }

}
