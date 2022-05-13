// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/NewInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NewInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NewInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerScheme"",
            ""id"": ""ed82aebc-452d-453e-97e9-8fc308ea979f"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""2b71e78c-6c65-4051-8c7d-fbf47b39b581"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2fd05a7-2bec-4390-8209-e16939cbc219"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7abc119d-99e0-44ef-9266-d967c55f7ad5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerScheme
        m_PlayerScheme = asset.FindActionMap("PlayerScheme", throwIfNotFound: true);
        m_PlayerScheme_Pause = m_PlayerScheme.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerScheme
    private readonly InputActionMap m_PlayerScheme;
    private IPlayerSchemeActions m_PlayerSchemeActionsCallbackInterface;
    private readonly InputAction m_PlayerScheme_Pause;
    public struct PlayerSchemeActions
    {
        private @NewInputActions m_Wrapper;
        public PlayerSchemeActions(@NewInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PlayerScheme_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PlayerScheme; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerSchemeActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerSchemeActions instance)
        {
            if (m_Wrapper.m_PlayerSchemeActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PlayerSchemeActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerSchemeActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerSchemeActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerSchemeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerSchemeActions @PlayerScheme => new PlayerSchemeActions(this);
    public interface IPlayerSchemeActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
