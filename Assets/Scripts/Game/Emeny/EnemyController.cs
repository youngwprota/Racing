using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmenyController : MonoBehaviour
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

    private void FixedUpdate()
    {
        if (gameObject != null && pickedTransport != null)
        {
            float speed = 5f; 
            gameObject.transform.position = Vector3.MoveTowards(
                gameObject.transform.position, 
                pickedTransport.transform.position, 
                Time.deltaTime * speed
            );
        }
    }
}
