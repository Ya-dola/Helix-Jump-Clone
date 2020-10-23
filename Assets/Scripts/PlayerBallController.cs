using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    public Rigidbody playerBallRigBody;
    public float impulseForce = 5f;
    private Vector3 startPos;
    private bool ignoreDoubleCollision;
    // public int perfectPass = 0;
    // public bool isSuperSpeedActive;

    private void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // // activate super speed
        // if (perfectPass >= 3 && !isSuperSpeedActive)
        // {
        //     isSuperSpeedActive = true;
        //     rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreDoubleCollision)
            return;

        // if (isSuperSpeedActive)
        // {
        //     if (!other.transform.GetComponent<Goal>())
        //     {
        //         /*foreach (Transform t in other.transform.parent)
        //         {
        //             gameObject.AddComponent<TriangleExplosion>();

        //             StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
        //             //Destroy(other.gameObject);
        //             Debug.Log("exploding - exploding - exploding - exploding");
        //         }*/
        //         Destroy(other.transform.parent.gameObject);

        //     }

        // }
        // // If super speed is not active and a death part git hit -> restart game
        // else
        // {
        DeathPartController deathPartController = collision.transform.GetComponent<DeathPartController>();
        if (deathPartController)
            deathPartController.HitDeathPart();
        // }

        // Sets the ball speed to zero
        playerBallRigBody.velocity = Vector3.zero;

        // Pushes Ball Upwards
        playerBallRigBody.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);

        // Safety Check to ensure the ball does not collide twice 
        ignoreDoubleCollision = true;
        Invoke("AllowCollision", 0.2f);

        // Handling super speed
        // perfectPass = 0;
        // isSuperSpeedActive = false;

    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

    private void AllowCollision()
    {
        ignoreDoubleCollision = false;
    }
}
