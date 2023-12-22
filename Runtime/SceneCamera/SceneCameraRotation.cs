using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Megumin.Cinemachine
{
    [CameraPipeline(CinemachineCore.Stage.Aim)]
    public partial class SceneCameraRotation : CinemachineComponentBase
    {
        public override bool IsValid => enabled;
        public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Aim;

        [Range(0, 1)]
        public float Damping = 0f;

        [Space]
        [Range(0.1f, 10)]
        public float HorizontalSpeed = 1f;
        [Range(0.1f, 10)]
        public float VerticalSpeed = 1f;

        [Header("Debug")]
        public bool IsRotating = false;
        public Vector2 MouseDelta = Vector2.zero;
        Quaternion PreviousOrientation = Quaternion.identity;
        Quaternion DampingDebt = Quaternion.identity;

        public override float GetMaxDampTime() => Damping;

        protected override void OnDisable()
        {
            base.OnDisable();
            //gameObject.activeInHierarchy false 时，从此处关闭输入系统。
            UpdateInputEnabled();
        }

        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            if (!IsValid)
            {
                return;
            }

            if (deltaTime < 0)
            {
                return;
            }

            UpdateInputEnabled();

            if (!VirtualCamera.LookAt)
            {
                //LookAt为空时不会更新VirtualCamera旋转
                VirtualCamera.LookAt = transform;
            }

            var h = Quaternion.identity;
            var v = Quaternion.identity;

            if (IsRotating)
            {
                if (MouseDelta != Vector2.zero)
                {
                    const float xScale = 0.5f;
                    const float yScale = 0.5f;

                    var hAngle = MouseDelta.x * xScale * HorizontalSpeed;
                    var vAngle = MouseDelta.y * yScale * VerticalSpeed * -1;

                    h = Quaternion.AngleAxis(hAngle, curState.ReferenceUp);
                    v = Quaternion.AngleAxis(vAngle, Vector3.right);

                    MouseDelta = Vector2.zero;
                }
            }

            if (Damping <= 0)
            {
                curState.RawOrientation = h * curState.RawOrientation * v;
            }
            else
            {
                //阻尼  可能存在潜在bug。
                var finalRos = h * (DampingDebt * PreviousOrientation) * v;
                Quaternion dampedOrientation = finalRos;
                if (deltaTime >= 0)
                {
                    float t = VirtualCamera.DetachedFollowTargetDamp(1, Damping, deltaTime);
                    dampedOrientation = Quaternion.Slerp(PreviousOrientation, finalRos, t);
                }

                PreviousOrientation = dampedOrientation;
                DampingDebt = finalRos * Quaternion.Inverse(dampedOrientation);
                curState.RawOrientation = dampedOrientation;
            }
        }

        public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
        {
            base.ForceCameraPosition(pos, rot);
            if (VirtualCamera)
            {
                VirtualCamera.transform.SetPositionAndRotation(pos, rot);
                PreviousOrientation = rot;
                DampingDebt = Quaternion.identity;
            }
        }

        SceneCameraInput inputs;

        /// <summary>
        /// Update Input Enable
        /// </summary>
        public void UpdateInputEnabled()
        {
            if (Application.isPlaying == false)
            {
                return;
            }

            var vcam = VirtualCamera;
            if (!vcam)
            {
                return;
            }

            if (inputs == null)
            {
                inputs = new();
                inputs.Rotation.SetCallbacks(this);
            }

            var enable = vcam.enabled
                         && vcam.gameObject.activeInHierarchy
                         && vcam.IsLive
                         && gameObject.activeInHierarchy;

            if (enable)
            {
                if (inputs.Rotation.enabled == false)
                {
                    inputs.Rotation.Enable();
                    //Debug.Log($"Enable Input Rotation");
                }
            }
            else
            {
                if (inputs.Rotation.enabled)
                {
                    inputs.Rotation.Disable();
                    //Debug.Log($"Disable Input Rotation");
                }
            }
        }
    }

    partial class SceneCameraRotation : SceneCameraInput.IRotationActions
    {
        public void OnRotatiomMode(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                IsRotating = true;
            }

            if (context.canceled)
            {
                IsRotating = false;
                MouseDelta = Vector2.zero;
            }
        }

        public void OnMouseDelta(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (IsRotating)
                {
                    Vector2 value = context.ReadValue<Vector2>();
                    MouseDelta += value;
                    //Debug.LogError($"{context.phase} ---- {value}");
                }
            }
        }
    }

}




