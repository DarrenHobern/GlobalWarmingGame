using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;

[RequireComponent(typeof(HexPosition))]
public class Tornado : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    
    private Vector3 direction = Vector3.forward;
    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        float xVar = Random.Range(-0.5f, 0.5f);
        float zVar = Random.Range(-0.5f, 0.5f);
        direction = new Vector3(direction.x + xVar, direction.y, direction.z + zVar);
        transform.Translate(direction*moveSpeed*Time.deltaTime);
        // TODO fix this so its not super wonky
        // TODO connect the speed of the tornado to the speed of the particles
    }
}
