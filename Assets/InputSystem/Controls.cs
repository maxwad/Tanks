using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    private NewInputActions inputs;

    public static float horizontal   = 0;
    public static float vertical     = 0;
    public static bool jump          = false;
    public static bool fire          = false;
    public static bool juggernaut    = false;
    public static bool super         = false;
    public static float switchWeapon = 0;
    public static bool pause         = false;
    public static bool submit        = false;
    public static bool cancel        = false;

    private int currentCountGamepads = 0;
    public static bool isGamepad = true;


    private void Awake()
    {
        inputs = new NewInputActions();
        currentCountGamepads = Gamepad.all.Count;

        //Initialising();    
    }

    //private void Initialising()
    //{
    //    if (gamepad == 0)
    //    {
    //        isGamepad = false;

    //        inputs.PlayerKB.Axises.performed += context => horizontal = inputs.PlayerKB.Axises.ReadValue<Vector2>().x > 0 ? 1 : inputs.PlayerKB.Axises.ReadValue<Vector2>().x < 0 ? -1 : 0;
    //        inputs.PlayerKB.Axises.canceled += context => horizontal = 0;

    //        inputs.PlayerKB.Axises.performed += context => vertical = inputs.PlayerKB.Axises.ReadValue<Vector2>().y > 0 ? 1 : inputs.PlayerKB.Axises.ReadValue<Vector2>().y < 0 ? -1 : 0;
    //        inputs.PlayerKB.Axises.canceled += context => vertical = 0;

    //        inputs.PlayerKB.Fire.performed += context => fire = true;
    //        inputs.PlayerKB.Fire.canceled += context => fire = false;

    //        inputs.PlayerKB.Super.started += context => super = true;
    //        inputs.PlayerKB.Super.canceled += context => super = false;

    //        inputs.PlayerKB.SwitchWeaponUp.performed += context => switchWeapon = inputs.PlayerKB.SwitchWeaponUp.ReadValue<float>() > 0 ? 1 : inputs.PlayerKB.SwitchWeaponUp.ReadValue<float>() < 0 ? -1 : 0;
    //        inputs.PlayerKB.SwitchWeaponUp.canceled += context => switchWeapon = 0;

    //        inputs.PlayerKB.SwitchWeaponDown.performed += context => switchWeapon = inputs.PlayerKB.SwitchWeaponDown.ReadValue<float>() > 0 ? 1 : inputs.PlayerKB.SwitchWeaponDown.ReadValue<float>() < 0 ? -1 : 0;
    //        inputs.PlayerKB.SwitchWeaponDown.canceled += context => switchWeapon = 0;

    //        inputs.PlayerKB.Submit.started += context => submit = true;
    //        inputs.PlayerKB.Submit.canceled += context => submit = false;

    //        inputs.PlayerKB.Cancel.started += context => cancel = true;
    //        inputs.PlayerKB.Cancel.canceled += context => cancel = false;
    //    }
    //    else
    //    {
    //        isGamepad = true;

    //        inputs.Player.Axises.performed += context => horizontal = inputs.Player.Axises.ReadValue<Vector2>().x > 0 ? 1 : inputs.Player.Axises.ReadValue<Vector2>().x < 0 ? -1 : 0;
    //        inputs.Player.Axises.canceled += context => horizontal = 0;

    //        inputs.Player.Axises.performed += context => vertical = inputs.Player.Axises.ReadValue<Vector2>().y > 0 ? 1 : inputs.Player.Axises.ReadValue<Vector2>().y < 0 ? -1 : 0;
    //        inputs.Player.Axises.canceled += context => vertical = 0;

    //        //in this case we have problems with emulating GetButtonDown function
    //        //therefore we need another solution, for example, like in Update method
    //        //
    //        //inputs.Player.Jump.started += context => jump = true;
    //        //inputs.Player.Jump.canceled += context => jump = false;

    //        //inputs.Player.Juggernaut.started += context => juggernaut = true;
    //        //inputs.Player.Juggernaut.canceled += context => juggernaut = false;

    //        //inputs.Player.Pause.started += context => pause = true;
    //        //inputs.Player.Pause.canceled += context => pause = false;

    //        inputs.Player.Fire.performed += context => fire = true;
    //        inputs.Player.Fire.canceled += context => fire = false;

    //        inputs.Player.Super.started += context => super = true;
    //        inputs.Player.Super.canceled += context => super = false;

    //        inputs.Player.SwitchWeaponUp.started += context => switchWeapon = 1;
    //        inputs.Player.SwitchWeaponUp.canceled += context => switchWeapon = 0;

    //        inputs.Player.SwitchWeaponDown.started += context => switchWeapon = -1;
    //        inputs.Player.SwitchWeaponDown.canceled += context => switchWeapon = 0;

    //        inputs.Player.Submit.started += context => submit = true;
    //        inputs.Player.Submit.canceled += context => submit = false;

    //        inputs.Player.Cancel.started += context => cancel = true;
    //        inputs.Player.Cancel.canceled += context => cancel = false;
    //    }
    //}

    private void Update()
    {

        pause = inputs.PlayerScheme.Pause.triggered;

        //    int gamepadesCount = Gamepad.all.Count;
        //    if (currentCountGamepads != gamepadesCount)
        //    {
        //        Initialising(gamepadesCount);
        //        currentCountGamepads = gamepadesCount;
        //    }

        //    if (gamepadesCount == 0)
        //    {
        //        juggernaut = inputs.PlayerKB.Juggernaut.triggered;
        //        jump = inputs.PlayerKB.Jump.triggered;
        //        pause = inputs.PlayerKB.Pause.triggered;            
        //    }
        //    else
        //    {
        //        juggernaut = inputs.Player.Juggernaut.triggered;
        //        jump = inputs.Player.Jump.triggered;
        //        pause = inputs.Player.Pause.triggered;
        //    }
        //    //debugging input
        //    //Debug.Log("juggernaut " + switchWeapon);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
