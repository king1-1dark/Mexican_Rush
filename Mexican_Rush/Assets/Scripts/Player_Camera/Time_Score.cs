using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Time_Score : MonoBehaviour
{
    
    public float time;
    public Text Timer,HighScore;
    public GameObject Restart;
    // Start is called before the first frame update
    void Start()
    {
        Timer.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(time >0)
        {
            Restart.SetActive(false);
            time -= Time.deltaTime;
            Timer.text = Mathf.Round(time).ToString();
            HighScore.text = Score_Manager.instance.ScorePoints.text;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Timer.text = "Time`s UP";
            Restart.SetActive(true);
        }
        
    }
}
