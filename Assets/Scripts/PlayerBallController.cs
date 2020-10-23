using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    private bool ignoreDoubleCollision;
    public Rigidbody playerBallRigBody;
    public float impulseForce = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreDoubleCollision)
            return;

        Debug.Log("Ball Touched Something");

        // Sets the ball speed to zero
        playerBallRigBody.velocity = Vector3.zero;

        // Pushes Ball Upwards
        playerBallRigBody.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        ignoreDoubleCollision = true;
        Invoke("AllowCollision", 0.2f);
    }

    private void AllowCollision()
    {
        ignoreDoubleCollision = false;
    }
}
