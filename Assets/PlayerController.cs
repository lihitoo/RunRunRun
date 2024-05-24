using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float halfScreeen = Screen.width / 2;
    [SerializeField] private Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    private void Move()
    {
        float xPos = (Input.mousePosition.x - halfScreeen) / halfScreeen;
        playerTransform.localPosition += new Vector3(xPos, 1, 0);
    }

    
}
