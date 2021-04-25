using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You win");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetBool("IsWin", true);
    }

    public void DisplayWinScreen()
    {
        FindObjectOfType<GameManager>().DisplayWinScreen();
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
