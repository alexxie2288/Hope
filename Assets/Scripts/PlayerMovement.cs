using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D players;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator movement;

   [SerializeField] private float HorizontalVelocity = 7f;
   [SerializeField] private float VerticleVelocity = 11f;
   [SerializeField] private LayerMask jumpableGround;


    private enum MovementStatus{idle, running, jumping, falling}
    // Start is called before the first frame update
    private void Start()
    {
        players = GetComponent<Rigidbody2D>(); 
        coll = GetComponent<BoxCollider2D>();
        movement = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {


        float dirX = Input.GetAxisRaw("Horizontal");

        players.velocity = new Vector2(dirX * HorizontalVelocity, players.velocity.y);


        if(Input.GetButtonDown("Jump") && isGrounded()){
            players.velocity = new Vector2(players.velocity.x, VerticleVelocity);
        }

        UpdateRunningAnimation(dirX);
     
    }

    private void UpdateRunningAnimation(float x){
    MovementStatus status;

        if(x > 0f){
            status = MovementStatus.running;
            sprite.flipX = true;
        }
         else if(x < 0f){
            status = MovementStatus.running;
            sprite.flipX = false;
        }
        else{
            status = MovementStatus.idle;
        }

        if(players.velocity.y > .1f){
            status = MovementStatus.jumping;
        }
        else if(players.velocity.y < -.1f){
            status = MovementStatus.falling;
        }

        movement.SetInteger("status", (int)status);
    }

    private bool isGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
