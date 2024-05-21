using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SOURCE:
// https://www.youtube.com/watch?v=XTfcTi2SUyE

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    private Transform target;

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!target) { return; }
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
        Vector2 temp;
        temp.x = 90;
        temp.y = 90;
        //Vector3 angle = Vector3.Angle(transform.forward)
        //rb.rotation = Mathf.Atan2(direction.x, direction.y);
        transform.up = direction;
        rb.rotation += 90f;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<currentH>
        Destroy(gameObject);
    }
}
