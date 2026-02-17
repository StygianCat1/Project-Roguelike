using System;
using UnityEngine;

public class S_GlassDestroyed : MonoBehaviour
{
    [SerializeField] private GameObject _endingUiRef;

    private void OnDestroy()
    {
        Instantiate(_endingUiRef);
    }
}
