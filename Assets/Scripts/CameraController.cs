using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, target.position.z - offset.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 10 * Time.deltaTime);
    }
}
