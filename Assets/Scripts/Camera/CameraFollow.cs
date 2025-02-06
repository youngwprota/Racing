using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject followObject;
    [SerializeField] private float returnSpeed;
    [SerializeField] private float height;
    [SerializeField] private float rearDisatnce;
    [SerializeField] private float lowYoffset;

    private Vector3 currentVector;

    void Start()
    {
        GameInitializer levelSettings = FindObjectOfType<GameInitializer>();
        followObject = levelSettings.pickedTransport;
        
        transform.position = new Vector3(followObject.transform.position.x, followObject.transform.position.y + height, followObject.transform.position.z - rearDisatnce);
        transform.rotation = Quaternion.LookRotation(followObject.transform.position - transform.position);
    }
    void Update()
    {   if (followObject.transform.position.y < -1)
            LowCameraMove();
        else 
            DefaultCameraMove();
    }

    void DefaultCameraMove() 
    {
        returnSpeed = 5f;

        transform.position = new Vector3(followObject.transform.position.x, followObject.transform.position.y + height, followObject.transform.position.z - rearDisatnce);
        transform.rotation = Quaternion.LookRotation(followObject.transform.position - transform.position);

        currentVector = new Vector3(followObject.transform.position.x, followObject.transform.position.y + height, followObject.transform.position.z - rearDisatnce);
        transform.position = Vector3.Lerp(transform.position, currentVector, returnSpeed * Time.deltaTime);
    } 

    void LowCameraMove()
    {
        returnSpeed = 1.5f;

        Vector3 targetPosition = new (followObject.transform.position.x, followObject.transform.position.y + lowYoffset, followObject.transform.position.z);
        Quaternion targetRotation = followObject.transform.rotation;
        transform.position = Vector3.Lerp(transform.position, targetPosition, returnSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, returnSpeed * Time.deltaTime);
    }
}
