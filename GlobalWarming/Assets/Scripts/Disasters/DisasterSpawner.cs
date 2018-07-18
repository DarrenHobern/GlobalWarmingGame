using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;

public class DisasterSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] disasters;
    HexMap hexMap;

    private void Start()
    {
        Debug.Assert(disasters.Length > 0);
        foreach (GameObject d in disasters)
        {
            Debug.Assert(d != null);
        }

        Debug.Assert(hexMap != null);
    }

    public void InitHexMap(HexMap map)
    {
        hexMap = map;
    }

    public void SpawnDisaster(Vector3 spawnPosition)
    {
        int i = Random.Range(0, disasters.Length);
        GameObject disaster = Instantiate(disasters[i], spawnPosition, Quaternion.identity, transform);
        disaster.GetComponent<Disaster>().InitMap(hexMap);
    }
}
