using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 moveVector;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = MoveAction.ReadValue<Vector2>();
        if(moveVector.magnitude != 0){
            moveVector /= moveVector.magnitude;
        }
        Debug.Log(moveVector);
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + moveVector * speed * Time.deltaTime;        
        rigidbody2d.MovePosition(position);
    }
}
