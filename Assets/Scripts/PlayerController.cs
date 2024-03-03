using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = MoveAction.ReadValue<Vector2>();
        if(moveVector.magnitude != 0){
            moveVector /= moveVector.magnitude;
        }
        Debug.Log(moveVector);
        Vector2 position = (Vector2)transform.position + moveVector * speed * Time.deltaTime;
        transform.position = position;
    }
}
