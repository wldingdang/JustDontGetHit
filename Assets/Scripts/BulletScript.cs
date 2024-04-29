using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// SOURCE:
// https://www.youtube.com/watch?v=dCtt6ri5Iag

public class BulletScript : MonoBehaviour
{
    public GameObject Bullet;
    public Transform BulletOrigin;
    public Vector2 Direction;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % 1 == 0) { shoot(); }
    }

    void shoot()
    {
        GameObject bulletInstance = Instantiate(Bullet, BulletOrigin.position, Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}
