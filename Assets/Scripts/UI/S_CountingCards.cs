using UnityEngine;
using TMPro;
public class S_CountingCards : MonoBehaviour
{
    public TMP_Text cardsText;
    public static S_CountingCards instance;
    public int currentCards = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cardsText.text = "X " + currentCards.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        cardsText.text = currentCards.ToString();  
    }

    public void IncreaseKey()
    {
        currentCards += 1;
        cardsText.text = "X " + currentCards.ToString();
    }
}
