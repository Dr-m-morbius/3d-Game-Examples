using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody _PlayerRigidbody;
    public float Gravity = 1f;
     public bool IsOnGround = true;
    public float JumpForce = 10f;
    public float RotationSpeed = 45f;

    private float _verticalinput;
    private float _horizontalinput;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerRigidbody = GetComponent<Rigidbody>();
    Physics.gravity *= Gravity;
    }

    // Update is called once per frame
    void Update()
    {
    
        _verticalinput = Input.GetAxis("Vertical");
        _horizontalinput = Input.GetAxis("Horizontal"); 

        transform.Translate(Vector3.forward * speed * _verticalinput * Time.deltaTime);

        transform.Rotate(Vector3.up, RotationSpeed * _horizontalinput * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround ) 
        {
            _PlayerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            
        }
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
    }
}