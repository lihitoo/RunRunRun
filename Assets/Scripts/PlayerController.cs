using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    //public CapsuleCollider capsuleCollider;
    public BoxCollider boxCollider;
    CharacterController characterController;
    [SerializeField] private float forwardSpeed;
    private Vector3 targetPos = Vector3.zero;
    private int desiredLane = 1;
    public float laneDistance = 5f;
    public float jumpForce = 5f;
    private Vector3 colliderSize;
    Animator animator;
    Rigidbody rb;
    public static int points = 0;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //capsuleCollider = GetComponent<CapsuleCollider>();
        colliderSize = boxCollider.size;
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {

    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || SwipeController.swipeRight)
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || SwipeController.swipeLeft)
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }

        }
        targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;
        //targetPos = transform.position;
        if (desiredLane == 0)
        {
            targetPos += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPos += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPos, 5 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) || SwipeController.swipeUp)
        {
            if (!animator.GetBool("isJumping") && !animator.GetBool("isRolling"))
            {
                StartCoroutine(Jump());
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || SwipeController.swipeDown)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            if (!animator.GetBool("isJumping") && !animator.GetBool("isRolling"))
            {
                StartCoroutine(Roll());
                colliderDown();
                Invoke("colliderReset", 2f);
            }
        }

    }
    private void colliderDown()
    {
        if(boxCollider.size == colliderSize)
        {
            boxCollider.size = boxCollider.size + (Vector3.down / 2);
        }
    }
    private void colliderReset()
    {
        boxCollider.size = colliderSize;
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, forwardSpeed)*Time.fixedDeltaTime;
        
    }
    private IEnumerator Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetBool("isJumping", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("isJumping", false);
    }
    private IEnumerator Roll()
    {
        animator.SetBool("isRolling",true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("isRolling", false);
    }
}
