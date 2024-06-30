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
    private float initialEffectSpeed;

    [SerializeField] private float WalkingEffectAmount = 0.3f;
    private float initialWalkingEffectAmount;
    [SerializeField] private float RunMultpl;
    private float sinTime;

    protected override void Awake()
    {
        _InputManager = InputManager.Instance;
        base.Awake();
    }


    private void Start()
    {
        initialWalkingEffectAmount = WalkingEffectAmount;
        initialEffectSpeed = EffectSpeed;
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
                    if (_InputManager.PlayerRunThisFrame())
                    {
                        EffectSpeed *= RunMultpl;
                        WalkingEffectAmount *= RunMultpl;
                        EffectSpeed = Mathf.Clamp(EffectSpeed, initialEffectSpeed, RunMultpl*initialEffectSpeed);
                        WalkingEffectAmount = Mathf.Clamp(WalkingEffectAmount, initialWalkingEffectAmount, RunMultpl * initialWalkingEffectAmount);
                    }
                    else
                    {
                        EffectSpeed = 5;
                        WalkingEffectAmount = initialWalkingEffectAmount;
                    }
                    sinTime += Time.deltaTime * EffectSpeed;
                    StartingRotation.z = Mathf.Sin(sinTime) * WalkingEffectAmount;
                }



                StartingRotation.y = Mathf.Clamp(StartingRotation.y, -clampAngel, clampAngel);
                state.RawOrientation = Quaternion.Euler(-StartingRotation.y, StartingRotation.x, StartingRotation.z);
            }
        }
    }
}
