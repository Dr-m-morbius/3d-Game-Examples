using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    public Transform Target;

    private Vector3 _offset;
    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
   
        transform.position = Target.transform.position + _offset;
    }
}

