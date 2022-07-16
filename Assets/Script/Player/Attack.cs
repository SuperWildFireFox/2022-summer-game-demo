using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void  OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("collision Judge!...");
        if (collision.gameObject.tag == "Enemy"){
            Debug.Log("collision Judge!...");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Deadth();
        }
    }
}
