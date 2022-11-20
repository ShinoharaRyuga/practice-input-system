using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    [SerializeField] 
    PlayerInput _playerInput = default;

    Vector2 _input;

    private void Start()
    {
        
    }

    private void Update()
    {
        var _input = _playerInput.currentActionMap["Move"].ReadValue<Vector2>();

        if (_input != Vector2.zero)
        {
            Debug.Log(_input);
        }
    }

    void TestAction()
    {
        Debug.Log("‰Ÿ‚³‚ê‚½");
    }
}
