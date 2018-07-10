using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;

    Rigidbody rb;
    bool controlEnabled = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
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

        float xOffset = xThrow * moveSpeed * Time.deltaTime;
        float yOffset = yThrow * moveSpeed * Time.deltaTime;
        
        Vector3 movementVector = new Vector3(xOffset, 0f, yOffset);
        transform.Translate(movementVector);
    }

    private void ProcessCamera()
    {
        float horizontalThrow = Input.GetAxis("HorizontalLook");
        float verticalThrow = Input.GetAxis("VerticalLook");

        // TODO camera movement
    }

    private void ProcessActions()
    {
        float confirmButton = Input.GetAxisRaw("ConfirmButton");
        float cancelButton = Input.GetAxisRaw("CancelButton");
        float actionButton = Input.GetAxisRaw("ActionButton");
        float menuNavButton = Input.GetAxisRaw("MenuNavButton");
        
    }
}
