using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
  
    // ���ҧ�ѧ���蹷��ж١���¡����ͤ�ԡ����
    public void RetryButton()
    {
        // ��Ŵ Scene ����к�
        SceneManager.LoadScene("Shooter");
    }

    public void ExitButton()
    {
        // ��Ŵ Scene ����к�
        SceneManager.LoadScene("Lobby");
    }
    public void StartButton()
    {
        // ��Ŵ Scene ����к�
        SceneManager.LoadScene("Shooter");
    }
    public void QuitButton()
    {
        // �͡�ҡ��
        Application.Quit();
    }
   
}