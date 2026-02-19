using UnityEngine;
using TMPro;
public class S_CountingCards : MonoBehaviour
{
    public TMP_Text cardsText;
    public int currentCards = 0;
    
    private S_Resources _resources;


    private void Start()
    {
        _resources = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<S_Resources>();
    }
    
    // Update is called once per frame
    void Update()
    {
        currentCards = _resources._resourcesOutGame;
        cardsText.text = " X " + currentCards.ToString();  
    }
}
