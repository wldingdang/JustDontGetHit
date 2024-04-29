using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SOURCE:
// https://www.youtube.com/watch?v=fcKGqxUuENk

public class PlayerControllerRB : MonoBehaviour
{
    public float moveSpeed;
    Vector2 input;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = input * moveSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
