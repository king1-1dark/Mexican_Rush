using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_Over : MonoBehaviour
{
    public void Start()
    {
       
        Time.timeScale = 1;
    }
    
    public void ChangeScene(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
