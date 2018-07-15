using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;

public class GameHexMapGenerator : MonoBehaviour
{
    [SerializeField] private int mapSize = 10; // the mapSize, can be set in inspector  
    [SerializeField] private GameObject tileMarker = null; // a GameObject we use to show the current mouse position -> create an instance of TileMarker.prefab and reference it in the inspector

    [SerializeField] private List<GameObject> tilePrefabs = null;

    private GameObject[] tileObjects; // this will contain all the GameObjects for visualisation purposes, their array index corresponds with the index of our Tiles

    // TODO move the settings to the GameController
    /// <summary>
    /// Generates a new HexMap of environments, at the given offset
    /// </summary>
    /// <returns>The generated map</returns>
    public HexMap GenerateMap (int offset)
    {
        Debug.Assert(tilePrefabs != null);

        HexMap<Environment> hexMap = new HexMap<Environment>(HexMapBuilder.CreateHexagonalShapedMap(mapSize), null);
        tileObjects = new GameObject[hexMap.TilesByPosition.Count]; //creates an array with the size equal to the number on tiles of the map
        Transform newMap = new GameObject("HexMap_" + offset).transform;  // Make a new folder to put the tiles in
        foreach (var tile in hexMap.Tiles)
        {
            int i = Random.Range(0, tilePrefabs.Count);
            GameObject instance = Instantiate(tilePrefabs[i], newMap);
            tile.Data = instance.GetComponent<Environment>();
            instance.name = instance.name + "_" + tile.Position;
            instance.transform.position = tile.CartesianPosition;
            tileObjects[tile.Index] = instance;
        }

        return hexMap;
    }
}

