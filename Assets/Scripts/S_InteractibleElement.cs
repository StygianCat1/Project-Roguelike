using UnityEngine;

public class S_InteractibleElement : MonoBehaviour
{
    [System.Serializable]
    private enum TypeOfInteractibleElement
    {
        Bar,
        GamblingMachine,
        VendingMachine
    }
    
    [SerializeField] private TypeOfInteractibleElement _type;
    
    [SerializeField] private GameObject _barUi;
    [SerializeField] private GameObject _vendingMachineUi;
    [SerializeField] private GameObject _gamblingMachineUi;

    public void LaunchInteraction()
    {
        if (_type == TypeOfInteractibleElement.Bar)
        {
            Bar();
            return;
        }

        if (_type == TypeOfInteractibleElement.GamblingMachine)
        {
            GamblingMachine();
            return;
        }

        if (_type == TypeOfInteractibleElement.VendingMachine)
        {
            VendingMachine();
        }
    }

    private void Bar()
    {
        Instantiate(_barUi);
    }

    private void GamblingMachine()
    {
        Instantiate(_gamblingMachineUi);
    }

    private void VendingMachine()
    {
        Instantiate(_vendingMachineUi);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCharacter")
        {
            other.GetComponent<S_CharacterCollisionHandler>().interactibleElementRef = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainCharacter")
        {
            other.GetComponent<S_CharacterCollisionHandler>().interactibleElementRef = null;
        }
    }
}
