using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerBall : MonoBehaviour
{
   

    private float _horozontalinput;
    private float _forwardinput;
    public float Speed = 10f;
    private Rigidbody _PlayerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _PlayerRigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        _horozontalinput = Input.GetAxis("Horizontal");
        _forwardinput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horozontalinput, 0.0f, _forwardinput);

        _PlayerRigidbody.AddForce(movement * Speed);
    }
}
   