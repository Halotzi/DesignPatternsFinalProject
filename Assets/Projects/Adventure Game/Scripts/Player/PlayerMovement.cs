using UnityEngine;

namespace AdventureGame
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed;

        [SerializeField]
        private float jumpSpeed;


        [SerializeField] private float _jumpButtonGracePeriod;
        [SerializeField] private float _jumpHorizontalSpeed;
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        private float ySpeed;
        private float originalStepOffset;
        private float? lastGroundedTime;
        private float? jumpButtonPressedTime;
        private bool _isGrounded;
        private bool _isJumping;
        private bool _isFalling;

        // Start is called before the first frame update
        void Start()
        {
            originalStepOffset = _characterController.stepOffset;
            GameManager.Instance.CoinManager.OnCollected += CoinCollected;
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical") ;

            Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

            _animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime);
            movementDirection = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
            movementDirection.Normalize();

            ySpeed += Physics.gravity.y * Time.deltaTime;

            if (_characterController.isGrounded)
            {
                lastGroundedTime = Time.time;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jumpButtonPressedTime = Time.time;
            }

            if (Time.time - lastGroundedTime <= _jumpButtonGracePeriod)
            {
                _characterController.stepOffset = originalStepOffset;
                ySpeed = -0.5f;
                ChangeAnimatorStateToGrounded();

                if (Time.time - jumpButtonPressedTime <= _jumpButtonGracePeriod)
                {
                    ySpeed = jumpSpeed;
                    ChangeAnimatorStateToJumping();
                    jumpButtonPressedTime = null;
                    lastGroundedTime = null;
                }
            }
            else
            {
                _characterController.stepOffset = 0;
                _animator.SetBool("IsGrounded", false);
                _isGrounded = false;

                if ((_isJumping && ySpeed < 0) || ySpeed < -2)
                    ChangeAnimatorStateToFalling();
            }

            if (movementDirection != Vector3.zero)
            {
                _animator.SetBool("IsMoving", true);

                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                _animator.SetBool("IsMoving", false);
                inputMagnitude = 0;
                _animator.SetFloat("Input Magnitude", 0);
            }

            if (!_isGrounded)
            {
                Vector3 velocity = movementDirection * inputMagnitude * _jumpHorizontalSpeed;
                velocity.y = ySpeed;

                _characterController.Move(velocity * Time.deltaTime);
            }
        }

        private void OnAnimatorMove()
        {
            if (_isGrounded)
            {
                Vector3 velocity = _animator.deltaPosition;
                velocity.y = ySpeed * Time.deltaTime;

                _characterController.Move(velocity);
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        private void ChangeAnimatorStateToJumping()
        {
            _isJumping = true;
            _animator.SetBool("IsJumping", true);
            _isFalling = false;
            _animator.SetBool("IsFalling", false);
            _isGrounded = false;
            _animator.SetBool("IsGrounded", false);
        }

        private void ChangeAnimatorStateToFalling()
        {
            _isJumping = false;
            _animator.SetBool("IsJumping", false);
            _isFalling = true;
            _animator.SetBool("IsFalling", true);
            _isGrounded = false;
            _animator.SetBool("IsGrounded", false);
        }
        private void ChangeAnimatorStateToGrounded()
        {
            _isJumping = false;
            _animator.SetBool("IsJumping", false);
            _isFalling = false;
            _animator.SetBool("IsFalling", false);
            _isGrounded = true;
            _animator.SetBool("IsGrounded", true);
        }

        private void CoinCollected(bool isCollected)
        {
            if(isCollected)
            ySpeed += 0.1f;
        }

        private void OnDestroy()
        {
            GameManager.Instance.CoinManager.OnCollected -= CoinCollected;
        }
    }

}
