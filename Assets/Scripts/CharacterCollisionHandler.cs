using System;
using UnityEngine;

public class CharacterCollisionHandler : MonoBehaviour
{
    
    private Rogue_Inputs _inputsManager;
    private Rogue_Combat _rogueCombat;
    
    public Teleporter teleporterRef;

    private void Start()
    {
        _inputsManager = GetComponentInParent<Rogue_Inputs>();
    }

    private void Update()
    {
        if (_inputsManager.interact)
        {
            if (teleporterRef != null && teleporterRef.tpLocation != null)
            {
                transform.position = teleporterRef.tpLocation.transform.position;
                return;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
