using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform highestPoint;

    // Cached variables
    private Rigidbody2D rigidBody;

    private bool isDying = false;
    private bool isActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        isDying = false;
    }

    public void Activate()
    {
        isActivated = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActivated)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!isDying)
        {
            Move();
            Rotate();
            Flip();
        }
        
        ManageBoundaries();
    }

    public void Die()
    {
        if (isDying)
        {
            return;
        }
        rigidBody.velocity = Vector2.zero;
        isDying = true;
        GetComponent<Animator>().SetBool("IsDying", true);
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ManageBoundaries()
    {
        var posY = Mathf.Min(highestPoint.position.y, transform.position.y);
        transform.position = new Vector3(transform.position.x, posY, transform.position.z);
    }

    private void Rotate()
    {
        var speedX = Input.GetAxis("Horizontal");
        var speedY = Input.GetAxis("Vertical");

        if (speedX == 0 && speedY == 0)
        {
            return;
        }

        float angle = Mathf.Atan2(this.rigidBody.velocity.y, this.rigidBody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
    }

    private void Move()
    {
        var speedX = Input.GetAxis("Horizontal");
        var speedY = Input.GetAxis("Vertical");

        var velocity = new Vector2(speedX, speedY);
        velocity.Normalize();

        rigidBody.velocity = speed * velocity;
    }

    private void Flip()
    {
        var speedX = Input.GetAxis("Horizontal");

        transform.localScale = new Vector3(speedX  < 0 ? - 1 : 1, transform.localScale.y, transform.localScale.z);
    }
}
