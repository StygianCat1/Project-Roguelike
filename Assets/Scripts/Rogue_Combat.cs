using UnityEngine;

public class Rogue_Combat : MonoBehaviour
{
    private HP_Component _characterHealthRef;
    private HP_Component _targetHealthRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _characterHealthRef = this.GetComponent<HP_Component>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
