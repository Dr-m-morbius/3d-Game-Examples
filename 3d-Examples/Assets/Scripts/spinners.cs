using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinners : MonoBehaviour
{
    public float rotate = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.forward, rotate * Time.deltaTime);
    }
}
