using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeOneMovement : MonoBehaviour
{
    public float speed = 5f;
    public float RotationSpeed = 45f;

    private float _verticalinput;
    private float _horizontalinput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        _verticalinput = Input.GetAxis("Vertical");
        _horizontalinput = Input.GetAxis("Horizontal"); 

        transform.Translate(Vector3.forward * speed * _verticalinput * Time.deltaTime);

        transform.Rotate(Vector3.up, RotationSpeed * _horizontalinput * Time.deltaTime);
    }
}