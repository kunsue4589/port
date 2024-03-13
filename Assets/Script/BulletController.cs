using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // ความเร็วของกระสุน
    public float bulletSpeed = 10f;
    public float destroyTime = 2f;
    public int damage = 1;
    // ทิศทางของกระสุน
    private Vector2 bulletDirection;


    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    void Update()
    {
        // เคลื่อนที่กระสุนตามทิศทางที่กำหนด
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);

       
       
    }
    IEnumerator DestroyBullet() 
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }

    // ตั้งค่าทิศทางของกระสุน
    public void SetDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized;
    }

  
  
    void OnTriggerEnter2D(Collider2D other)
    {
        // เช็คว่า Bullet ชนกับ Enemy หรือไม่
        if (other.CompareTag("Enemy"))
        {
            // ดึง Component ของ Enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // ตรวจสอบว่า EnemyHealth ไม่เป็น null
            if (enemyHealth != null)
            {
                // ทำลาย Enemy
                enemyHealth.TakeDamage(damage);
            }

            // ทำลาย Bullet เมื่อชนกับ Enemy
            Destroy(gameObject);
        }
    }


}
