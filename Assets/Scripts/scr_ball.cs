using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_ball : MonoBehaviour
{
    public Rigidbody2D rigid;
    public float velocidade;
    public Transform mundo;

    public scr_gameManager gmLink;

    void Start()
    {
        gmLink = GameObject.FindGameObjectWithTag("GM").GetComponent<scr_gameManager>();
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            Movimentacao();
        }
    }

    public void Movimentacao()
    {

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0.02f)
        {
            float x = transform.position.x;
            transform.position = new Vector2(x, transform.position.y);
        }
        else if (viewPos.x > 0.99f)
        {
            float x = transform.position.x;
            transform.position = new Vector2(x, transform.position.y);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movimento = new Vector3(moveHorizontal, 0, 0);

        transform.Translate(movimento * velocidade);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -2.5f, 2.50f), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            transform.SetParent(collision.transform, true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chao")
        {
            transform.SetParent(mundo, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coliPonto")
        {
            gmLink.MarcaPonto();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "morte")
        {
            gmLink.StartCoroutine(gmLink.Morte(3.5f));
            Destroy(gameObject);
        }
    }
}
