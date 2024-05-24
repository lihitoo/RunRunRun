using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
            //Debug.Log(0);
        }
    }

    private void Move()
    {
        float halfScreeen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreeen) / halfScreeen;
        playerTransform.localPosition = new Vector3(xPos*9, 2, 0);
        Debug.Log(xPos);
        Debug.Log(playerTransform.localPosition);
    }

    
}
