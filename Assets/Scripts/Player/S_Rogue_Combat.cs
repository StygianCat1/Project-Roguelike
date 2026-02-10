using System.Collections.Generic;
using UnityEngine;

public class S_Rogue_Combat : MonoBehaviour
{
    private S_HP_Component _characterHealthRef;
    private S_HP_Component _targetHealthRef;
    private S_Rogue_Inputs _inputsManager;
    [SerializeField] List<Collider> _attackHitBoxes;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _characterHealthRef = GetComponent<S_HP_Component>();
        _inputsManager = GetComponent<S_Rogue_Inputs>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
