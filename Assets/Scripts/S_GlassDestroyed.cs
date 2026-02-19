using System;
using UnityEngine;

public class S_GlassDestroyed : MonoBehaviour
{
    [SerializeField] private GameObject _endingUiRef;

    public void DestroyGlass()
    {
        Instantiate(_endingUiRef);
    }
}
