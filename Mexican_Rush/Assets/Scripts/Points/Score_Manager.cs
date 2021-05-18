using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score_Manager : MonoBehaviour
{
    public static Score_Manager instance;

    public Text ScorePoints;//—четчик очков
    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        ScorePoints.text = score.ToString() + " Score";
    }

    #region ћетоды на очки
    public void Add10Point()
    {
        score+=10;
        ScorePoints.text = score.ToString() + " Score";
    }
    public void Add25Point()
    {
        score += 25;
        ScorePoints.text = score.ToString() + " Score";
    }
    public void Add50Point()
    {
        score += 50;
        ScorePoints.text = score.ToString() + " Score";
    }
    #endregion
}
