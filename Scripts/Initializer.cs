using UnityEngine;
using MapSystem;
using DialogueSystem;

public class Initializer : MonoBehaviour
{
    [SerializeField] private DialogController _dialogController;
    [SerializeField] private Localizator _localizator;
    [SerializeField] private MapController _mapController;

    private void Awake()
    {
        _dialogController.Initialize();
        _localizator.Initialize();
        _mapController.Initialize();

        Destroy(this);
    }
}
