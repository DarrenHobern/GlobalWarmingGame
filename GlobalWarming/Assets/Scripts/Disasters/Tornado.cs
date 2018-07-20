using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;

[RequireComponent(typeof(HexPosition))]
public class Tornado : MonoBehaviour {

    [SerializeField] float moveSpeed = 1f;
    
    private Vector3 direction = Vector3.forward;
    private ParticleSystem particles;

    private void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        direction = new Vector3(Random.Range(-1, 1), 0f, Random.Range(-1, 1));
    }

    private void Update()
    {
        
        transform.Translate(direction*moveSpeed*Time.deltaTime);
        Debug.DrawLine(transform.position, direction * moveSpeed);
        // TODO connect the speed of the tornado to the speed of the particles
        
    }
}
