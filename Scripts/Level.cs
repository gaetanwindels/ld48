using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] public  float lightIntensityStart = 1;
    [SerializeField] public float lightIntensityEnd = 0.8f;
    [SerializeField] public float length = 100f;
    [SerializeField] public Level previousLevel = null;
    [SerializeField] public Level nextLevel;

    // Cached variables
    LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entering " + gameObject.name + " level");
        if (collision.gameObject.name == "Player")
        {
            levelManager.SetCurrentLevel(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Entering " + gameObject.name + " level");
    }

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
