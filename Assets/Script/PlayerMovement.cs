using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //w, a, s, d
    private Rigidbody2D Rbody;                                          // створ змін компоненти player (inspector)
    private BoxCollider2D BoxCollider;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private LayerMask jumpground;

    private float directionX = 0f;
    [SerializeField] private float movespeed = 8f;                     //7 [SerializeField] - дод.поле в unity => Player -> Player Movement; movespeed = швидкість переміщення
    [SerializeField] private float jumpforce = 12f;                     //9 стрибкова сила

    private enum MovementStatus {idle, running, jumping, falling}       //0,1,2,3

    [SerializeField] private AudioSource JumpSoundEffect;               //Jump sound

    // Start(before the first frame update)
    private void Start()
    {
        //Debug.Log("working");
        Rbody = GetComponent<Rigidbody2D>();                            //присв знач компоненти
        BoxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update (once per frame)
    private void Update()
    {
        directionX = Input.GetAxisRaw("Horizontal");                    //axis - вісь, raw - (без скольжения), немедленно
        Rbody.velocity = new Vector2(directionX * movespeed, Rbody.velocity.y);

        if (Input.GetButtonDown("Jump") && IsOnTheGround())             //якщо натиснути space
        {
            JumpSoundEffect.Play();                                     //play sound effect
            //Rbody.velocity = new Vector2(Rbody.velocity.x, jumpforce);     // или використ player, компонент  unity "rigidbody2d", velocity розміщ, vector (x,y)
            Rbody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse); // или імпульс вверх по осі y до Rigidbody2D
        }

        AnimationsUpdate();
    }
    // Animation
    private void AnimationsUpdate()
    {
        MovementStatus movementStatus;
        if (directionX > 0f)                                            //run, if 0 = stop
        {
            movementStatus = MovementStatus.running;                    //right direction
            spriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            movementStatus = MovementStatus.running;                    //left direction
            spriteRenderer.flipX = true;                                //перевернути анімацію
        }
        else
        {
            movementStatus = MovementStatus.idle;                       // idle (stop)
        }

        if(Rbody.velocity.y > .1f)                                      //up
        { 
            movementStatus = MovementStatus.jumping;
        }
        else if(Rbody.velocity.y < -.1f)                                //down
        {
            movementStatus = MovementStatus.falling;
        }
        animator.SetInteger("Status", (int)movementStatus);
    }

    private bool IsOnTheGround()
    {
        return Physics2D.BoxCast(BoxCollider.bounds.center, BoxCollider.bounds.size,0f, Vector2.down,.1f, jumpground); // маленька коробочка трохи нижче гравця, яка перевіряє чи на землі гравець
    }
}
