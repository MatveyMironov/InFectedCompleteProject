using SprintSystem;
using UnityEngine;

namespace PlayerSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        private Rigidbody2D _playerRigidbody;

        [Header("Parameters")]
        [SerializeField] private float maxWalkingSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;
        [SerializeField] private float turningSpeed;
        [SerializeField] private bool turnInstantly;

        [Header("Sprinting")]
        [SerializeField] private float maxSprintingSpeed;
        [SerializeField] private StaminaController staminaController;
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

        public void Move(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }

        public void StopMoving()
        {
            Move(new(0.0f, 0.0f));
        }

        public void Sprint(bool isSprinting)
        {
            //Debug.Log("Sprint");

            if (staminaController.AvailableStamina <= 0)
            {
                //Debug.Log("Unaible to sprint");
                return;
            }

            _isSprinting = isSprinting;
            //Debug.Log("Is sprinting");
        }

        public void Aim(Vector2 aimPosition)
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
            //Debug.Log("Use stamina");
            staminaController.AvailableStamina -= Time.deltaTime * staminaUseRate;

            if (staminaController.AvailableStamina <= 0)
            {
                //Debug.Log("No stamina left");
                _isSprinting = false;
            }
        }
    }
}