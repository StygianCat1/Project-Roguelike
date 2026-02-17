using UnityEngine;

public class S_MerchantInteractible : MonoBehaviour
{
    [SerializeField] private GameObject _merchantUi;
    
    public void ShowMerchantUi()
    {
        Instantiate(_merchantUi);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCharacter")
        {
            other.GetComponent<S_CharacterCollisionHandler>().merchantInteractionRef = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCharacter")
        {
            other.GetComponent<S_CharacterCollisionHandler>().merchantInteractionRef = null;
        }
    }
}
