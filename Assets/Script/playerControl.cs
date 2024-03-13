using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class playerControl : MonoBehaviour
{   
    //���§�׹
    public AudioSource gunSound;

    //�Ǻ����������ǡ����ع
    public float rotationSpeed = 5f;

    // ��������㹡������͹���
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
       
            // �֧���˹觢ͧ cursor ��š 2D
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;

            // ��ѧ��ѹ��ع player �����ع��� cursor
            Rotateplayer(cursorPosition);

            // ��ѧ��ѹ����͹��� player 
            MovePlayer();

            // ��Ǩ�ͺ��ä�ԡ��������
            if (Input.GetMouseButtonDown(0))
            {
                // ���ҧ Bullet ����ԧ
                ShootBullet(cursorPosition);
            }
        
    }
    void Rotateplayer(Vector3 targetPosition)
    {
        // �ӹǳ��ȷҧ��� player ���ѹ�
        Vector2 direction = targetPosition - transform.position;

        // �ӹǳ��������ع
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ��ع player 价��������ӹǳ�� ���� Quaternion.Slerp
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f,270+ angle), rotationSpeed * Time.deltaTime);
    }

    // �ѧ��ѹ����͹��� player 
    void MovePlayer()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // ����������������������͡� W+A ���� S+D

        // �ӹǳ���˹�����ͧ player
        Vector3 newPosition = transform.position + new Vector3(movement.x, movement.y, 0f) * movementSpeed * Time.deltaTime;

        // ��˹���� player �������͹���仹͡�ͺࢵ��
        newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);
        newPosition.y = Mathf.Clamp(newPosition.y, -4f, 4f);

        // ��駤�ҵ��˹�����ͧ player
        transform.position = newPosition;
    }
    void ShootBullet(Vector3 targetPosition)
    {

        // ���˹�������鹢ͧ����ع (���˹觢ͧ Player)
        Vector3 spawnPosition = transform.position;

      

        // ���ҧ Bullet �ҡ Prefab
        GameObject bullet = Instantiate(bulletPrefab, (transform.position), Quaternion.identity);

        // ��駤�ҷ�ȷҧ�ͧ Bullet ����繷�ȷҧ价�� cursor
        Vector2 direction = targetPosition - transform.position;
        bullet.GetComponent<BulletController>().SetDirection(direction);

        // ��Ǩ�ͺ��� AudioSource �١�Դ�������
        if (gunSound != null)
        {
            gunSound.Play();
        }

    }

}
