using UnityEngine;
using MapSystem;
using DialogueSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private DialogController _dialogController;
    [SerializeField] private MapController _mapController;

    private string _mode = "Map";

    private bool _lockControl;

    private void Update()
    {
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");

        if (scrollValue != 0 && !_lockControl)
        {
            if (_mode == "Map")
            {
                _mapController.ScrollMap(scrollValue);
            }
        }
        
        if (Input.anyKeyDown && !_lockControl)
        {
            if (_mode == "DialogueWindow")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _dialogController.UpdateDialog();
                }
            }

            if (_mode == "Map")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _mapController.MoveCharacter(Input.mousePosition);
                }
            }
        }
    }

    public void LockControl()
    {
        _lockControl = true;
    }

    public void UnlockControl()
    {
        _lockControl = false;
    }
}
