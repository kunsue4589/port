using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float speed = 5f;  // ความเร็วของ Enemy
    private Transform player;  // Transform ของ Player
    private Rigidbody2D rb;  // Rigidbody2D ของ Enemy
    public float rotationSpeed = 5f;  // ความเร็วในการหมุน


    void Start()
    {


        rb = GetComponent<Rigidbody2D>();  // ดึงค่า Rigidbody2D 

    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // หา Transform ของ Player
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // คำนวณทิศทางที่ Enemy จะเคลื่อนที่ไป
        Vector2 direction = player.position - transform.position;
        direction.Normalize();  // ทำให้ความยาวของ Vector เท่ากับ 1

        // เคลื่อนที่ Enemy ในทิศทางที่คำนวณได้
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

        // หมุนหน้าเข้าหา Player 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = Mathf.LerpAngle(rb.rotation, angle + 270, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(currentAngle);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ถ้า Enemy โดน Player ให้เรียกฟังก์ชัน "suicide"
            Suicide();
        }
    }


    void Suicide()
    {
        //  ทำลาย Enemy เมื่อโดน Player 
        Destroy(this.gameObject);
    }
}
