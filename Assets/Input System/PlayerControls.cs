// GENERATED AUTOMATICALLY FROM 'Assets/Input System/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""e58eb0a5-c8c1-4978-ab05-b6192730cec7"",
            ""actions"": [
                {
                    ""name"": ""Moving Right"",
                    ""type"": ""Button"",
                    ""id"": ""252ce11e-24ee-445d-97b6-f6bc77de3e0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Moving Left"",
                    ""type"": ""Button"",
                    ""id"": ""7f38e7d4-2d57-4b06-8c81-6f9139690621"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f7655ffe-39ed-4bd6-84b4-d053fa4e6a1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""90d74804-6e7e-4fdd-b328-40a6b704115e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d3234e24-fb70-48cd-90ab-bbd6755ad37b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2cf5a16-15bd-44f9-b133-47305536807d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8910a3e-6cc7-42a9-962f-09d2e2eb5143"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6458f2cb-1379-473a-806b-357d848af924"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_MovingRight = m_PlayerMovement.FindAction("Moving Right", throwIfNotFound: true);
        m_PlayerMovement_MovingLeft = m_PlayerMovement.FindAction("Moving Left", throwIfNotFound: true);
        m_PlayerMovement_PrimaryContact = m_PlayerMovement.FindAction("PrimaryContact", throwIfNotFound: true);
        m_PlayerMovement_PrimaryPosition = m_PlayerMovement.FindAction("PrimaryPosition", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_MovingRight;
    private readonly InputAction m_PlayerMovement_MovingLeft;
    private readonly InputAction m_PlayerMovement_PrimaryContact;
    private readonly InputAction m_PlayerMovement_PrimaryPosition;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovingRight => m_Wrapper.m_PlayerMovement_MovingRight;
        public InputAction @MovingLeft => m_Wrapper.m_PlayerMovement_MovingLeft;
        public InputAction @PrimaryContact => m_Wrapper.m_PlayerMovement_PrimaryContact;
        public InputAction @PrimaryPosition => m_Wrapper.m_PlayerMovement_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @MovingRight.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovingRight;
                @MovingRight.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovingRight;
                @MovingRight.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovingRight;
                @MovingLeft.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovingLeft;
                @MovingLeft.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovingLeft;
                @MovingLeft.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovingLeft;
                @PrimaryContact.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPrimaryContact;
                @PrimaryContact.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPrimaryContact;
                @PrimaryPosition.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovingRight.started += instance.OnMovingRight;
                @MovingRight.performed += instance.OnMovingRight;
                @MovingRight.canceled += instance.OnMovingRight;
                @MovingLeft.started += instance.OnMovingLeft;
                @MovingLeft.performed += instance.OnMovingLeft;
                @MovingLeft.canceled += instance.OnMovingLeft;
                @PrimaryContact.started += instance.OnPrimaryContact;
                @PrimaryContact.performed += instance.OnPrimaryContact;
                @PrimaryContact.canceled += instance.OnPrimaryContact;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovingRight(InputAction.CallbackContext context);
        void OnMovingLeft(InputAction.CallbackContext context);
        void OnPrimaryContact(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}
