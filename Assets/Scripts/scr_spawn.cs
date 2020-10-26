using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawn : MonoBehaviour
{
    public float spawnRate;
    public GameObject plataformaObj;

    void Start()
    {
        spawnRate = 1;
    }

    void Update()
    {
        if (spawnRate <= 0)
        {
            spawnRate = Random.Range(0.75f, 1.75f);
            Instantiate(plataformaObj, new Vector2(Random.Range(-2, 2), transform.position.y), transform.rotation);
        }

        else
        {
            spawnRate-= Time.deltaTime;
        }

    }
}
