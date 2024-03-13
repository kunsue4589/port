using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{

    public float speed = 5f;  // �������Ǣͧ Enemy
    private Transform player;  // Transform �ͧ Player
    private Rigidbody2D rb;  // Rigidbody2D �ͧ Enemy
    public float rotationSpeed = 5f;  // ��������㹡����ع


    void Start()
    {


        rb = GetComponent<Rigidbody2D>();  // �֧��� Rigidbody2D 

    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;  // �� Transform �ͧ Player
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // �ӹǳ��ȷҧ��� Enemy ������͹����
        Vector2 direction = player.position - transform.position;
        direction.Normalize();  // ����������Ǣͧ Vector ��ҡѺ 1

        // ����͹��� Enemy 㹷�ȷҧ���ӹǳ��
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);

        // ��ع˹������� Player 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = Mathf.LerpAngle(rb.rotation, angle + 270, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(currentAngle);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��� Enemy ⴹ Player ������¡�ѧ��ѹ "suicide"
            Suicide();
        }
    }


    void Suicide()
    {
        //  ����� Enemy �����ⴹ Player 
        Destroy(this.gameObject);
    }
}
