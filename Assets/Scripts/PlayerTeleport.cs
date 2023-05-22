using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{

    public GameObject portal;
    private GameObject player;
    private Animator anim;

    void Start(){
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }


    IEnumerator Teleport(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 1f){

                anim.SetTrigger("Teleport");
                yield return new WaitForSeconds(1);
            
                player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
            }
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        StartCoroutine(Teleport(collision));
    }

}