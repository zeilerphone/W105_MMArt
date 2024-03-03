using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable()
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = MoveAction.ReadValue<Vector2>();
        Debug.Log(moveVector);
        Vector2 position = (Vector2)transform.position + moveVector * 0.1f;
        transform.position = position;
    }
}
