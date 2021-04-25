using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject startingArea;
    [SerializeField] GameObject water;
    [SerializeField] GameObject waterFollowPoint;
    [SerializeField] Level[] levels;
    [SerializeField] GameObject highestPoint;
    [SerializeField] GameObject lowestPoint;
    [SerializeField] GameObject startingAreaPoint;

    [SerializeField] UnityEngine.Experimental.Rendering.LWRP.Light2D globalLight;

    // Cached variable
    private PlayerController player;

    // State variable
    public Level currentLevel = null;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Is player close to the end of the current level? 
        var bounds = water.GetComponent<Renderer>().bounds;
        var size = bounds.size.x / 2;
        water.transform.position = new Vector3(water.transform.position.x, player.transform.position.y - 3, water.transform.position.z);

        Debug.Log("position" + (water.transform.position.y + size));
        Debug.Log("waterposition" + (water.transform.position.y));
        Debug.Log("size" + (size));
        Debug.Log("highest" + (highestPoint.transform.position.y));
        Debug.Log("repo" + (highestPoint.transform.position.y - size));
        if (water.transform.position.y > -13.23f)
        {
            water.transform.position = new Vector3(water.transform.position.x, -13.23f, water.transform.position.z);
        } else if (water.transform.position.y < -138.356f)
        {
            water.transform.position = new Vector3(water.transform.position.x, -138.356f, water.transform.position.z);
        }

        UpdateLight();
    }

    public void SetCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    private void UpdateLight()
    {
        if (currentLevel != null && currentLevel.nextLevel != null)
        {
            var lightInterval = currentLevel.lightIntensityStart - currentLevel.lightIntensityEnd;
            var distance = currentLevel.transform.position.y - currentLevel.nextLevel.transform.position.y;
            var distanceTraveled = player.transform.position.y - currentLevel.transform.position.y;

            globalLight.intensity = currentLevel.lightIntensityStart + ((distanceTraveled / distance) * lightInterval);
        } else if (currentLevel == null)
        {
            globalLight.intensity = 1f;
        }
    }
}
