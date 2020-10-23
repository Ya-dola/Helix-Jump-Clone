using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 lastTapPos;
    private Vector3 startRotation;
    public Transform topPlatformTransform;
    public Transform goalPlatformTransform;
    private float helixDistance;
    public List<LevelController> allLevels = new List<LevelController>();
    private List<GameObject> spawnedPlatforms = new List<GameObject>();
    public GameObject helixPlatformPrefab;
    private int numPlatformParts = 12;


    private void Awake()
    {
        // Returns Angles of the object in Vector 3 format
        startRotation = transform.localEulerAngles;
        helixDistance = topPlatformTransform.localPosition.y - (goalPlatformTransform.localPosition.y + 0.1f);
        LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
                lastTapPos = currentTapPos;

            float deltaPos = lastTapPos.x - currentTapPos.x;
            lastTapPos = currentTapPos;

            transform.Rotate(Vector3.up * deltaPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }

    public void LoadLevel(int levelNumber)
    {
        // Get the correct Level
        LevelController level = allLevels[Mathf.Clamp(levelNumber, 0, allLevels.Count - 1)];

        if (level == null)
        {
            Debug.LogError("No Level " + levelNumber + " found in allLevels list from HelixController !!! Check if all the Levels are assigned in the list ?");
            return;
        }

        // Set the new background color
        Camera.main.backgroundColor = allLevels[levelNumber].levelBackgroundColor;
        FindObjectOfType<PlayerBallController>().GetComponent<Renderer>().material.color = allLevels[levelNumber].levelBallColor;

        // Reset the helix rotation
        transform.localEulerAngles = startRotation;

        // Destroy the old platforms if there are some
        foreach (GameObject go in spawnedPlatforms)
            Destroy(go);

        // Creates new platforms
        float platformDistance = helixDistance / level.platforms.Count;
        float spawnPosY = topPlatformTransform.localPosition.y;

        for (int i = 0; i < level.platforms.Count; i++)
        {
            spawnPosY -= platformDistance;
            GameObject platform = Instantiate(helixPlatformPrefab, transform);

            // Debug.Log("Spawned Level");
            platform.transform.localPosition = new Vector3(0, spawnPosY, 0);
            spawnedPlatforms.Add(platform);

            // Disable some parts according to platform setup
            int partsToDisable = numPlatformParts - level.platforms[i].partCount;
            List<GameObject> disabledParts = new List<GameObject>();

            // Debug.Log("Should disable " + partsToDisable);

            // Disables Parts randomly
            while (disabledParts.Count < partsToDisable)
            {
                GameObject randomPart = platform.transform.GetChild(Random.Range(0, platform.transform.childCount)).gameObject;

                if (!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                    // Debug.Log("Disabled Part");
                }
            }

            // Colours the active parts
            List<GameObject> activePlatformParts = new List<GameObject>();

            foreach (Transform transform in platform.transform)
            {
                transform.GetComponent<Renderer>().material.color = allLevels[levelNumber].levelPlatformPartColor;

                if (transform.gameObject.activeInHierarchy)
                    activePlatformParts.Add(transform.gameObject);
            }

            // Debug.Log(activePlatformParts.Count + " parts left");

            List<GameObject> deathParts = new List<GameObject>();

            // Debug.Log("Should mark " + stage.levels[i].deathPartCount + " death parts");

            while (deathParts.Count < level.platforms[i].deathPartCount)
            {
                GameObject randomPart = activePlatformParts[(Random.Range(0, activePlatformParts.Count))];

                if (!deathParts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPartController>();
                    deathParts.Add(randomPart);
                    // Debug.Log("Set death part");
                }
            }
        }
    }

    // TODO - Make number of Active Parts and Death Parts be generated randomly purely from code
}
