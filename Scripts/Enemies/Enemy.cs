using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [SerializeField] public GameObject leftMostPoint;
    [SerializeField] public GameObject rightMostPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision " + collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.Die();
        } else if (collision.gameObject.name == "Walls")
        {
            OnWallCollision();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.Die();
        }
    }

    protected void OnWallCollision()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
