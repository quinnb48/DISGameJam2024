using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    public float spawnRate = 3f;
    float timer;
    public GameObject spawnedObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = spawnRate;
            Instantiate(spawnedObject, transform.position, Quaternion.identity);
        }
    }
}
