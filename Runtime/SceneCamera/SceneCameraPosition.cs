using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Megumin.Cinemachine
{
    [CameraPipeline(CinemachineCore.Stage.Body)]
    public partial class SceneCameraPosition : CinemachineComponentBase
    {
        public override bool IsValid => enabled;
        public override CinemachineCore.Stage Stage => CinemachineCore.Stage.Body;

        [Range(0, 5)]
        public float Damping = 0.5f;

        /// <summary>
        /// 冲刺
        /// </summary>
        [Space]
        public float SprintScale = 5f;

        [Range(0.1f, 10)]
        public float DragSpeed = 1f;

        public bool EnabledZoom = true;

        [Header("Flythrough")]
        [Range(0.01f, 10)]
        public float Speed = 1f;
        public float MinSpeed = 0.01f;
        public float MaxSpeed = 2f;

        [Header("Debug")]
        public bool IsSprint = false;
        public bool IsDraging = false;
        public Camera OutputCamera = null;
        public Vector2 MouseDelta = Vector2.zero;
        public float LastSpeed = 1f;
        public Vector3 InputDir = Vector3.zero;
        public Vector2 Zoom = Vector2.zero;

        /// <summary>
        /// 当前更新根据输入计算得到的移动位移
        /// </summary>
        [Space]
        public Vector3 MoveDelta = Vector3.zero;

        /// <summary>
        /// 阻尼还没有移动的位移
        /// </summary>
        public Vector3 DampingDebt;


        public override float GetMaxDampTime() => Damping;

        protected override void OnDisable()
        {
            base.OnDisable();
            //gameObject.activeInHierarchy false 时，从此处关闭输入系统。
            UpdateInputEnabled();
        }

        public override bool OnTransitionFromCamera(ICinemachineCamera fromCam, Vector3 worldUp, float deltaTime)
        {
            //Debug.LogError($"{Time.frameCount} OnTransitionFromCamera    IsLive:{VirtualCamera.IsLive}");
            UpdateOutPutCamera();
            return base.OnTransitionFromCamera(fromCam, worldUp, deltaTime);
        }

        protected void UpdateOutPutCamera()
        {
            var brain = CinemachineCore.FindPotentialTargetBrain(VirtualCamera);
            OutputCamera = brain?.OutputCamera;
        }

        public override void MutateCameraState(ref CameraState curState, float deltaTime)
        {
            //Debug.LogError($"{Time.frameCount} MutateCameraState    IsLive:{VirtualCamera.IsLive}");

            if (IsValid == false)
            {
                return;
            }

            if (deltaTime < 0)
            {
                return;
            }

            UpdateInputEnabled();

            if (!VirtualCamera.Follow)
            {
                //Follow为空时不会更新VirtualCamera位置
                VirtualCamera.Follow = transform;
            }

            MoveDelta = default;
            if (IsDraging)
            {
                if (MouseDelta != Vector2.zero && OutputCamera)
                {
                    var worldDelta = ScreenToWorldDistance(MouseDelta, OutputCamera);

                    const float DragScale = 5f;
                    var speed = DragSpeed * DragScale;

                    if (IsSprint)
                    {
                        speed *= SprintScale;
                    }

                    worldDelta *= speed;

                    MoveDelta = worldDelta * -1;
                    MouseDelta = Vector2.zero;
                }
            }
            else
            {
                //Flythrough
                if (InputDir != Vector3.zero)
                {
                    var moveDir = curState.RawOrientation * InputDir;
                    //速度增量，1秒内加速到最大值。
                    var addSpeed = Mathf.Lerp(Speed, MaxSpeed, deltaTime) - Speed;
                    var speed = LastSpeed + Math.Abs(addSpeed);

                    //Debug.LogError($"{Time.frameCount} ---- {addSpeed} ----{speed}");

                    speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
                    LastSpeed = speed;

                    if (IsSprint)
                    {
                        speed *= SprintScale;
                    }

                    const float FlyScale = 3f;

                    MoveDelta = deltaTime * speed * FlyScale * moveDir;
                }
                else
                {
                    LastSpeed = Speed;
                }
            }

            if (EnabledZoom && Zoom != Vector2.zero)
            {
                MoveDelta += curState.RawOrientation * new Vector3(0, 0, Zoom.y);
            }

            var totalMoveDelta = MoveDelta + DampingDebt;

            if (totalMoveDelta == Vector3.zero)
            {
                return;
            }

            //阻尼
            Vector3 dampedDelta = totalMoveDelta;
            if (deltaTime >= 0)
            {
                dampedDelta = VirtualCamera.DetachedFollowTargetDamp(
                    totalMoveDelta, Damping, deltaTime);
            }

            DampingDebt = totalMoveDelta - dampedDelta;
            curState.RawPosition += dampedDelta;
        }

        public override void ForceCameraPosition(Vector3 pos, Quaternion rot)
        {
            base.ForceCameraPosition(pos, rot);
            if (VirtualCamera)
            {
                VirtualCamera.transform.SetPositionAndRotation(pos, rot);
                DampingDebt = Vector3.zero;
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
                inputs.Position.SetCallbacks(this);
            }

            var enable = vcam.enabled
                         && vcam.gameObject.activeInHierarchy
                         && vcam.IsLive
                         && gameObject.activeInHierarchy;

            if (enable)
            {
                if (inputs.Position.enabled == false)
                {
                    inputs.Position.Enable();
                    //Debug.Log($"Enable Input Position");
                }
            }
            else
            {
                if (inputs.Position.enabled)
                {
                    inputs.Position.Disable();
                    //Debug.Log($"Disable Input Position");
                }
            }
        }

        /// <summary>
        /// 屏幕空间距离转换为世界空间距离
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="camera"></param>
        /// <param name="zDistance"></param>
        /// <returns></returns>
        public static Vector3 ScreenToWorldDistance(Vector2 startPos, Vector2 endPos, Camera camera, float zDistance = 1)
        {
            if (camera)
            {
                var startWorldPos = camera.ScreenToWorldPoint(new Vector3(startPos.x, startPos.y, zDistance));
                var endWorldPos = camera.ScreenToWorldPoint(new Vector3(endPos.x, endPos.y, zDistance));

                var delta = endWorldPos - startWorldPos;
                return delta;
            }

            return endPos - startPos;
        }

        /// <summary>
        /// 屏幕空间距离转换为世界空间距离
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="camera"></param>
        /// <param name="zDistance"></param>
        /// <returns></returns>
        public static Vector3 ScreenToWorldDistance(Vector2 delta, Camera camera, float zDistance = 1)
        {
            return ScreenToWorldDistance(Vector2.zero, delta, camera, zDistance);
        }
    }

    partial class SceneCameraPosition : SceneCameraInput.IPositionActions
    {
        public void OnMoveCamera(InputAction.CallbackContext context)
        {
            var xz = context.ReadValue<Vector2>();
            InputDir.x = xz.x;
            InputDir.z = xz.y;
        }

        public void OnUpDown(InputAction.CallbackContext context)
        {
            var y = context.ReadValue<float>();
            InputDir.y = y;
        }

        public void OnDrag(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                //Debug.Log($"started {MousePosition}");
                IsDraging = true;
            }

            if (context.canceled)
            {
                //Debug.Log($"canceled {MousePosition}");
                IsDraging = false;
                MouseDelta = Vector2.zero;
            }
        }

        public void OnMouseDelta(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                if (IsDraging)
                {
                    Vector2 value = context.ReadValue<Vector2>();
                    MouseDelta += value;
                    //Debug.LogError($"{context.phase} ---- {value}");
                }
            }
            //Debug.LogError($"{context.phase} ---- ");
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                IsSprint = true;
            }

            if (context.canceled)
            {
                IsSprint = false;
            }
        }

        public void OnZoom(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                Zoom = context.ReadValue<Vector2>();
                //Debug.Log($"started {Zoom}");
            }

            if (context.canceled)
            {
                Zoom = Vector2.zero;
                //Debug.Log($"canceled {Zoom}");
            }
        }

        public void OnFrameSelected(InputAction.CallbackContext context)
        {

        }
    }
}







