using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkittishController : MonoBehaviour
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
            // calculate the vector away from the player
            moveVector = rigidbody2d.position - player.GetComponent<Rigidbody2D>().position;
        } else if (GameObject.FindGameObjectWithTag("cage") != null){
            GameObject cage = GameObject.FindGameObjectWithTag("cage");
            if(Vector2.Distance(rigidbody2d.position, cage.GetComponent<Rigidbody2D>().position) < 10.0f){
                moveVector = cage.GetComponent<Rigidbody2D>().position - rigidbody2d.position;
            }
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
