﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScalpelWithKeys : MonoBehaviour
{

    [SerializeField]
    private float speed = 1;

    //y axis
    public KeyCode pressUp; 
    public KeyCode pressDown;
    //x axis
    public KeyCode pressLeft;
    public KeyCode pressRight;
    //z axis
    public KeyCode pressBackward;
    public KeyCode pressForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(pressUp))
        {
            Vector3 objectPosition = transform.position;
            objectPosition.y += 0.01f * speed;
            transform.position = objectPosition;
        }
        if (Input.GetKey(pressDown))
        {
            Vector3 objectPosition = transform.position;
            objectPosition.y -= 0.01f * speed;
            transform.position = objectPosition;
        }
        if (Input.GetKey(pressLeft))
        {
            Vector3 objectPosition = transform.position;
            objectPosition.x -= 0.01f * speed;
            transform.position = objectPosition;
        }
        if (Input.GetKey(pressRight))
        {
            Vector3 objectPosition = transform.position;
            objectPosition.x += 0.01f * speed;
            transform.position = objectPosition;
        }
        if (Input.GetKey(pressForward))
        {
            Vector3 objectPosition = transform.position;
            objectPosition.z -= 0.01f * speed;
            transform.position = objectPosition;
        }
        if (Input.GetKey(pressBackward))
        {
            Vector3 objectPosition = transform.position;
            objectPosition.z += 0.01f * speed;
            transform.position = objectPosition;
        }
    }
}
