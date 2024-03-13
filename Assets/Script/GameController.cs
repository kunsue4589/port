using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [Header("ScoreManager")] 
    public TextMeshProUGUI scoreText;
    private int score = 0;



    [Header("EnemySpawner")] 
    public GameObject enemyPrefab;
    public GameObject playerPrefab; // เพิ่มตัวแปรเก็บ prefab ของ player
    public float spawnInterval = 1f;
    float circleRadius = 10f;  // รัศมีของวงกลม


    public GameObject gameOverPanel;




    private bool playerIsActive = true;

    void Start()
    {
       
        Time.timeScale = 1f;

        StartCoroutine(SpawnEnemies());
        UpdateScoreUI();
        // ปิด UI Game Over
        gameOverPanel.SetActive(false);

    }

    void Update()
    {
        


        

    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // รอเวลาตาม spawnInterval
            yield return new WaitForSeconds(spawnInterval);

            Vector2 circleCenter = new Vector2(0f, 0f);  // ตำแหน่งศูนย์กลางของวงกลม

            Vector2 newPosition = new Vector2(Random.Range(-11f, 11f), Random.Range(-12f, 12f));

            while (Vector2.Distance(newPosition, circleCenter) <= circleRadius)
            {
                newPosition = new Vector2(Random.Range(0f, 10f), Random.Range(0f, 10f));
            }

            // ตรวจสอบว่า player ยัง activate อยู่หรือไม่
            if (playerIsActive)
            {
                // Instantiate โดยกำหนด Prefab, ตำแหน่ง, และการหมุน
                GameObject spawnedObject = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
            }

          
        }
    }

    // ฟังก์ชันที่จะถูกเรียกเมื่อ player หายไป
    public void PlayerDied()
    {
        playerIsActive = false;

        // ลบ prefab Enemy ทั้งหมด
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

     

        ShowGameOver();

        // หยุดเวลา
        Time.timeScale = 0f;

    }

   


    // เรียกใช้เมื่อต้องการเปิด UI Game Over
    public void ShowGameOver()
    {
        // เปิด UI Game Over
        gameOverPanel.SetActive(true);
    }

  

}