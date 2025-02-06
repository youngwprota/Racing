using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vehicle pickedTransport;
    public void Start()
    {
        GameInitializer levelSettings = FindObjectOfType<GameInitializer>();
        pickedTransport = levelSettings.pickedTransport.GetComponent<Vehicle>();

        if (pickedTransport != null)
            Debug.Log("Find object: " + pickedTransport.name);
        else 
            Debug.Log("Can't find object pickedTransport");
    }

    private void Update()
    {
        pickedTransport.HorizontalMovement = Input.GetAxis("Horizontal"); 
        pickedTransport.VerticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
            pickedTransport.Handbrake();
        else if (Input.GetKeyUp(KeyCode.Space))
            pickedTransport.ReleaseHandbrake();
    }

    private void FixedUpdate()
    {
        if (pickedTransport.VerticalMovement > 0)
            pickedTransport.GoForward();
        else if (pickedTransport.VerticalMovement < 0)
            pickedTransport.GoBackward();

        if (pickedTransport.HorizontalMovement > 0 && pickedTransport.VerticalMovement > 0) 
            pickedTransport.TurnRight();
        else if (pickedTransport.HorizontalMovement < 0 && pickedTransport.VerticalMovement > 0)
            pickedTransport.TurnLeft();

        if (pickedTransport.HorizontalMovement > 0 && pickedTransport.VerticalMovement < 0) 
            pickedTransport.TurnLeft();
        else if (pickedTransport.HorizontalMovement < 0 && pickedTransport.VerticalMovement < 0)
            pickedTransport.TurnRight();
    }
}
