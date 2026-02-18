using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_CountingCoins : MonoBehaviour
{
    
    public TMP_Text coinText;
    public static S_CountingCoins instance;
    public int currentCoins = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        coinText.text = "X " + currentCoins.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        coinText.text = currentCoins.ToString();  
    }

    public void IncreaseCoins()
    {
        currentCoins += 1;
        coinText.text = "X " + currentCoins.ToString();
    }
}
