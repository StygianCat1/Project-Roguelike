using UnityEngine;
using TMPro;
public class S_CountingKey : MonoBehaviour
{
      
    public TMP_Text keyText;
    public static S_CountingKey instance;
    public int currentKey = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        keyText.text = "X " + currentKey.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        keyText.text = currentKey.ToString();  
    }

    public void IncreaseKey()
    {
        currentKey += 1;
        keyText.text = "X " + currentKey.ToString();
    }
}
