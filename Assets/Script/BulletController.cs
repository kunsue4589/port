using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // �������Ǣͧ����ع
    public float bulletSpeed = 10f;
    public float destroyTime = 2f;
    public int damage = 1;
    // ��ȷҧ�ͧ����ع
    private Vector2 bulletDirection;


    private void Start()
    {
        StartCoroutine(DestroyBullet());
    }
    void Update()
    {
        // ����͹������ع�����ȷҧ����˹�
        transform.Translate(bulletDirection * bulletSpeed * Time.deltaTime);

       
       
    }
    IEnumerator DestroyBullet() 
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }

    // ��駤�ҷ�ȷҧ�ͧ����ع
    public void SetDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized;
    }

  
  
    void OnTriggerEnter2D(Collider2D other)
    {
        // ����� Bullet ���Ѻ Enemy �������
        if (other.CompareTag("Enemy"))
        {
            // �֧ Component �ͧ Enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // ��Ǩ�ͺ��� EnemyHealth ����� null
            if (enemyHealth != null)
            {
                // ����� Enemy
                enemyHealth.TakeDamage(damage);
            }

            // ����� Bullet ����ͪ��Ѻ Enemy
            Destroy(gameObject);
        }
    }


}
