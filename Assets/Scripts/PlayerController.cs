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
        transform.position = Vector3.Lerp(transform.position, targetPos, 10 * Time.deltaTime);
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


        if (isColliding)
        {
            collisionTime += Time.deltaTime;

            Debug.Log(collisionTime);
            if (collisionTime >= requiredCollisionTime)
            {
                
                LoseGame();
            }
        }
        else
        {
            
            collisionTime = 0f; // Reset thời gian va chạm nếu không còn va chạm
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
        yield return new WaitForSeconds(1f);
        animator.SetBool("isJumping", false);
    }
    private IEnumerator Roll()
    {
        animator.SetBool("isRolling",true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("isRolling", false);
    }
    

    

   /* private IEnumerator CheckLoseCondition(Collision collision)
    {
        yield return new WaitForSeconds(2f); // Wait for 3 seconds
        //if(collision.gameObject.CompareTag("Respawn"))
        {
          //  LoseGame();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            StartCoroutine(CheckLoseCondition(collision));
            void OnCollisionEnter(Collision col)
            {
                if (collision.gameObject.CompareTag("Respawn"))
                    LoseGame();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }*/
    private float collisionTime = 0f;
    private float requiredCollisionTime = 2f; // Thời gian cần thiết để thua cuộc
    private bool isColliding = false;
    string name;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            isColliding = true;
            name = collision.gameObject.name;
            Debug.Log("cham");
        }
        
    }

    private void OnCollisionExit(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Respawn"))
        {
            isColliding = false;
            //name = collision.gameObject.name;
            Debug.Log("thoat cham");
        }
        
    }

    private void LoseGame()
    {
        Debug.Log("thua r cmm");
        Time.timeScale = 0;
        
        
    }
}

