using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_platform : MonoBehaviour
{

    public float velocidade;
    scr_gameManager link;

    void Start()
    {
        link = FindObjectOfType<scr_gameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * velocidade * link.multiVelocidade * Time.deltaTime);

    }
}
