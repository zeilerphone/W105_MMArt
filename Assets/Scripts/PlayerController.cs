using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public Rigidbody2D rigidbody2d;
    Vector2 moveVector;
    Vector2 moveDirection = new Vector2(1, 0);
    Vector2 position;
    public float speed = 5.0f;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = MoveAction.ReadValue<Vector2>();
        if(moveVector.magnitude != 0){
            moveVector.Normalize();
        }
        //Debug.Log(moveVector);

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
}
