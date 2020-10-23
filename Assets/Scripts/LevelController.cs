using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Platform
{
    [Range(1,11)]
    public int partCount = 11;

    [Range(0, 11)]
    public int deathPartCount = 1;
}

[CreateAssetMenu(fileName = "New Level")]
public class LevelController : ScriptableObject {
    public Color levelBackgroundColor = Color.white;
    public Color levelPlatformPartColor = Color.white;
    public Color levelBallColor = Color.white;
    public List<Platform> platforms = new List<Platform>();
}

