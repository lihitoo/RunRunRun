using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraHolder : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    Vector3 offset;
    private void Awake()
    {
        offset = transform.position - playerTransform.position;
        //offset.x = 0 ;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerTransform.position.z + offset.z);
        //transform.eulerAngles = new Vector3(playerTransform.eulerAngles.x, playerTransform.eulerAngles.y, 0);
    }
}
