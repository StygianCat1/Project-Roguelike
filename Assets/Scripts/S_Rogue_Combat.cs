using UnityEngine;

public class S_Rogue_Combat : MonoBehaviour
{
    private S_HP_Component _characterHealthRef;
    private S_HP_Component _targetHealthRef;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _characterHealthRef = this.GetComponent<S_HP_Component>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
