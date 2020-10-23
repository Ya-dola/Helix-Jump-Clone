using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerBallController cameraTarget;
    // Keeps the starting distance between the camera and the player ball
    private float offset;

    private void Awake()
    {
        offset = transform.position.y - cameraTarget.transform.position.y;
    }

    void Update()
    {
        // Moves the camera smoothly to targets' height - on Y Axis
        Vector3 currentPos = transform.position;
        currentPos.y = cameraTarget.transform.position.y + offset;
        transform.position = currentPos;
    }
}
