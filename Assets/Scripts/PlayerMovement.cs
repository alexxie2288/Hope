using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D players;
    private BoxCollider2D coll;
    private Animator movement;
    private SpriteRenderer sprite;
    private float dirX;
    private bool isFacingRight = true;

    private bool canDash = true; 
    private bool isDashing;
    private float dashingPower = 15f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private float HorizontalVelocity = 7f;
    [SerializeField] private float VerticleVelocity = 11f;
    [SerializeField] private LayerMask jumpableGround;   
    [SerializeField] private TrailRenderer tr;


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
        if (isDashing)
        {
            return;
        }

        dirX = Input.GetAxisRaw("Horizontal");

        players.velocity = new Vector2(dirX * HorizontalVelocity, players.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded()){
            players.velocity = new Vector2(players.velocity.x, VerticleVelocity);
        }
            players.velocity = new Vector2(dirX * HorizontalVelocity, players.velocity.y);
         if ((Input.GetKeyDown(KeyCode.LeftShift)) && (canDash))
        {
            StartCoroutine(Dash());
        }
        
        UpdateRunningAnimation(dirX);
     
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        players.velocity = new Vector2(dirX * VerticleVelocity, players.velocity.y);
        //players.velocity = new Vector2(HorizontalVelocity * VerticleVelocity, players.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && dirX < 0f || !isFacingRight && dirX > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void UpdateRunningAnimation(float x){
    MovementStatus status;
        //Debug.Log(x);
        if(x > 0f){
            status = MovementStatus.running;
            sprite.flipX = true;
        }
         else if(x < 0f){
            status = MovementStatus.running;
            sprite.flipX = true;
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
        Flip();
        movement.SetInteger("status", (int)status);
    }

    private bool isGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = players.gravityScale;
        players.gravityScale = 0f;
        players.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        players.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
