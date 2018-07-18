using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;

/// <summary>
/// TODO make strenght-weakness table so picking a strength automatically indicates its weaknesses.
///      Also disallow picking clashing elements... maybe
/// </summary>
//[System.Serializable]
//public class Element
//{
//    [Header("Element Type")]
//    public bool fire;
//    public bool water;
//    public bool earth;
//    public bool air;
//    public bool ice;
//    public bool disease;
//    public bool electricity;

//}

public class Disaster : MonoBehaviour {

    protected HexMap hexMap;
    public HexPosition Position { get; private set; }
    public int Strength { get; private set; }
    public int Radius { get; private set; }

    private void Start()
    {
        
    }

    /// <summary>
    /// Initialise the map, this needs to be done immediately after instantiation.
    /// </summary>
    /// <param name="map"></param>
    public void InitMap(HexMap map)
    {
        hexMap = map;
        Position.Init(hexMap);
    }


    /// <summary>
    /// Damages the tiles the disaster is currently on.
    /// </summary>
    private void DamageAffectedTiles()
    {
        // get all the affected tiles
        // get the tile the diaster is on from the hexmap and hexposition,
        // get the environment type
        // deal damage to the populations and tile

    }

    /// <summary>
    /// Damages this disaster, reducing its strength by amount.
    /// If the strength of the disaster is reduced to 0 the diaster is destroyed.
    /// TODO add animation/sfx
    /// </summary>
    /// <param name="amount">The amount to reduce the strength of the disaster</param>
    public void DamageDisaster(int amount)
    {
        Strength -= amount;
        if (Strength <= 0)
        {
            Dissipate();
        }
    }

    /// <summary>
    /// Removes the disaster from the game.
    /// TODO add animations/sfx here
    /// </summary>
    public void Dissipate()
    {
        Destroy(gameObject);
    }
}
