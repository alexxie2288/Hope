using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 respawnPoint;
    CameraController cameraController;
    private Vector3 scale;

    private void Awake(){
        cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawnPoint = transform.position;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Killzone")){
            Die();
        }
    }

    private void Die()
    {
        anim.SetBool("death", true);
        StartCoroutine(Respawn(0.5f));
        
    }


    // private void Respawn(){
    //     rb.transform.position = new Vector2(respawnPoint.x, respawnPoint.y);
    //     //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    // private void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    public void updateCheckpoint(Vector2 pos){
        respawnPoint = pos;
    }

    IEnumerator Respawn(float duration){
        scale = transform.localScale;
        rb.velocity = Vector3.zero;;
        rb.simulated = false;
        transform.localScale = new Vector3(0,0,0);
        yield return new WaitForSeconds(duration);
        
        transform.position = respawnPoint;
        transform.localScale = scale;
        rb.simulated = true;
        rb.transform.parent = null;
        anim.SetBool("death", false);
    }
}