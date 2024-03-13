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
    public GameObject playerPrefab; // ����������� prefab �ͧ player
    public float spawnInterval = 1f;
    float circleRadius = 10f;  // ����բͧǧ���


    public GameObject gameOverPanel;




    private bool playerIsActive = true;

    void Start()
    {
       
        Time.timeScale = 1f;

        StartCoroutine(SpawnEnemies());
        UpdateScoreUI();
        // �Դ UI Game Over
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
            // �����ҵ�� spawnInterval
            yield return new WaitForSeconds(spawnInterval);

            Vector2 circleCenter = new Vector2(0f, 0f);  // ���˹��ٹ���ҧ�ͧǧ���

            Vector2 newPosition = new Vector2(Random.Range(-11f, 11f), Random.Range(-12f, 12f));

            while (Vector2.Distance(newPosition, circleCenter) <= circleRadius)
            {
                newPosition = new Vector2(Random.Range(0f, 10f), Random.Range(0f, 10f));
            }

            // ��Ǩ�ͺ��� player �ѧ activate �����������
            if (playerIsActive)
            {
                // Instantiate �¡�˹� Prefab, ���˹�, ��С����ع
                GameObject spawnedObject = Instantiate(enemyPrefab, newPosition, Quaternion.identity);
            }

          
        }
    }

    // �ѧ��ѹ���ж١���¡����� player ����
    public void PlayerDied()
    {
        playerIsActive = false;

        // ź prefab Enemy ������
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

     

        ShowGameOver();

        // ��ش����
        Time.timeScale = 0f;

    }

   


    // ���¡������͵�ͧ����Դ UI Game Over
    public void ShowGameOver()
    {
        // �Դ UI Game Over
        gameOverPanel.SetActive(true);
    }

  

}