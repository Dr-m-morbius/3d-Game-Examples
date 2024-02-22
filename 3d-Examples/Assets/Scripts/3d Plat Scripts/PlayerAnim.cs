using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

     private Playermove _playermove;
     private Animator _playeranimator;
    // Start is called before the first frame update
    void Start()
    {
        _playermove = GameObject.Find("player").GetComponent<Playermove>();
        _playeranimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal) > 0 || Math.Abs(vertical) >0)
        {
            _playeranimator.SetBool("IsWalking", true);
        }
        else
        {
            _playeranimator.SetBool("IsWalking", false);
        }

        if(_playermove.IsPlayerOnGround())
        {
            _playeranimator.SetBool("IsOnGround", true);
        }
        else
        {
            _playeranimator.SetBool("IsOnGround", false);
        }
    }
}
