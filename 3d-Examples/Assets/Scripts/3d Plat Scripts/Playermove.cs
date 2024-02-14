using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float turnSpeed = 20f;
    public float Gravity = 1f;
     public bool IsOnGround = true;
    public float JumpForce = 10f;
    
    private Vector3 startpos;

    Rigidbody m_Rigidbody;

    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
            
    Physics.gravity *= Gravity;
        m_Rigidbody = GetComponent<Rigidbody> ();
        startpos = transform.position;
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

         Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);

         m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * moveSpeed * Time.deltaTime);
        m_Rigidbody.MoveRotation (m_Rotation);


        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround ) 
        {
            m_Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
            
        }
    }

     private void OnTriggerEnter(Collider other)
     {
        
     
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        if (other.gameObject.CompareTag("DeadZone"))
        {
            transform.position = startpos; 
        } 
    }
}}

    
 