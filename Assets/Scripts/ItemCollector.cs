using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int items = 0;

   private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Items")){
            Destroy(collision.gameObject);
            items++;
            Debug.Log("item num" + items);
        }
   }
}
 