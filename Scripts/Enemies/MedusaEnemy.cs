using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MedusaEnemy : Enemy
{

    [SerializeField] float moveAmplitudeY = 0.5f;
    [SerializeField] float moveAmplitudeX = 2f;
    [SerializeField] float minAmplitudeX = 1f;
    [SerializeField] float speed = 2f;
    [SerializeField] float speedAmplitude = 0.5f;

    [SerializeField] float minStopTime = 0.2f;
    [SerializeField] float maxStopTime = 1f;

    [SerializeField] bool changeDirectionOnNext = false;

    Vector2 startPosition;
    Vector2 destination;
    float direction = 1;
    float computedSpeed;

    private bool isPickingNext = false;

    new protected void OnWallCollision()
    {
        Debug.Log("Wall collision");
        direction *= -1;
        PickNextDestination();
    }

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        direction = Random.Range(0f, 1f) > 0.5f ? -1 : 1;
        computedSpeed = speed + Random.Range(-speedAmplitude, speedAmplitude);
        PickNextDestination();
    }

    void Flip()
    {
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
    }

    void PickNextDestination()
    {
        if (changeDirectionOnNext)
        {
            direction = Random.Range(0f, 1f) > 0.5f ? -1 : 1;
        }
        var newX = Random.Range(minAmplitudeX, moveAmplitudeX);
        newX *= direction;
        var newY = Random.Range(startPosition.y - 0.25f, startPosition.y + 0.25f);
        destination = new Vector2(newX + transform.position.x, newY);
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * computedSpeed);

        var outOfBoundaries = transform.position.x < leftMostPoint.transform.position.x || transform.position.x > rightMostPoint.transform.position.x;

        if (transform.position.x == destination.x)
        {
            if (maxStopTime == 0f)
            {
                PickNextDestination();
            } else if (!isPickingNext)
            {
                StartCoroutine(PickNextDestinationRoutine(Random.Range(minStopTime, maxStopTime)));
            }
        } else if (outOfBoundaries)
        {
            var x = Mathf.Max(transform.position.x, leftMostPoint.transform.position.x);
            x = Mathf.Min(x, rightMostPoint.transform.position.x);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            direction *= -1;
            PickNextDestination();
        }
    }

    IEnumerator PickNextDestinationRoutine(float time)
    {
        isPickingNext = true;
        yield return new WaitForSeconds(time);
        PickNextDestination();
        isPickingNext = false;
    }

}
