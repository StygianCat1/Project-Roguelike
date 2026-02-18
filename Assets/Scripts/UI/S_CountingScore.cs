using UnityEngine;
using TMPro;
public class S_CountingScore : MonoBehaviour
{
     
    public TMP_Text scoreText;
    public static S_CountingScore instance;
    public int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "X " + currentScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        scoreText.text = currentScore.ToString();  
    }

    public void PointsKillEnemies()
    {
        currentScore += 750;
        scoreText.text = "X " + currentScore.ToString();
    }

    public void PointsPunchEnemies()
    {
        currentScore += 500;
        scoreText.text = "X " + currentScore.ToString();
    }

    public void PointsPerks()
    {
        currentScore += 1000;
        scoreText.text = "X " + currentScore.ToString();
    }
}
