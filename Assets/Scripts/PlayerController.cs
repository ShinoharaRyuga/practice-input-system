using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    /// <summary>����؂�ւ��{�^���̖��O�i���j </summary>
    const string WEAPON_CHANGE_LEFT_NAME = "leftShoulder";
    /// <summary>����؂�ւ��{�^���̖��O�i�E�j </summary>
    const string WEAPON_CHANE_RIGHT_NAME = "rightShoulder";

    
    private ActionMapNames _currentMap = ActionMapNames.UI;
    private GameInput _gameInputs;

    private void Awake()
    {
        // Input Action�C���X�^���X����
        _gameInputs = new GameInput();

        InputInitialzie();
    }

    //�ȉ�InGame��Action
    //---------------------------------------------------------------------

    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("�U��");
        ChangeActionMap(ActionMapNames.UI);
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("�|�[�Y");
    }
    private void OnRestart(InputAction.CallbackContext context)
    {
        Debug.Log("�ĊJ");
    }

    private void OnWeaponChange(InputAction.CallbackContext context)
    {
        Debug.Log("����؂�ւ�");

        if (context.control.name == WEAPON_CHANGE_LEFT_NAME)    //���������ꂽ
        {
            Debug.Log("���������ꂽ");
        }
        else �@�@//�E�������ꂽ
        {
            Debug.Log("�E�������ꂽ");
        }
    }

    private void OnPicture(InputAction.CallbackContext context)
    {
        Debug.Log("�ʐ^���B��");
        
    }

    //--------------------------------------------------------------------------------------------

    //�ȉ�OutGame��Action
    //--------------------------------------------------------------------------------------------

    private void OnSelect(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        Debug.Log("����");
        ChangeActionMap(ActionMapNames.InGame);
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        Debug.Log("�L�����Z��");
    }

    //--------------------------------------------------------------------------------------------

    private void InputInitialzie()
    {
        InGameInputInitialzie();
        UIInitialzie();

        ChangeActionMap(ActionMapNames.UI);
    }

    private void InGameInputInitialzie()
    {
        //�ړ�
        _gameInputs.InGame.Move.started += OnMove;
        _gameInputs.InGame.Move.performed += OnMove;
        _gameInputs.InGame.Move.canceled += OnMove;

        //�U��
        _gameInputs.InGame.Attack.performed += OnAttack;

        //�|�[�Y
        _gameInputs.InGame.Pause.performed += OnPause;

        //�ĊJ
        //_gameInputs.InGame.Restart.performed += OnRestart;

        //����؂�ւ�
        _gameInputs.InGame.WeaponChange.performed += OnWeaponChange;

        //�ʐ^���B��
        _gameInputs.InGame.Picture.performed += OnPicture; 
    }

    private void UIInitialzie()
    {
        //�I��
        _gameInputs.UI.Navigate.started += OnSelect;
        _gameInputs.UI.Navigate.performed += OnSelect;
        _gameInputs.UI.Navigate.canceled += OnSelect;

        //����
        _gameInputs.UI.Submit.performed += OnSubmit;

        //�L�����Z��
        _gameInputs.UI.Cancel.performed += OnCancel;
    }

    private void ChangeActionMap(ActionMapNames nextMap)
    {
        switch (nextMap)
        {
            case ActionMapNames.InGame:
                _gameInputs.InGame.Enable();
                _gameInputs.UI.Disable();
                break;
            case ActionMapNames.UI:
                _gameInputs.UI.Enable();
                _gameInputs.InGame.Disable();
                break;
        }

        _currentMap = nextMap;
    }
}

public enum ActionMapNames
{
    InGame,
    UI,
}
