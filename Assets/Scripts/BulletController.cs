using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float velocityX = 10;

    private const string ENEMY_TAG = "Enemy"; 

    private Rigidbody2D rb;
    private int cont = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Destroy(this.gameObject, 2);
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag != "Player")
            Destroy(this.gameObject);

        if (other.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(other.gameObject);
        }
    }
}
