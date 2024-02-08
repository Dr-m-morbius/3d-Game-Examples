using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class JumpingBall : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public float JumpForce = 10f;
    public int score = 0;
    public float bounds = -10;
    public float Gravity = 1f;
    public bool IsOnGround = true;
    private float _horozontalinput; 
    private float _forwardinput;
    public float Speed = 10f;
    private Rigidbody _PlayerRigidbody;
    private Vector3 _StartPos;
    private bool IsAtCheckpoint = false;
    public Vector3 _CheckPos;

    // Start is called before the first frame update
    void Start()
    {
    _StartPos = transform.position;
    _PlayerRigidbody = GetComponent<Rigidbody>();
    Physics.gravity *= Gravity;
    scoretext.text = "Score: " + score.ToString();
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
            if(IsAtCheckpoint)
            {
                transform.position = _CheckPos;
            }
            else
            {
                transform.position = _StartPos; 
            }
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
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            if(IsAtCheckpoint)
            {
                transform.position = _CheckPos;
            }
            else
            {
                transform.position = _StartPos; 
            } 
        }
    } 
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            IsAtCheckpoint = true;
            _CheckPos = other.gameObject.transform.position;
        }

         if(other.gameObject.CompareTag("End"))
        {
            IsAtCheckpoint = false;
            transform.position = _StartPos;
        }
        if(other.gameObject.CompareTag("Collect"))
        {
         
            score++; 
              scoretext.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }
    }
   
}
     