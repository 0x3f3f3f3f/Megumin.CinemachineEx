using System;
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

        [Range(0, 5)]
        public float Damping = 0.5f;

        [Space]
        [Range(0.1f, 10)]
        public float HorizontalSpeed = 1f;
        [Range(0.1f, 10)]
        public float VerticalSpeed = 1f;

        [Header("Debug")]
        public bool IsRotating = false;
        public Vector2 MouseDelta = Vector2.zero;
        public float hDampingDebt = 0f;
        public float vDampingDebt = 0f;

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

            float hAngle = 0;
            float vAngle = 0;

            if (MouseDelta != Vector2.zero)
            {
                const float xScale = 0.5f;
                const float yScale = 0.5f;

                hAngle = MouseDelta.x * xScale * HorizontalSpeed;
                vAngle = MouseDelta.y * yScale * VerticalSpeed * -1;

                MouseDelta = Vector2.zero;
            }

            hAngle += hDampingDebt;
            vAngle += vDampingDebt;

            if (hAngle == 0 && vAngle == 0)
            {
                return;
            }

            var damph = hAngle;
            var dampv = vAngle;
            if (deltaTime >= 0)
            {
                //针对 各个轴角度制作阻尼。
                //如果针对Quaternion制作阻尼，插值时会造成ReferenceUp改变。
                float t = VirtualCamera.DetachedFollowTargetDamp(1, Damping, deltaTime);
                damph = Mathf.Lerp(0, hAngle, t);
                dampv = Mathf.Lerp(0, vAngle, t);
            }

            hDampingDebt = hAngle - damph;
            vDampingDebt = vAngle - dampv;

            if (Math.Abs(hDampingDebt) < 0.01f)
            {
                hDampingDebt = 0;
            }
            if (Math.Abs(vDampingDebt) < 0.01f)
            {
                vDampingDebt = 0;
            }

            var h = Quaternion.AngleAxis(damph, curState.ReferenceUp);
            var v = Quaternion.AngleAxis(dampv, Vector3.right);

            curState.RawOrientation = h * curState.RawOrientation * v;
        }

        public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
        {
            base.ForceCameraPosition(pos, rot);
            if (VirtualCamera)
            {
                VirtualCamera.transform.SetPositionAndRotation(pos, rot);
                hDampingDebt = 0;
                vDampingDebt = 0;
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




