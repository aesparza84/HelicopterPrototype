using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float speed;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Missile Spawned");
        rigidBody = GetComponent<Rigidbody>();

        direction = transform.forward;
    }

    private void FixedUpdate()
    {
        Debug.Log("Missile flying");
        rigidBody.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Debug.Log(collision.gameObject.name);
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("Missile Destroyed");
    }
}
