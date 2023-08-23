using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followTarget;
    private Vector3 targetPosition;
    private float cameraSpeed = 4f;

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x,
            this.transform.position.y,
            this.transform.position.z);

        this.transform.position = Vector3.Lerp(this.transform.position,
            targetPosition, 
            cameraSpeed * Time.deltaTime);
    }
}
