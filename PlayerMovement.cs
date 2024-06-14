using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float upForce;
    private float yInput;
    //private float xInput;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxisRaw("Vertical");
        //xInput = Input.GetAxisRaw("Horizontal");

    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * upForce * yInput);
        //Añade movimiento giratorio , con el menos se aplica a la direccion de la tecla
        //rb.AddTorque(-xInput);
    }
}
