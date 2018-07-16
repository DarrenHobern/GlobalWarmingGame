using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wunderwunsch.HexMapLibrary;
using Wunderwunsch.HexMapLibrary.Generic;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] GameObject tileMarker;

    private GameController gameController;
    private HexMap<Environment> hexMap;
    private HexPosition hexPlayer;
    private Vector3Int playerTilePosition;
    private bool controlEnabled = true;

	// Use this for initialization
	void Start () {
        gameController = FindObjectOfType<GameController>();
        hexMap = gameController.FindPlayerMap(transform.position);
        Debug.Assert(hexMap != null);  // This wont always be true need to fix TODO
        hexPlayer = GetComponentInChildren<HexPosition>();
        hexPlayer.Init(hexMap);
    }
	
	// Update is called once per frame
	void Update () {
        if (controlEnabled)
        {
            ProcessMovement();
            //ProcessCamera();
            ProcessActions();
        }
	}

    private void ProcessMovement()
    {
        float xThrow = Input.GetAxis("HorizontalMove");
        float yThrow = Input.GetAxis("VerticalMove");

        // Only do things if there is an input
        if (Mathf.Abs(xThrow) > Mathf.Epsilon || Mathf.Abs(yThrow) > Mathf.Epsilon)
        {

            float xOffset = xThrow * moveSpeed * Time.deltaTime;
            float yOffset = yThrow * moveSpeed * Time.deltaTime;

            Vector3 movementVector = new Vector3(xOffset, 0f, yOffset);
            transform.Translate(movementVector, Space.World);
            transform.rotation = Quaternion.LookRotation(movementVector.normalized);
        }

        if (!hexPlayer.CursorIsOnMap) return; // if we are not on the map we won't do anything so we can return

        playerTilePosition = hexPlayer.TileCoord;

        tileMarker.transform.position = HexConverter.TileCoordToCartesianCoord(playerTilePosition, 0.1f); //we put our tile marker on the tile in front of the player

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
            if (hexPlayer.CursorIsOnMap)
            {
                Tile<Environment> t = hexMap.TilesByPosition[playerTilePosition]; // select the tile the player is looking at
                print(t.Data.GetEnvironmentStats());
            }
        }
    }
}
