﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject tileMarker;
    [SerializeField] Collider cursorCollider;

    private GameController gameController;
    private HexMap<Environment> hexMap;
    private HexPosition hexPosition;
    private Vector3Int playerTilePosition;
    private bool controlEnabled = true;
    private bool channelling = false;
    private Targetable target;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
        hexMap = gameController.FindPlayerMap(transform.position);
        hexPosition = GetComponentInChildren<HexPosition>();
        hexPosition.Init(hexMap);

    }
	
	// Update is called once per frame
	void Update () {
        if (controlEnabled)
        {
            ProcessMovement();
            //ProcessCamera();
            ProcessActions();
        }
        if (channelling)
        {
            ProcessChannel();  // TODO change this to take the stats of the player
        }
	}

    private void ProcessMovement()
    {
        float xThrow = Input.GetAxis("HorizontalMove");
        float yThrow = Input.GetAxis("VerticalMove");

        // Only do things if there is an input
        if (Mathf.Abs(xThrow) > Mathf.Epsilon || Mathf.Abs(yThrow) > Mathf.Epsilon)
        {
            // If you move while channelling then cancel the channel
            if (channelling)
            {
                channelling = false;
            }

            float xOffset = xThrow * moveSpeed * Time.deltaTime;
            float yOffset = yThrow * moveSpeed * Time.deltaTime;

            Vector3 movementVector = new Vector3(xOffset, 0f, yOffset);
            transform.Translate(movementVector, Space.World);
            transform.rotation = Quaternion.LookRotation(movementVector.normalized);
        }

        tileMarker.transform.position = hexPosition.GetRealPosition();

    }

    private void ProcessCamera()
    {
        float horizontalThrow = Input.GetAxis("HorizontalLook");
        float verticalThrow = Input.GetAxis("VerticalLook");

        // TODO camera movement
    }

    private void ProcessActions()
    {
        bool confirmButton = Input.GetButtonDown("ConfirmButton"); // defaults X  || A
        bool cancelButton = Input.GetButtonDown("CancelButton");  // default O    || B
        bool actionButton = Input.GetButtonDown("ActionButton");  // default Sqr  || X
        float menuNavButton = Input.GetAxisRaw("MenuNavButton");  // default R1L1 || RBLB // float so we can use +- values for left and right. 


        if (confirmButton)
        {
            if (hexPosition.CursorIsOnMap)
            {
                Tile<Environment> t = hexMap.TilesByPosition[playerTilePosition]; // select the tile the player is looking at
                print(t.Data.GetEnvironmentStats());
            }
        }
        if (actionButton)
        {
            if (target != null)
            {
                channelling = true;
            }
        }
    }

    private void ProcessChannel()
    {
        if (target == null) { return; }

        target.Channel(1f);
        // TODO any visuals on the player associated with channelling
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target != null) { return; }
        if(other.CompareTag("Targetable"))
        {
            try
            {
                target = other.GetComponent<Targetable>();
                print("Aquiring target: " + target.name);

            } catch
            {
                target = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == target)
        {
            print("Losing target: " + target.name);
            target = null;
        }            
    }
}
