using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController characterController;
    [SerializeField] private float forwardSpeed;
    private Vector3 targetPos = Vector3.zero;
    private int desiredLane = 1;
    public float laneDistance = 5f;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }
        targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPos += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);


    }
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, forwardSpeed)*Time.fixedDeltaTime;
        
    }

}
