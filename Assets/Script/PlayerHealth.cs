using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100; // เลือดสูงสุดของ Player
    private float currentHealth; // เลือดปัจจุบันของ Player
    public   bool isDead = false; // ตัวแปรเพื่อตรวจสอบว่า Player ตายหรือไม่

  
    public GameController gameController;

    [Header("HP Bar")]

    public RectTransform uiTransform;
    public float lerpSpeed = 5f;


    void Start()
    {
        currentHealth = maxHealth; // ตั้งค่าเลือดเริ่มต้นให้เท่ากับเลือดสูงสุด
    }

    void Update()
    {
        UpdateUI();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ถ้า Player ชนกับ Enemy ให้ลดเลือด
            TakeDamage(20); // ลดเลือดทีละ ... หน่วย 
        }
    }

    // ฟังก์ชันที่ให้ลดเลือด
    void TakeDamage(int damage)
    {
        currentHealth -= damage; // ลดเลือดตามความเสียหายที่ระบุ
       

        if (currentHealth <= 0)
        {
           
           
                isDead = true;
                Die(); // ถ้าเลือดลดลงเหลือ 0 player จะตาย

                      
               
           
        }
    }

  

    // ฟังก์ชันที่เรียกเมื่อ Player ตาย
    void Die()
    {
        // แจ้งให้ GameController ทราบว่าผู้เล่นตายแล้ว
        gameController.PlayerDied();

            Invoke("Respawn", 5f);   // เรียกฟังก์ชัน Respawn หลังจากผ่านไป 5 วินาที

            gameObject.SetActive(false);
    }
  
    void UpdateUI()
    {
        // ปรับค่า scale Y ของ UI ตามค่าเลือด
        float scaleFactorY = currentHealth / maxHealth; // ปรับ scale Y ให้อยู่ในช่วง 0-1
        float targetScaleY = Mathf.Lerp(uiTransform.localScale.y, scaleFactorY, Time.deltaTime * lerpSpeed);
        uiTransform.localScale = new Vector3(uiTransform.localScale.x, targetScaleY, uiTransform.localScale.z);
    }
}