using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{




    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float playerRunSpeed;
    private float initialSpeed;

    [SerializeField] private float jumpHeight = 1.0f;

    [SerializeField] private float gravityValue = -9.81f;

    private InputManager inputManager;
    private Transform cameraTransform;


    [SerializeField] private float BobbingEffectSpeed = 10f;
    [SerializeField] private float BobbingEffectAmount = 10f;
    [SerializeField] private Transform EyesOfPlayer;
    private float sinTime;
    [SerializeField] private Transform Vcam;


    [SerializeField] private AudioClip[] footstepSounds; 
    private AudioSource audioSource; 
    private float footstepTimer;
    [SerializeField] private float footstepInterval = 0.5f; 
    [SerializeField] private float footstepVolume = 0.5f;


    private void Start()
    {
        inputManager = InputManager.Instance;
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        initialSpeed = playerSpeed;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (inputManager.PlayerRunThisFrame())
        {
            playerSpeed = playerRunSpeed;
        }
        else
        {
            playerSpeed = initialSpeed;
        }

        Vector2 movement = inputManager.getPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right *move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        if (move != Vector3.zero && groundedPlayer)
        {
            footstepTimer += Time.deltaTime;
            if (footstepTimer >= footstepInterval)
            {
                PlayFootstepSound();
                footstepTimer = 0f;
            }
        }


        if (inputManager.PlayerJumpThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        BlobbingEffect();


    }




    private void BlobbingEffect()
    {
        sinTime += Time.deltaTime * BobbingEffectSpeed;
        float sinAmountY = Mathf.Sin(sinTime) * BobbingEffectAmount;  
        EyesOfPlayer.localPosition += new Vector3(0, sinAmountY, 0);


    }


    private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            AudioClip footstepSound = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(footstepSound, footstepVolume);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FrameFramePath framePath))
        {
            Debug.Log("triggerd");
            framePath.PathStarer();
        }
    }

}
