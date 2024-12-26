using SprintSystem;
using UnityEngine;
using WeaponSystem;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _playerRigidbody;

        [Header("Parameters")]
        [SerializeField] private float maxWalkingSpeed;
        [SerializeField] private float maxSprintingSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;
        [SerializeField] private float turningSpeed;
        [SerializeField] private bool turnInstantly;

        [Header("Stamina")]
        [SerializeField] private float staminaUseRate;

        [Header("Animation")]
        [SerializeField] private Animator animator;
        [Tooltip("Speed at which walking animation will be started")]
        [SerializeField] private float walkingThreshold;
        [Tooltip("Speed at which sprinting animation will be started")]
        [SerializeField] private float sprintingThreshold;

        [Header("Audio")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip walkingClip;
        [SerializeField] private AudioClip sprintingClip;

        private Vector2 _movementDirection;
        private bool _isSprinting;
        private float _aimAngle;

        private StaminaController _staminaController;
        private float _staminaUseTimer = 0;

        private Movement _movement;
        private Turning _turning;

        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody2D>();
            _movement = new(_playerRigidbody);
            _turning = new(_playerRigidbody);
        }

        private void Update()
        {
            HandleMovement();
            HandleTurning();
            HandleEffects();

            /*
            if (_isSprinting && _movement.CurrentSpeed > 0)
            {
                weaponUser.ReadyToUseWeapon = false;
                weaponUser.ReleaseWeaponTrigger();
            }
            else
            {
                weaponUser.ReadyToUseWeapon = true;
            }*/

        }

        public void Setup(StaminaController staminaController)
        {
            _staminaController = staminaController;
        }

        public void SetMovementDirection(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }

        public void SetSprint(bool isSprinting)
        {
            if (_staminaController.AvailableStamina <= 0) return;

            _isSprinting = isSprinting;
        }

        public void SetAim(Vector2 aimPosition)
        {
            Vector2 aimDirection = aimPosition - _playerRigidbody.position;
            _aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90.0f;
        }

        private float CalculateTurningAngle(Vector2 turnDirection)
        {
            return Mathf.Atan2(turnDirection.y, turnDirection.x) * Mathf.Rad2Deg - 90.0f;
        }

        private void HandleMovement()
        {
            Vector2 targetVelocity;

            if (_isSprinting)
            {
                targetVelocity = _movementDirection * maxSprintingSpeed;
                UseStamina();
            }
            else
            {
                targetVelocity = _movementDirection * maxWalkingSpeed;
            }

            _movement.Move(targetVelocity, acceleration, deceleration);
        }

        private void HandleTurning()
        {
            float turnAngle;

            if (_isSprinting && _movement.CurrentSpeed > 0)
            {
                turnAngle = CalculateTurningAngle(_movementDirection);
            }
            else
            {
                turnAngle = _aimAngle;
            }

            if (turnInstantly)
            {
                _turning.TurnInstantly(turnAngle);
            }
            else
            {
                _turning.TurnWithSpeed(turnAngle, turningSpeed);
            }
        }

        private void HandleEffects()
        {
            if (_movement.CurrentSpeed > walkingThreshold)
            {
                animator.SetBool("IsMoving", true);

                if (_movement.CurrentSpeed > sprintingThreshold)
                {
                    animator.SetBool("IsSprinting", true);

                    if (audioSource.clip != sprintingClip)
                    {
                        audioSource.clip = sprintingClip;
                    }
                }
                else
                {
                    if (audioSource.clip != walkingClip)
                    {
                        audioSource.clip = walkingClip;
                    }
                }

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                animator.SetBool("IsMoving", false);
                audioSource.Stop();
            }
        }

        private void UseStamina()
        {
            _staminaUseTimer += Time.deltaTime * staminaUseRate;
            if (_staminaUseTimer >= 1)
            {
                _staminaUseTimer -= 1;
                _staminaController.AvailableStamina -= 1;
                {
                    if (_staminaController.AvailableStamina <= 0)
                    {
                        _staminaUseTimer = 0;
                        _isSprinting = false;
                    }
                }
            }
        }
    }
}