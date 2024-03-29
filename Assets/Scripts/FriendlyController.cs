using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FriendlyController : MonoBehaviour
{
    public float movementSpeed;
    public GameObject player;

    Rigidbody2D rigidbody2d;
    Vector2 moveVector;
    Vector2 position;
    bool caged = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();        
    }

    void FixedUpdate()
    {   
        if(caged){
            return;
        }
        moveVector = new Vector2(0,0);
        if(Vector2.Distance(rigidbody2d.position, player.GetComponent<Rigidbody2D>().position) < 5.0f){
            // calculate the vector towards the player
            moveVector = player.GetComponent<Rigidbody2D>().position - rigidbody2d.position;
        } else {
            //moveVector = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        }
        moveVector.Normalize();
        position = rigidbody2d.position + moveVector * movementSpeed * Time.deltaTime;  
        rigidbody2d.MovePosition(position);
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player){
            player.GetComponent<PlayerController>().catCount++;
            this.GameObject().SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "cage"){
            rigidbody2d.MovePosition(other.GameObject().GetComponent<Rigidbody2D>().position);
            caged = true;
        }
    }
}
