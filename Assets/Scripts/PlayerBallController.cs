using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    public Rigidbody playerBallRigBody;
    public float impulseForce = 5f;
    private Vector3 startPos;
    private bool ignoreDoubleCollision;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreDoubleCollision)
            return;

        // Sets the ball speed to zero
        playerBallRigBody.velocity = Vector3.zero;

        // Pushes Ball Upwards
        playerBallRigBody.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreDoubleCollision = true;
        Invoke("AllowCollision", 0.2f);

        GameManager.singleton.AddScore(1);
        Debug.Log("Score: " + GameManager.singleton.score);
    }

    private void AllowCollision()
    {
        ignoreDoubleCollision = false;
    }
}
