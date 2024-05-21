using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// SOURCE:
// https://www.youtube.com/watch?v=0x4EigFnWws
public class Turret : MonoBehaviour
{
    public Transform turretRotationPoint;
    public Transform bulletOrigin;
    public GameObject bulletPrefab;
    public LayerMask TargetMask;
    public float range = 10;
    public float rotationSpeed = 250;
    public float fireRate = 1;

    private Transform target;
    private float timeToFire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            FindTarget();
        }
        else
        {
            if (CheckTargetInRange())
            {
                RotateTowardsTarget();
                timeToFire += Time.deltaTime;
                if (timeToFire >= 1 / fireRate)
                {
                    Shoot();
                    timeToFire = 0;
                }
            }
            else { target = null; }
        }
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(turretRotationPoint.position, range, (Vector2)turretRotationPoint.position, 0, TargetMask);
        if (hits.Length > -0)
        {
            target = hits[0].transform;
        }
    }

    private bool CheckTargetInRange()
    {
        return Vector2.Distance(target.position, turretRotationPoint.position) <= range;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - turretRotationPoint.position.y, target.position.x - turretRotationPoint.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bulletPrefab, bulletOrigin.position, Quaternion.identity);
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.white;
        Handles.DrawWireDisc(turretRotationPoint.position, turretRotationPoint.forward, range);
    }
}
