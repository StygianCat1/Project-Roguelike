using UnityEngine;
using TMPro;
public class S_CountingScore : MonoBehaviour
{
     
    public TMP_Text scoreText;
    public int currentScore = 0;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = " X " + currentScore.ToString();  
    }

    public void PointsKillEnemies()
    {
        currentScore += 750;
    }

    public void PointsPunchEnemies()
    {
        currentScore += 100;
    }
}
