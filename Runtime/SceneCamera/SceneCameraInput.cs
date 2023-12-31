//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Packages/com.megumin.cinemachineex/Runtime/SceneCamera/SceneCameraInput.inputactions
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

namespace Megumin.Cinemachine
{
    public partial class @SceneCameraInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @SceneCameraInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""SceneCameraInput"",
    ""maps"": [
        {
            ""name"": ""Position"",
            ""id"": ""0bf57cba-d556-4761-93ee-50ed23dc2442"",
            ""actions"": [
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""Value"",
                    ""id"": ""63084713-ca9e-4fb6-8e5c-90e9546f10fa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""StickDeadzone"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""UpDown"",
                    ""type"": ""Value"",
                    ""id"": ""94006ba8-ab0a-424b-9edb-cf528a61ce07"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""d62297d1-e37d-4b1c-814f-e1f016e399ad"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""127bbdf7-d117-4b2d-a27d-634214cdea52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Value"",
                    ""id"": ""c51f4fcc-4247-4b3d-80ef-2990c1b27ade"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""FrameSelected"",
                    ""type"": ""Button"",
                    ""id"": ""c6270513-1648-4f23-bcdb-3f6553f51b57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""1d2bc33c-8323-4db8-aa72-f34b81c36117"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""855619de-97db-4af9-8d92-1a6a28e20fc8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""52b00e4b-a2e4-441a-a621-8a14ed03e23f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1ccbbb59-e27e-40f0-82cb-6e1dab4fa423"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""792a1f54-b829-48fe-b207-c7f9cca94d42"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3b3a5fac-5542-4bea-9b39-ade057df1b60"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fb09eff4-a47f-401c-851a-01b64d77ed65"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ad2cb357-9ee6-405d-a069-c8249afed03a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a73571da-46ed-407e-bdb3-abe3a65df0dc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""69ccd125-b6b5-479c-9b9c-6f9f7f368b9c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""fc949d3d-766d-4e31-b4ca-a57750e165b5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba0c1455-b7aa-4195-adc7-c2cbb56891ec"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf30dbb8-3746-4b8e-9f9f-40c268439086"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f274b5ac-c34c-424c-b6a0-a1bf39a24d51"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e84dbbc3-1bbe-4b29-907f-b23cde0cbcf2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FrameSelected"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb0253ab-7cbf-4a25-ae88-13fd8576a353"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Rotation"",
            ""id"": ""86df9a2c-0d18-4f97-8493-0e22e8a54f8c"",
            ""actions"": [
                {
                    ""name"": ""RotatiomMode"",
                    ""type"": ""Button"",
                    ""id"": ""5dc1ffe1-7b33-4d0a-855f-1db1f79fa647"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseDelta"",
                    ""type"": ""Value"",
                    ""id"": ""45b43818-70c5-4f8e-9949-2852031603ec"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5b273199-3955-4040-8273-ff84f850b724"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotatiomMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6f004a-82a5-4004-a50e-0a280d1bc74c"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Position
            m_Position = asset.FindActionMap("Position", throwIfNotFound: true);
            m_Position_MoveCamera = m_Position.FindAction("MoveCamera", throwIfNotFound: true);
            m_Position_UpDown = m_Position.FindAction("UpDown", throwIfNotFound: true);
            m_Position_Drag = m_Position.FindAction("Drag", throwIfNotFound: true);
            m_Position_Sprint = m_Position.FindAction("Sprint", throwIfNotFound: true);
            m_Position_Zoom = m_Position.FindAction("Zoom", throwIfNotFound: true);
            m_Position_FrameSelected = m_Position.FindAction("FrameSelected", throwIfNotFound: true);
            m_Position_MouseDelta = m_Position.FindAction("MouseDelta", throwIfNotFound: true);
            // Rotation
            m_Rotation = asset.FindActionMap("Rotation", throwIfNotFound: true);
            m_Rotation_RotatiomMode = m_Rotation.FindAction("RotatiomMode", throwIfNotFound: true);
            m_Rotation_MouseDelta = m_Rotation.FindAction("MouseDelta", throwIfNotFound: true);
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

        // Position
        private readonly InputActionMap m_Position;
        private List<IPositionActions> m_PositionActionsCallbackInterfaces = new List<IPositionActions>();
        private readonly InputAction m_Position_MoveCamera;
        private readonly InputAction m_Position_UpDown;
        private readonly InputAction m_Position_Drag;
        private readonly InputAction m_Position_Sprint;
        private readonly InputAction m_Position_Zoom;
        private readonly InputAction m_Position_FrameSelected;
        private readonly InputAction m_Position_MouseDelta;
        public struct PositionActions
        {
            private @SceneCameraInput m_Wrapper;
            public PositionActions(@SceneCameraInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @MoveCamera => m_Wrapper.m_Position_MoveCamera;
            public InputAction @UpDown => m_Wrapper.m_Position_UpDown;
            public InputAction @Drag => m_Wrapper.m_Position_Drag;
            public InputAction @Sprint => m_Wrapper.m_Position_Sprint;
            public InputAction @Zoom => m_Wrapper.m_Position_Zoom;
            public InputAction @FrameSelected => m_Wrapper.m_Position_FrameSelected;
            public InputAction @MouseDelta => m_Wrapper.m_Position_MouseDelta;
            public InputActionMap Get() { return m_Wrapper.m_Position; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PositionActions set) { return set.Get(); }
            public void AddCallbacks(IPositionActions instance)
            {
                if (instance == null || m_Wrapper.m_PositionActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PositionActionsCallbackInterfaces.Add(instance);
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @UpDown.started += instance.OnUpDown;
                @UpDown.performed += instance.OnUpDown;
                @UpDown.canceled += instance.OnUpDown;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @FrameSelected.started += instance.OnFrameSelected;
                @FrameSelected.performed += instance.OnFrameSelected;
                @FrameSelected.canceled += instance.OnFrameSelected;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }

            private void UnregisterCallbacks(IPositionActions instance)
            {
                @MoveCamera.started -= instance.OnMoveCamera;
                @MoveCamera.performed -= instance.OnMoveCamera;
                @MoveCamera.canceled -= instance.OnMoveCamera;
                @UpDown.started -= instance.OnUpDown;
                @UpDown.performed -= instance.OnUpDown;
                @UpDown.canceled -= instance.OnUpDown;
                @Drag.started -= instance.OnDrag;
                @Drag.performed -= instance.OnDrag;
                @Drag.canceled -= instance.OnDrag;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @Zoom.started -= instance.OnZoom;
                @Zoom.performed -= instance.OnZoom;
                @Zoom.canceled -= instance.OnZoom;
                @FrameSelected.started -= instance.OnFrameSelected;
                @FrameSelected.performed -= instance.OnFrameSelected;
                @FrameSelected.canceled -= instance.OnFrameSelected;
                @MouseDelta.started -= instance.OnMouseDelta;
                @MouseDelta.performed -= instance.OnMouseDelta;
                @MouseDelta.canceled -= instance.OnMouseDelta;
            }

            public void RemoveCallbacks(IPositionActions instance)
            {
                if (m_Wrapper.m_PositionActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPositionActions instance)
            {
                foreach (var item in m_Wrapper.m_PositionActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PositionActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PositionActions @Position => new PositionActions(this);

        // Rotation
        private readonly InputActionMap m_Rotation;
        private List<IRotationActions> m_RotationActionsCallbackInterfaces = new List<IRotationActions>();
        private readonly InputAction m_Rotation_RotatiomMode;
        private readonly InputAction m_Rotation_MouseDelta;
        public struct RotationActions
        {
            private @SceneCameraInput m_Wrapper;
            public RotationActions(@SceneCameraInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @RotatiomMode => m_Wrapper.m_Rotation_RotatiomMode;
            public InputAction @MouseDelta => m_Wrapper.m_Rotation_MouseDelta;
            public InputActionMap Get() { return m_Wrapper.m_Rotation; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RotationActions set) { return set.Get(); }
            public void AddCallbacks(IRotationActions instance)
            {
                if (instance == null || m_Wrapper.m_RotationActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_RotationActionsCallbackInterfaces.Add(instance);
                @RotatiomMode.started += instance.OnRotatiomMode;
                @RotatiomMode.performed += instance.OnRotatiomMode;
                @RotatiomMode.canceled += instance.OnRotatiomMode;
                @MouseDelta.started += instance.OnMouseDelta;
                @MouseDelta.performed += instance.OnMouseDelta;
                @MouseDelta.canceled += instance.OnMouseDelta;
            }

            private void UnregisterCallbacks(IRotationActions instance)
            {
                @RotatiomMode.started -= instance.OnRotatiomMode;
                @RotatiomMode.performed -= instance.OnRotatiomMode;
                @RotatiomMode.canceled -= instance.OnRotatiomMode;
                @MouseDelta.started -= instance.OnMouseDelta;
                @MouseDelta.performed -= instance.OnMouseDelta;
                @MouseDelta.canceled -= instance.OnMouseDelta;
            }

            public void RemoveCallbacks(IRotationActions instance)
            {
                if (m_Wrapper.m_RotationActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IRotationActions instance)
            {
                foreach (var item in m_Wrapper.m_RotationActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_RotationActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public RotationActions @Rotation => new RotationActions(this);
        public interface IPositionActions
        {
            void OnMoveCamera(InputAction.CallbackContext context);
            void OnUpDown(InputAction.CallbackContext context);
            void OnDrag(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnZoom(InputAction.CallbackContext context);
            void OnFrameSelected(InputAction.CallbackContext context);
            void OnMouseDelta(InputAction.CallbackContext context);
        }
        public interface IRotationActions
        {
            void OnRotatiomMode(InputAction.CallbackContext context);
            void OnMouseDelta(InputAction.CallbackContext context);
        }
    }
}
