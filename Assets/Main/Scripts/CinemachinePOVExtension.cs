using UnityEngine;
using Cinemachine;
public class CinemachinePOVExtension : CinemachineExtension
{
    private InputManager _InputManager;
    private Vector3 StartingRotation;

    [SerializeField] private float horizontalSpeed = 10f;
    [SerializeField] private float verticallSpeed = 10f;

    [SerializeField] private float clampAngel = 80f;




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
                StartingRotation.y = Mathf.Clamp(StartingRotation.y, -clampAngel, clampAngel);
                state.RawOrientation = Quaternion.Euler(-StartingRotation.y, StartingRotation.x, 0f);
            }
        }
    }
}
