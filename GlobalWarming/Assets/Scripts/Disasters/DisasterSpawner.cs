using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;

public class DisasterSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] disasters;
    HexMap<Environment> hexMap = null;

    private void Start()
    {
        Debug.Assert(disasters.Length > 0);
        foreach (GameObject d in disasters)
        {
            Debug.Assert(d != null);
        }

        Debug.Assert(hexMap != null);
    }

    public void InitHexMap(HexMap<Environment> map)
    {
        this.hexMap = map;
    }

    public void SpawnDisaster(Vector3 spawnPosition)
    {
        int i = Random.Range(0, disasters.Length);
        GameObject instance = Instantiate(disasters[i], spawnPosition, Quaternion.identity, transform);
        Disaster disaster = instance.GetComponent<Disaster>();
        disaster.InitMap(hexMap);
    }
}
