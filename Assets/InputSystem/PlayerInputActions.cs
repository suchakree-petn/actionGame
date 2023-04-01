//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player_Movement"",
            ""id"": ""e66530f3-a10e-4960-b3bb-6722f1d764ca"",
            ""actions"": [
                {
                    ""name"": ""walk"",
                    ""type"": ""Value"",
                    ""id"": ""72d280fe-3eae-4f94-83de-5ffe41994e84"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fce7c755-2d81-4fa2-a704-f0258379061e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""d2d5fefc-4fb9-4ba1-a13d-cd7f68ff8ff7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""04a90a25-9f08-4c06-907b-0385ac79ba4b"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""01023a7e-be2b-4e8e-bca3-78734dae7f88"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""227c69fc-9852-4174-ab21-9ab934893d47"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""90e53eea-331b-466d-b531-181d506b62d3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player_Attack"",
            ""id"": ""b59c705c-3de4-4280-a2cd-a3dd382e091e"",
            ""actions"": [
                {
                    ""name"": ""PriAttack"",
                    ""type"": ""Button"",
                    ""id"": ""04a119c5-f841-401d-b897-9b786221e792"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill01"",
                    ""type"": ""Button"",
                    ""id"": ""9cdf7a3e-1357-484b-afd4-93f7292b2202"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Skill02"",
                    ""type"": ""Button"",
                    ""id"": ""6f1fb499-fc6d-43b7-8d69-f2d364db1305"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8a0d45e8-6711-4dba-9f3e-e5c518c4f2ac"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""PriAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82359475-33a1-4012-9d76-5f844964394f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""PriAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07119678-5b1f-41a3-86e5-373e08c88d7f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""Skill01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dab5f233-75ec-473a-b6e6-bfbe96f41604"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyMouse"",
                    ""action"": ""Skill02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyMouse"",
            ""bindingGroup"": ""KeyMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player_Movement
        m_Player_Movement = asset.FindActionMap("Player_Movement", throwIfNotFound: true);
        m_Player_Movement_walk = m_Player_Movement.FindAction("walk", throwIfNotFound: true);
        // Player_Attack
        m_Player_Attack = asset.FindActionMap("Player_Attack", throwIfNotFound: true);
        m_Player_Attack_PriAttack = m_Player_Attack.FindAction("PriAttack", throwIfNotFound: true);
        m_Player_Attack_Skill01 = m_Player_Attack.FindAction("Skill01", throwIfNotFound: true);
        m_Player_Attack_Skill02 = m_Player_Attack.FindAction("Skill02", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player_Movement
    private readonly InputActionMap m_Player_Movement;
    private IPlayer_MovementActions m_Player_MovementActionsCallbackInterface;
    private readonly InputAction m_Player_Movement_walk;
    public struct Player_MovementActions
    {
        private @PlayerInputActions m_Wrapper;
        public Player_MovementActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @walk => m_Wrapper.m_Player_Movement_walk;
        public InputActionMap Get() { return m_Wrapper.m_Player_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_MovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_MovementActions instance)
        {
            if (m_Wrapper.m_Player_MovementActionsCallbackInterface != null)
            {
                @walk.started -= m_Wrapper.m_Player_MovementActionsCallbackInterface.OnWalk;
                @walk.performed -= m_Wrapper.m_Player_MovementActionsCallbackInterface.OnWalk;
                @walk.canceled -= m_Wrapper.m_Player_MovementActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_Player_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @walk.started += instance.OnWalk;
                @walk.performed += instance.OnWalk;
                @walk.canceled += instance.OnWalk;
            }
        }
    }
    public Player_MovementActions @Player_Movement => new Player_MovementActions(this);

    // Player_Attack
    private readonly InputActionMap m_Player_Attack;
    private IPlayer_AttackActions m_Player_AttackActionsCallbackInterface;
    private readonly InputAction m_Player_Attack_PriAttack;
    private readonly InputAction m_Player_Attack_Skill01;
    private readonly InputAction m_Player_Attack_Skill02;
    public struct Player_AttackActions
    {
        private @PlayerInputActions m_Wrapper;
        public Player_AttackActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PriAttack => m_Wrapper.m_Player_Attack_PriAttack;
        public InputAction @Skill01 => m_Wrapper.m_Player_Attack_Skill01;
        public InputAction @Skill02 => m_Wrapper.m_Player_Attack_Skill02;
        public InputActionMap Get() { return m_Wrapper.m_Player_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_AttackActions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_AttackActions instance)
        {
            if (m_Wrapper.m_Player_AttackActionsCallbackInterface != null)
            {
                @PriAttack.started -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnPriAttack;
                @PriAttack.performed -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnPriAttack;
                @PriAttack.canceled -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnPriAttack;
                @Skill01.started -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnSkill01;
                @Skill01.performed -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnSkill01;
                @Skill01.canceled -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnSkill01;
                @Skill02.started -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnSkill02;
                @Skill02.performed -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnSkill02;
                @Skill02.canceled -= m_Wrapper.m_Player_AttackActionsCallbackInterface.OnSkill02;
            }
            m_Wrapper.m_Player_AttackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PriAttack.started += instance.OnPriAttack;
                @PriAttack.performed += instance.OnPriAttack;
                @PriAttack.canceled += instance.OnPriAttack;
                @Skill01.started += instance.OnSkill01;
                @Skill01.performed += instance.OnSkill01;
                @Skill01.canceled += instance.OnSkill01;
                @Skill02.started += instance.OnSkill02;
                @Skill02.performed += instance.OnSkill02;
                @Skill02.canceled += instance.OnSkill02;
            }
        }
    }
    public Player_AttackActions @Player_Attack => new Player_AttackActions(this);
    private int m_KeyMouseSchemeIndex = -1;
    public InputControlScheme KeyMouseScheme
    {
        get
        {
            if (m_KeyMouseSchemeIndex == -1) m_KeyMouseSchemeIndex = asset.FindControlSchemeIndex("KeyMouse");
            return asset.controlSchemes[m_KeyMouseSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    public interface IPlayer_MovementActions
    {
        void OnWalk(InputAction.CallbackContext context);
    }
    public interface IPlayer_AttackActions
    {
        void OnPriAttack(InputAction.CallbackContext context);
        void OnSkill01(InputAction.CallbackContext context);
        void OnSkill02(InputAction.CallbackContext context);
    }
}
