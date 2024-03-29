using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playermove : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float turnSpeed = 20f;
    public float Gravity = 1f;
     public bool IsOnGround = true;
     public bool IsWalking;
     public bool life = true;
    public float JumpForce = 10f;
    public int _life = 3;
    private Vector3 startpos;
    public Vector3 floorOne;
    public Vector3 floorTwo;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
            
    Physics.gravity *= Gravity;
     m_Rigidbody = GetComponent<Rigidbody> ();
    startpos = transform.position;
    floorOne = GameObject.Find("F1s").transform.position;
    floorTwo = GameObject.Find("F2s").transform.position;
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
      private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }
        if (collision.gameObject.CompareTag("DeadZone"))
        { 
            transform.position = startpos;
        }
        if (collision.gameObject.CompareTag("floor 1"))
        {
            transform.position = floorOne;
        }
        if (collision.gameObject.CompareTag("floor 2"))
        {
            transform.position = floorTwo;
        }
        if (collision.gameObject.CompareTag("Game End"))
        {
            SceneManager.LoadScene (0);
        }
    } 

    public bool IsPlayerOnGround() 
    {
        return IsOnGround;
    }
}

    
 