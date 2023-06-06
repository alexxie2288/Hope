using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerLife gameController;

    private void Awake(){
        gameController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            gameController.updateCheckpoint(transform.position);
        }
    }
}
