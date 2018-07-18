using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;

[RequireComponent(typeof(GameHexMapGenerator))]
public class GameController : MonoBehaviour {

    [SerializeField] int numberOfMaps = 1;

    GameHexMapGenerator mapGenerator;
    List<HexMap<Environment>> maps = new List<HexMap<Environment>>();

    DisasterSpawner disasterSpawner;
    private int diasterSpawnInterval = 3;

	// Use this for initialization
	void Start () {
        mapGenerator = GetComponent<GameHexMapGenerator>();
        disasterSpawner = GetComponent<DisasterSpawner>();
        for (int i = 0; i < numberOfMaps; i++)
        {
            maps.Add(mapGenerator.GenerateMap(i*100)); // TODO remove magic number and pick a real offset
        }
        Debug.Assert(maps[0] != null);
        disasterSpawner.InitHexMap(maps[0]); // TODO allow for multiple maps
        disasterSpawner.SpawnDisaster(Vector3.zero);
    
	}

    private void Update()
    {
        // TODO repeatedly spawn disasters
    }

    /// <summary>
    /// Returns the map that the player is on based on their position.
    /// Null if the player is not on a map.
    /// Should be called at the start of the game while the player is over a map.
    /// TODO return closest map if player is not over one.
    /// </summary>
    /// <param name="position"></param>
    /// <returns>The map the player is on</returns>
    public HexMap<Environment> FindPlayerMap(Vector3 position)
    {
        foreach (HexMap<Environment> map in maps)
        {
            if (map.GetTilePosition.IsInputCoordinateOnMap(position))
            {
                return map;
            }
        }

        return null;
    }
}
