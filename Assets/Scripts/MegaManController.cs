using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaManController : MonoBehaviour
{
    public float velocityX = 8;
    public float JumpForce = 40;

    //Bullets Pequeñas
    public GameObject rightBullet;
    public GameObject leftBullet;

    //Bullet Mediana
    public GameObject Right_MBullet;
    public GameObject Left_MBullet;

    //Bullet Grande
    public GameObject Right_BBullet;
    public GameObject Left_BBullet;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    
    //Const
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_RUN = 1;
    private const int ANIMATION_RUNSHOOTING = 2;
    private const int ANIMATION_JUMP = 3;

    private float time = 0f;

    void Start()
    {
       Debug.Log("Iniciando Game Objet");
       sr = GetComponent<SpriteRenderer>();
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(ANIMATION_QUIETO);
        
        //ir a la derecha
        if(Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUN);
        }
        //ir a la derecha disparando
        if(Input.GetKey(KeyCode.F))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            changeAnimation(ANIMATION_RUNSHOOTING);
        }
        
        //ir a la izquierda
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUN);
        }
        //ir a la izquierda disparando
        if(Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true;
            changeAnimation(ANIMATION_RUNSHOOTING);
        }
        
        //Dispara bala pequeña
        if (Input.GetKeyUp(KeyCode.X))
        {
            var bullet = sr.flipX ? leftBullet : rightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);
        }
        //Dispara bala mediana
        if (Input.GetKeyUp(KeyCode.C))
        {
 
            var bullet = sr.flipX ? Left_MBullet : Right_MBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);
        }
        //Dispara bala Grande
        if (Input.GetKeyUp(KeyCode.V))
        {
 
            var bullet = sr.flipX ? Left_BBullet : Right_BBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);
        }
        
        //saltar
        if(Input.GetKeyUp(KeyCode.Space) )
        {
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            changeAnimation(ANIMATION_JUMP);
        }
    }
    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}

