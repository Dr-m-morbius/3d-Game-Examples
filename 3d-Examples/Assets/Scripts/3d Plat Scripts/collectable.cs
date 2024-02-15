using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
    {
        if (other.gameObject.CompareTag("player")) 
        {
              GameObject.Find("Canvas").GetComponent<Ui>().UpdateCoinCount();
            Debug.Log("player collected a coin");
            Destroy(gameObject);
        }
    }
}}

