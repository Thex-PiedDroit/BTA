// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/InputActions/Player/IA_PlayerCombat.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @IA_PlayerCombat : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @IA_PlayerCombat()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""IA_PlayerCombat"",
    ""maps"": [
        {
            ""name"": ""Combat"",
            ""id"": ""a9c11c12-41e8-471c-ab03-669baab2190a"",
            ""actions"": [
                {
                    ""name"": ""RightHand"",
                    ""type"": ""Button"",
                    ""id"": ""07d584f3-3ec0-4580-a954-57058f1dde3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftHand"",
                    ""type"": ""Button"",
                    ""id"": ""8090af23-39e8-4573-9efa-f7a43518ee84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9ef15702-bd0c-4fe3-bbb0-02ba9b40fd84"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MK"",
                    ""action"": ""RightHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f728795a-d3f3-4cf6-bad6-c6f62023c38d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MK"",
                    ""action"": ""LeftHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MK"",
            ""bindingGroup"": ""MK"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Combat
        m_Combat = asset.FindActionMap("Combat", throwIfNotFound: true);
        m_Combat_RightHand = m_Combat.FindAction("RightHand", throwIfNotFound: true);
        m_Combat_LeftHand = m_Combat.FindAction("LeftHand", throwIfNotFound: true);
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

    // Combat
    private readonly InputActionMap m_Combat;
    private ICombatActions m_CombatActionsCallbackInterface;
    private readonly InputAction m_Combat_RightHand;
    private readonly InputAction m_Combat_LeftHand;
    public struct CombatActions
    {
        private @IA_PlayerCombat m_Wrapper;
        public CombatActions(@IA_PlayerCombat wrapper) { m_Wrapper = wrapper; }
        public InputAction @RightHand => m_Wrapper.m_Combat_RightHand;
        public InputAction @LeftHand => m_Wrapper.m_Combat_LeftHand;
        public InputActionMap Get() { return m_Wrapper.m_Combat; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CombatActions set) { return set.Get(); }
        public void SetCallbacks(ICombatActions instance)
        {
            if (m_Wrapper.m_CombatActionsCallbackInterface != null)
            {
                @RightHand.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnRightHand;
                @RightHand.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnRightHand;
                @RightHand.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnRightHand;
                @LeftHand.started -= m_Wrapper.m_CombatActionsCallbackInterface.OnLeftHand;
                @LeftHand.performed -= m_Wrapper.m_CombatActionsCallbackInterface.OnLeftHand;
                @LeftHand.canceled -= m_Wrapper.m_CombatActionsCallbackInterface.OnLeftHand;
            }
            m_Wrapper.m_CombatActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RightHand.started += instance.OnRightHand;
                @RightHand.performed += instance.OnRightHand;
                @RightHand.canceled += instance.OnRightHand;
                @LeftHand.started += instance.OnLeftHand;
                @LeftHand.performed += instance.OnLeftHand;
                @LeftHand.canceled += instance.OnLeftHand;
            }
        }
    }
    public CombatActions @Combat => new CombatActions(this);
    private int m_MKSchemeIndex = -1;
    public InputControlScheme MKScheme
    {
        get
        {
            if (m_MKSchemeIndex == -1) m_MKSchemeIndex = asset.FindControlSchemeIndex("MK");
            return asset.controlSchemes[m_MKSchemeIndex];
        }
    }
    public interface ICombatActions
    {
        void OnRightHand(InputAction.CallbackContext context);
        void OnLeftHand(InputAction.CallbackContext context);
    }
}
