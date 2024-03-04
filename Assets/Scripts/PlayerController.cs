using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public InputAction CageDeploy;
    Rigidbody2D rigidbody2d;
    public GameObject cage;
    Vector2 moveVector;
    float deployVector;
    public int cageCount;
    public int catCount;
    Vector2 moveDirection = new Vector2(1, 0);
    Vector2 position;
    public float speed = 5.0f;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        CageDeploy.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cageCount = 3;
        catCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = MoveAction.ReadValue<Vector2>();
        if(moveVector.magnitude != 0){
            moveVector.Normalize();
        }

        deployVector = CageDeploy.ReadValue<float>();
        if (CageDeploy.WasPressedThisFrame()){
            if(deployVector > 0){
                if(cageCount > 0){
                    cageCount--;
                    Instantiate(cage, transform.position, Quaternion.identity);
                    Debug.Log("Cage Deployed! " + cageCount + " cages left.");
                } else {
                    Debug.Log("No cages left!");
                }
            }
        }

        if(!Mathf.Approximately(moveVector.x, 0) || !Mathf.Approximately(moveVector.y, 0)){
            moveDirection.Set(moveVector.x, moveVector.y);
            moveDirection.Normalize();
        }
        animator.SetFloat("moveX", moveDirection.x);
        animator.SetFloat("moveY", moveDirection.y);
        animator.SetFloat("speed", moveVector.magnitude);
    }

    void FixedUpdate()
    {
        position = (Vector2)transform.position + moveVector * speed * Time.deltaTime;  
        rigidbody2d.MovePosition(position);
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "cage"){
            deployVector = CageDeploy.ReadValue<float>();
            Debug.Log("Cage Touching: " + deployVector);
            if(deployVector < 0){
                Debug.Log("Cage Retracted!");
                cageCount++;
                other.gameObject.SetActive(false);
            }
        }
    }
}
