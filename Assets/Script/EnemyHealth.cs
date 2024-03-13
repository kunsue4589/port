using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;  // เลือดสูงสุดของ Enemy
    private int currentHealth;  // เลือดปัจจุบันของ Enemy

    public int points = 1;  //แต้เมที่จะได้รับ
    public GameController scoreManager;

    void Start()
    {
        currentHealth = maxHealth;  // ตั้งค่าเป็นเลือดสูงสุด
        scoreManager = GameObject.FindObjectOfType<GameController>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // ลดเลือดตามความเสียหายที่รับ

        if (currentHealth <= 0)
        {
            Die();  // ถ้าเลือดเป็น 0 หรือต่ำกว่า, เรียกฟังก์ชัน Die
        }
    }

    void Die()
    {
        scoreManager.AddScore(points);  //เพิ่มแต้ม
        Destroy(this.gameObject);    //ทำลายยยยย
    }
}
