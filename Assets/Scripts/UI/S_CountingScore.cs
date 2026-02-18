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

    public void IncreaseCoins(int v)
    {
        currentScore += v;
        scoreText.text = "SCORE :  " + currentScore.ToString();
    }
}
