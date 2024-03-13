using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;  // ���ʹ�٧�ش�ͧ Enemy
    private int currentHealth;  // ���ʹ�Ѩ�غѹ�ͧ Enemy

    public int points = 1;  //�����������Ѻ
    public GameController scoreManager;

    void Start()
    {
        currentHealth = maxHealth;  // ��駤�������ʹ�٧�ش
        scoreManager = GameObject.FindObjectOfType<GameController>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Ŵ���ʹ�������������·���Ѻ

        if (currentHealth <= 0)
        {
            Die();  // ������ʹ�� 0 ���͵�ӡ���, ���¡�ѧ��ѹ Die
        }
    }

    void Die()
    {
        scoreManager.AddScore(points);  //�������
        Destroy(this.gameObject);    //���������
    }
}
