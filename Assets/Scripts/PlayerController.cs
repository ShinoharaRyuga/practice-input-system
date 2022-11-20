using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    /// <summary>武器切り替えボタンの名前（左） </summary>
    const string WEAPON_CHANGE_LEFT_NAME = "leftShoulder";
    /// <summary>武器切り替えボタンの名前（右） </summary>
    const string WEAPON_CHANE_RIGHT_NAME = "rightShoulder";

    
    private ActionMapNames _currentMap = ActionMapNames.UI;
    private GameInput _gameInputs;

    private void Awake()
    {
        // Input Actionインスタンス生成
        _gameInputs = new GameInput();

        InputInitialzie();
    }

    //以下InGameのAction
    //---------------------------------------------------------------------

    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("攻撃");
        ChangeActionMap(ActionMapNames.UI);
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("ポーズ");
    }
    private void OnRestart(InputAction.CallbackContext context)
    {
        Debug.Log("再開");
    }

    private void OnWeaponChange(InputAction.CallbackContext context)
    {
        Debug.Log("武器切り替え");

        if (context.control.name == WEAPON_CHANGE_LEFT_NAME)    //左が押された
        {
            Debug.Log("左が押された");
        }
        else 　　//右が押された
        {
            Debug.Log("右が押された");
        }
    }

    private void OnPicture(InputAction.CallbackContext context)
    {
        Debug.Log("写真を撮る");
        
    }

    //--------------------------------------------------------------------------------------------

    //以下OutGameのAction
    //--------------------------------------------------------------------------------------------

    private void OnSelect(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    private void OnSubmit(InputAction.CallbackContext context)
    {
        Debug.Log("決定");
        ChangeActionMap(ActionMapNames.InGame);
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        Debug.Log("キャンセル");
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
        //移動
        _gameInputs.InGame.Move.started += OnMove;
        _gameInputs.InGame.Move.performed += OnMove;
        _gameInputs.InGame.Move.canceled += OnMove;

        //攻撃
        _gameInputs.InGame.Attack.performed += OnAttack;

        //ポーズ
        _gameInputs.InGame.Pause.performed += OnPause;

        //再開
        //_gameInputs.InGame.Restart.performed += OnRestart;

        //武器切り替え
        _gameInputs.InGame.WeaponChange.performed += OnWeaponChange;

        //写真を撮る
        _gameInputs.InGame.Picture.performed += OnPicture; 
    }

    private void UIInitialzie()
    {
        //選択
        _gameInputs.UI.Navigate.started += OnSelect;
        _gameInputs.UI.Navigate.performed += OnSelect;
        _gameInputs.UI.Navigate.canceled += OnSelect;

        //決定
        _gameInputs.UI.Submit.performed += OnSubmit;

        //キャンセル
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
