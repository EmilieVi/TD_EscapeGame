using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]//Ajoute un rigidbody s'il n'y en a pas
public class MovementBehaviour : MonoBehaviour {

    Rigidbody rb;
    Vector3 velocity;
    [SerializeField] float speed; //SerializeField -> Accéder à la variable dans l'éditeur
    [SerializeField] Camera cam;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        velocity = Vector3.zero;
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        /*if (xAxis != 0)
        {
            velocity.x = xAxis * speed;
        }

        if (zAxis != 0)
        {
            velocity.z = zAxis * speed;
        }*/
        velocity = cam.transform.forward * speed * zAxis;
        velocity += cam.transform.right * speed * xAxis;
        velocity.y = 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }
}
