using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
  
    // สร้างฟังก์ชั่นที่จะถูกเรียกเมื่อคลิกปุ่ม
    public void RetryButton()
    {
        // โหลด Scene ที่ระบุ
        SceneManager.LoadScene("Shooter");
    }

    public void ExitButton()
    {
        // โหลด Scene ที่ระบุ
        SceneManager.LoadScene("Lobby");
    }
    public void StartButton()
    {
        // โหลด Scene ที่ระบุ
        SceneManager.LoadScene("Shooter");
    }
    public void QuitButton()
    {
        // ออกจากเกม
        Application.Quit();
    }
   
}