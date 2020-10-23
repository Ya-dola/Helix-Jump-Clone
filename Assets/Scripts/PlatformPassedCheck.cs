using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPassedCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(1);

        // FindObjectOfType<PlayerBallController>().perfectPass++;
    }
}
