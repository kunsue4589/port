using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class playerControl : MonoBehaviour
{   
    //เสียงปืน
    public AudioSource gunSound;

    //ควบคุมความเร็วการหมุน
    public float rotationSpeed = 5f;

    // ความเร็วในการเคลื่อนที่
    public float movementSpeed = 5f;

    
    public GameObject bulletPrefab;

  

    // Start is called before the first frame update
    void Start()
    {
        gunSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
            // ดึงตำแหน่งของ cursor ในโลก 2D
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;

            // ใช้ฟังก์ชันหมุน player ให้หมุนตาม cursor
            Rotateplayer(cursorPosition);

            // ใช้ฟังก์ชันเคลื่อนที่ player 
            MovePlayer();

            // ตรวจสอบการคลิกเมาส์ซ้าย
            if (Input.GetMouseButtonDown(0))
            {
                // สร้าง Bullet และยิง
                ShootBullet(cursorPosition);
            }
        
    }
    void Rotateplayer(Vector3 targetPosition)
    {
        // คำนวณทิศทางที่ player จะหันไป
        Vector2 direction = targetPosition - transform.position;

        // คำนวณมุมการหมุน
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // หมุน player ไปที่มุมที่คำนวณได้ โดยใช้ Quaternion.Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f,270+ angle), rotationSpeed * Time.deltaTime);
    }

    // ฟังก์ชันเคลื่อนที่ player 
    void MovePlayer()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // ทำให้ความเร็วเท่าเดิมเมื่อกด W+A หรือ S+D

        // คำนวณตำแหน่งใหม่ของ player
        Vector3 newPosition = transform.position + new Vector3(movement.x, movement.y, 0f) * movementSpeed * Time.deltaTime;

        // กำหนดให้ player ไม่เคลื่อนที่ไปนอกขอบเขตจอ
        newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

        // ตั้งค่าตำแหน่งใหม่ของ player
        transform.position = newPosition;
    }
    void ShootBullet(Vector3 targetPosition)
    {

        // ตำแหน่งเริ่มต้นของกระสุน (ตำแหน่งของ Player)
        Vector3 spawnPosition = transform.position;

      

        // สร้าง Bullet จาก Prefab
        GameObject bullet = Instantiate(bulletPrefab, (transform.position), Quaternion.identity);

        // ตั้งค่าทิศทางของ Bullet ให้เป็นทิศทางไปที่ cursor
        Vector2 direction = targetPosition - transform.position;
        bullet.GetComponent<BulletController>().SetDirection(direction);

        // ตรวจสอบว่า AudioSource ถูกเปิดหรือไม่
        if (gunSound != null)
        {
            gunSound.Play();
        }

    }

}
