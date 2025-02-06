using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class DemoBall : MonoBehaviour
{
    public float speed = 5f;
    public float currentSpeed { get; set; }
    public float maxSpeed = Mathf.Infinity;
    private Rigidbody rb;
    public Vector3 originalPosition;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = gameObject.transform.position;
        
        float x = Random.value < 0.5f ? -1f : 1f;
        
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
            : Random.Range(0.5f, 1f);

        // Apply the initial force and set the current speed
        Vector3 direction = new Vector3(x, y).normalized;
        rb.AddForce(direction * speed, ForceMode.Impulse);
        currentSpeed = speed;
    }

    // Update is called once per frame
    /*void Update()
    {
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);
        Quaternion posRotation = Quaternion.Euler(45f, 0f, 0f);
        Quaternion negRotation = Quaternion.Euler(-45f, 0f, 0f);
        
        Vector3 posVector = posRotation * up;
        Vector3 negVector = negRotation * up;

        Transform t = GetComponent<Transform>();
        Debug.DrawRay(transform.position, posVector * 2f, Color.red);
        Debug.DrawRay(transform.position, negVector * 2f, Color.blue);
    }*/

    void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Made contact with {other.gameObject.name}");
        
        Rigidbody rbody = GetComponent<Rigidbody>();
        
        float speed = other.relativeVelocity.magnitude;
        float newSpeed = speed * 2f;
        
        Vector3 newVelocity = other.relativeVelocity;
        newVelocity = newVelocity.normalized * newSpeed;

        rbody.linearVelocity = newVelocity;
        
        ContactPoint contact = other.GetContact(0);

        //Vector3 velocity = other.rigidbody.linearVelocity;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Goal"))
        {
            //transform.position = new Vector3(0, 0.8f, -0.07169282f);
            
            //transform.position = Vector3.zero;
            
            //rb.position = originalPosition + new Vector3(0, 0.8f, -0.07169282f);
            
            /*Vector3 position = transform.position;
            position.x = 0;
            position.y = 0.8f;
            position.z = -0.07169282f;
            transform.position = position;*/
        }
        

        /*if (other.gameObject.CompareTag("Wall"))
        {
            velocity.y *= -1;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            velocity.x *= -1;
        }*/
    }
    
    private void FixedUpdate()
    {
        // Clamp the velocity of the ball to the max speed
        Vector3 direction = rb.linearVelocity.normalized;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        rb.linearVelocity = direction * currentSpeed;
    }
}
