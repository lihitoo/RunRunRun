using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float limitValue;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
        playerTransform.localPosition += new Vector3(0, 0, speed * Time.deltaTime );
    }

    private void Move()
    {
        float halfScreeen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreeen) / halfScreeen;
        float finalXPos = Mathf.Clamp(xPos * limitValue, -limitValue, limitValue);
        playerTransform.localPosition = new Vector3(finalXPos, playerTransform.position.y, playerTransform.position.z);
        Debug.Log(xPos);
        Debug.Log(playerTransform.localPosition);
    }

    
}
