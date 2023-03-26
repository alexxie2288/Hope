using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private Rigidbody2D players;
    private Animator movement;
    
    // Start is called before the first frame update
    private void Start()
    {
        players = GetComponent<Rigidbody2D>(); 
        movement = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {


        float dirX = Input.GetAxisRaw("Horizontal");

        players.velocity = new Vector2(dirX * 7f, players.velocity.y);


        if(Input.GetButtonDown("Jump")){
            players.velocity = new Vector2(players.velocity.x, 7f);
        }

        UpdateRunningAnimation(dirX);
     
    }

    private void UpdateRunningAnimation(float x){
        if(x > 0f){
            movement.SetBool("Run", true);

        }
         else if(x < 0f){
            movement.SetBool("Run", true);
        }
        else{
            movement.SetBool("Run", false);
        }
    }
}
