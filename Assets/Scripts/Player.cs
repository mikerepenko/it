using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D body;
    private float jump = 17f;

    public GameManager gameManager;

    private AudioSource soundFence;
    private AudioSource soundLuke;

    void Start()
    {
        soundFence = GameObject.Find("Sound_Fence").GetComponent<AudioSource>();
        soundLuke = GameObject.Find("Sound_Luke").GetComponent<AudioSource>();

        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            body.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "clown")
        {
            gameManager.GameOver();
        }
        if (col.gameObject.tag == "fence")
        {
            soundFence.Play();
        }
        if (col.gameObject.tag == "luke")
        {
            soundLuke.Play();
            gameManager.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "coin")
        {
            Destroy(other.gameObject);
            gameManager.AddMoney(5);
        }
    }
}