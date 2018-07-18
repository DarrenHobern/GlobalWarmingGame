using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;


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

    private HexMap<Environment> hexMap;
    [SerializeField] private int radius = 0;
    public int Radius
    {
        get
        {
            return this.radius;
        }
        private set
        {
            this.radius = value;
        }
    }

    [SerializeField] private int strength = 1;
    public int Strength
    {
        get
        {
            return this.strength;
        }
        private set
        {
            this.strength = value;
        }
    }

    public HexPosition Position { get; private set; }

    private void Start()
    {
        Position = GetComponent<HexPosition>();
    }
    private void Update()
    {

        DamageAffectedTiles();
    }

    /// <summary>
    /// Initialise the map, this needs to be done immediately after instantiation.
    /// </summary>
    /// <param name="map"></param>
    public void InitMap(HexMap<Environment> map)
    {
        this.hexMap = map;
        if (Position == null)
        {
            Position = GetComponent<HexPosition>();
        }
        Position.Init(hexMap);
    }


    /// <summary>
    /// Damages the tiles the disaster is currently on.
    /// </summary>
    private void DamageAffectedTiles()
    {
        if (!Position.CursorIsOnMap) return;

        // get all the affected tiles
        List<Vector3Int> affectedTiles = hexMap.GetTilePositions.Disc(Position.TileCoord, Radius, true);
        foreach (Vector3Int tilePos in affectedTiles)
        {
            // get the environment type
            print(hexMap.Tiles[hexMap.TileIndexByPosition[tilePos]].Data.GetEnvironmentStats());
            // deal damage to the populations and tile
            
        }
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
