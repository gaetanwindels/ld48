using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] float height = 1;
    [SerializeField] float width = 8;
    [SerializeField] int numberToSpawn = 1;

    private List<GameObject> spawnedEnemies;

    // Start is called before the first frame update
    void Start()
    {
        spawnedEnemies = new List<GameObject>();

        for (var i = 0; i < numberToSpawn;  i++)
        {
            var x = Random.Range(transform.position.x - width / 2, transform.position.x + width / 2);
            var y = Random.Range(transform.position.y - height / 2, transform.position.y + height / 2);
            var go = Instantiate(enemyToSpawn, new Vector3(x, y, 10), Quaternion.identity);
            spawnedEnemies.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
