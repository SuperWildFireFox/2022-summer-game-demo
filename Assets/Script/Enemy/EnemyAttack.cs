using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDemage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void  OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("collision Judge!...");
        if (collision.gameObject.tag == "Player"){
            Debug.Log("Attacked Player ! ....");
            // Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            collision.gameObject.GetComponent<PlayerControl>().Hurted(attackDemage);
            // Debug.Log(enemy);
            // enemy.Attacked(attackDemage);
        }
    }
}
