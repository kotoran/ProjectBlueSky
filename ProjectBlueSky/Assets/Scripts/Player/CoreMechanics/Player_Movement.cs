using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : NetworkBehaviour
{
    //In the case we store players into an array, we will use 0
    [SerializeField]
    private int playerNumber = 0; 
    //[SerializeField]
    //private Vector3 velocity = new Vector3(8.0f, 0, 8.0f);
    [SerializeField]
    private float velocity = 8.0f;
    //private float acceleration = 0;
    //private float friction = 0;
    //[SerializeField]
    //private Rigidbody rb;

    // Use this for initialization
    //void Start()
    //{
    //rb = GetComponent<Rigidbody>();
    //rb.velocity = velocity;
    //rb.isKinematic = false;
    //}
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        var z = Input.GetAxis("Vertical") * velocity * Time.deltaTime;

        transform.Translate(x, 0, z);
    }
}
