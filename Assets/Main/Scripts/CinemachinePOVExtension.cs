using UnityEngine;
using Cinemachine;
public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager _InputManager;
    private Vector3 StartingRotation;

    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticallSpeed = 10f;

    [SerializeField] private float clampAngel = 80f;

    [SerializeField] private float EffectSpeed = 10f;

    [SerializeField] private float WalkingEffectAmount = 10f;
    private float sinTime;

    protected override void Awake()
    {
        _InputManager = InputManager.Instance;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                if (StartingRotation == null) StartingRotation = transform.localRotation.eulerAngles;
                Vector2 deltaInput = _InputManager.getMouseDelta();
                StartingRotation.x += deltaInput.x *horizontalSpeed * Time.deltaTime;
                StartingRotation.y += deltaInput.y * verticallSpeed *Time.deltaTime;

                if(_InputManager.getPlayerMovement().magnitude > new Vector2(0, 0).magnitude)
                {
                    sinTime += Time.deltaTime * EffectSpeed;
                    StartingRotation.z = Mathf.Sin(sinTime) * WalkingEffectAmount;
                }



                StartingRotation.y = Mathf.Clamp(StartingRotation.y, -clampAngel, clampAngel);
                state.RawOrientation = Quaternion.Euler(-StartingRotation.y, StartingRotation.x, StartingRotation.z);
            }
        }
    }
}
