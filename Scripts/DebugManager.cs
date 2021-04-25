using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{

    [SerializeField] Text debugText;
    [SerializeField] bool showDebug = true;

    PlayerController player;
    LevelManager manager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        manager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!showDebug)
        {
            return;
        }

        var currentLevelString = "Starting Area";
        if (manager.currentLevel != null)
        {
            currentLevelString = manager.currentLevel.gameObject.name;
        }
        debugText.text = "Level : " + currentLevelString + "     Player position : " + player.transform.position.y;
    }
}
