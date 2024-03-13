using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100; // ���ʹ�٧�ش�ͧ Player
    private float currentHealth; // ���ʹ�Ѩ�غѹ�ͧ Player
    public   bool isDead = false; // ��������͵�Ǩ�ͺ��� Player ����������

  
    public GameController gameController;

    [Header("HP Bar")]

    public RectTransform uiTransform;
    public float lerpSpeed = 5f;


    void Start()
    {
        currentHealth = maxHealth; // ��駤�����ʹ������������ҡѺ���ʹ�٧�ش
    }

    void Update()
    {
        UpdateUI();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ��� Player ���Ѻ Enemy ���Ŵ���ʹ
            TakeDamage(20); // Ŵ���ʹ���� ... ˹��� 
        }
    }

    // �ѧ��ѹ������Ŵ���ʹ
    void TakeDamage(int damage)
    {
        currentHealth -= damage; // Ŵ���ʹ�������������·���к�
       

        if (currentHealth <= 0)
        {
           
           
                isDead = true;
                Die(); // ������ʹŴŧ����� 0 player �е��

                      
               
           
        }
    }

  

    // �ѧ��ѹ������¡����� Player ���
    void Die()
    {
        // ����� GameController ��Һ��Ҽ����蹵������
        gameController.PlayerDied();

            Invoke("Respawn", 5f);   // ���¡�ѧ��ѹ Respawn ��ѧ�ҡ��ҹ� 5 �Թҷ�

            gameObject.SetActive(false);
    }
  
    void UpdateUI()
    {
        // ��Ѻ��� scale Y �ͧ UI ���������ʹ
        float scaleFactorY = currentHealth / maxHealth; // ��Ѻ scale Y �������㹪�ǧ 0-1
        float targetScaleY = Mathf.Lerp(uiTransform.localScale.y, scaleFactorY, Time.deltaTime * lerpSpeed);
        uiTransform.localScale = new Vector3(uiTransform.localScale.x, targetScaleY, uiTransform.localScale.z);
    }
}