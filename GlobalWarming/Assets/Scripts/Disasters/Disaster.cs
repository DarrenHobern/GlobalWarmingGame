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

[RequireComponent(typeof(Collider))]
public class Disaster : Targetable {

    public HexPosition Position { get; private set; }
    [SerializeField] private int radius = 0;
    [SerializeField] private int strength = 1;
    [SerializeField] private int health = 40;
    public int Health { get; private set; }

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

    private HexMap<Environment> hexMap;
    private Collider interactableZone;


    private void Start()
    {
        Position = GetComponent<HexPosition>();
        interactableZone = GetComponent<Collider>();
        Debug.Assert(interactableZone.isTrigger);
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
            Environment tileEnv = hexMap.Tiles[hexMap.TileIndexByPosition[tilePos]].Data;
            // deal damage to the populations and tile
            tileEnv.DealDamage(strength);
            //print(tileEnv.GetEnvironmentStats());
        }
    }

    public override void Channel(float power)
    {
        // visual updates, sfx, etc
        // weaken the strength of the disaster, for a tornado it slows down
        // earthquake it has less/weaker aftershocks
        // fire weaker/spreadslower
        // flood weaker/slower
        // 
        channelTime += power;
        if (channelTime >= channelDuration)
        {
            Dissipate();
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
        health -= amount;
        if (health <= 0)
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
