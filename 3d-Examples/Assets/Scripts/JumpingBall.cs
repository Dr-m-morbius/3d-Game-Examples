using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpingBall : MonoBehaviour
{
    public float JumpForce = 10f;
    public float bounds = -10;
    public float Gravity = 1f;
    public bool IsOnGround = true;
    private float _horozontalinput; 
    private float _forwardinput;
    public float Speed = 10f;
    private Rigidbody _PlayerRigidbody;
    private Vector3 _StartPos;

    // Start is called before the first frame update
    void Start()
    {
    _StartPos = transform.position;
    _PlayerRigidbody = GetComponent<Rigidbody>();
    Physics.gravity *= Gravity;
    }

    // Update is called once per frame
    void Update()
    {
        _horozontalinput = Input.GetAxis("Horizontal");
        _forwardinput = Input.GetAxis("Vertical");
         if (Input.GetKeyDown(KeyCode.Space) && IsOnGround ) 
        {
            _PlayerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            
        }
        if(transform.position.y < bounds)
        {
            transform.position = _StartPos;
        }
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horozontalinput, 0.0f, _forwardinput);
        _PlayerRigidbody.AddForce(movement * Speed);
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    } 
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            _StartPos = other.gameObject.transform.position;
        }
    }
}
     