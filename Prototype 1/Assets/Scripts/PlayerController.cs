using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform; //[SerializeField] or sloppily set it public to expose it //opt.: = null;
    [SerializeField] private LayerMask playerMask;

    [SerializeField] private Transform wheelfr;
    [SerializeField] private Transform wheelfl;
    [SerializeField] private Transform wheelrr;
    [SerializeField] private Transform wheelrl;


    private Rigidbody rigidbodyComponent;

    private float speed = 20.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");  //side-to-side
        verticalInput = Input.GetAxis("Vertical");      //forward

        /*
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Turn the vehicle
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        */
    }

    private void FixedUpdate()
    {
        //Debug.Log($"overlap: {Physics.OverlapSphere(wheelrr.position, 0.5f).Length}");
        if (Physics.OverlapSphere(wheelrr.position, 0.5f).Length == 2
            && Physics.OverlapSphere(wheelrl.position, 0.5f).Length == 2
            && Physics.OverlapSphere(wheelfr.position, 0.5f).Length == 2
            && Physics.OverlapSphere(wheelfl.position, 0.5f).Length == 2)
        //if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0) //alt: Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1 //1 instead of 0 because playercollider is alwals colliding
        {
            //Debug.Log("returning");
            return;
        }

        Vector3 velocity = transform.forward * verticalInput * speed;
        velocity.y = 0;
        rigidbodyComponent.velocity = velocity;
        //rigidbodyComponent.AddForce(velocity*100);

        rigidbodyComponent.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
     
    }
}
