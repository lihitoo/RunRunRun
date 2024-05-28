using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float spinningSpeed = 120f;

    void Start()
    {
        // Lưu vị trí ban đầu
    }

    void Update()
    {
        // Tính toán vị trí mới sử dụng hàm PingPong
        transform.Rotate(Vector3.up, spinningSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController.points++;
            Destroy(gameObject);
            //Debug.Log("Destroyed");
            Debug.Log(PlayerController.points);
        }
    }
}
