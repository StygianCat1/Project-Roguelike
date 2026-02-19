using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_CountingCoins : MonoBehaviour
{
    
    public TMP_Text coinText;
    public int currentCoins = 0;
    
    private S_Resources _resources;

    private void Start()
    {
        _resources = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<S_Resources>();
    }

    // Update is called once per frame
    private void Update()
    {
        currentCoins = _resources._resourcesInGame;
        coinText.text = " X " + currentCoins.ToString();  
    }
}
