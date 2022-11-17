// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""21c40d26-b90f-4e41-8c0f-6297c05918a0"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""1232b8dc-178d-406c-ac8c-5f8924373808"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8db20c90-c6fe-409d-930c-d08f77a5c330"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""886eda0d-f9e0-4269-b91d-f95246dbea52"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ping"",
                    ""type"": ""Button"",
                    ""id"": ""813bf225-bb0c-4210-b4b5-8c656f476b9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectionWheel"",
                    ""type"": ""Button"",
                    ""id"": ""90694ca1-51ba-4ede-997f-22d986fe8484"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""d5b3979e-593d-4e2b-b7cf-2f01c480e24d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MenuSelect"",
                    ""type"": ""Value"",
                    ""id"": ""0fdeea4c-c9c7-470d-80c9-d5c313701306"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""6378b1bc-63c6-448d-b627-f53fcc07316f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""27183c8c-3a61-4f7a-8655-593abff1aee3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2bd97c1-0f36-46b8-9924-bbde325f11fa"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""68c88530-d72a-4673-a003-5459c5caba3f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""814eb32f-6b86-4b19-96f2-267c3e4e96d0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""afd5d34b-941e-4f35-b1e7-2f6d21548963"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9cf6b9a3-bc71-4126-a054-2e012f97eb35"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b6c351c-41d2-40c5-99b1-892a981526e2"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84073cec-2255-430f-8dd2-dec1c9798161"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Ping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a38ae4c3-623a-4403-bcc1-eec81bec9e26"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SelectionWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09900d4d-7a49-4c51-b5f7-5daa9469c241"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a98e0d5c-b58c-4ad1-b4d5-4f21048d90a3"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""MenuSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""553e3211-2b3b-4bc8-b483-be8b4b419d32"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Camera = m_Player.FindAction("Camera", throwIfNotFound: true);
        m_Player_Ping = m_Player.FindAction("Ping", throwIfNotFound: true);
        m_Player_SelectionWheel = m_Player.FindAction("SelectionWheel", throwIfNotFound: true);
        m_Player_Select = m_Player.FindAction("Select", throwIfNotFound: true);
        m_Player_MenuSelect = m_Player.FindAction("MenuSelect", throwIfNotFound: true);
        m_Player_Tab = m_Player.FindAction("Tab", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Camera;
    private readonly InputAction m_Player_Ping;
    private readonly InputAction m_Player_SelectionWheel;
    private readonly InputAction m_Player_Select;
    private readonly InputAction m_Player_MenuSelect;
    private readonly InputAction m_Player_Tab;
    public struct PlayerActions
    {
        private @InputSystem m_Wrapper;
        public PlayerActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Camera => m_Wrapper.m_Player_Camera;
        public InputAction @Ping => m_Wrapper.m_Player_Ping;
        public InputAction @SelectionWheel => m_Wrapper.m_Player_SelectionWheel;
        public InputAction @Select => m_Wrapper.m_Player_Select;
        public InputAction @MenuSelect => m_Wrapper.m_Player_MenuSelect;
        public InputAction @Tab => m_Wrapper.m_Player_Tab;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Camera.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCamera;
                @Ping.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPing;
                @Ping.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPing;
                @Ping.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPing;
                @SelectionWheel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectionWheel;
                @SelectionWheel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectionWheel;
                @SelectionWheel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelectionWheel;
                @Select.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSelect;
                @MenuSelect.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuSelect;
                @MenuSelect.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuSelect;
                @MenuSelect.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMenuSelect;
                @Tab.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTab;
                @Tab.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTab;
                @Tab.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTab;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Ping.started += instance.OnPing;
                @Ping.performed += instance.OnPing;
                @Ping.canceled += instance.OnPing;
                @SelectionWheel.started += instance.OnSelectionWheel;
                @SelectionWheel.performed += instance.OnSelectionWheel;
                @SelectionWheel.canceled += instance.OnSelectionWheel;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @MenuSelect.started += instance.OnMenuSelect;
                @MenuSelect.performed += instance.OnMenuSelect;
                @MenuSelect.canceled += instance.OnMenuSelect;
                @Tab.started += instance.OnTab;
                @Tab.performed += instance.OnTab;
                @Tab.canceled += instance.OnTab;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnPing(InputAction.CallbackContext context);
        void OnSelectionWheel(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnMenuSelect(InputAction.CallbackContext context);
        void OnTab(InputAction.CallbackContext context);
    }
}
