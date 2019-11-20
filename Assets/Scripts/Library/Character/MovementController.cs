using Library.Events;
using UnityEngine;
using NaughtyAttributes;

namespace Library.Character
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class MovementController : MonoBehaviour
    {
        [BoxGroup("Variables")]
        [SerializeField] 
        private float movementSpeed = 3f;
        [BoxGroup("Variables")]
        [SerializeField] 
        private float speedSmoothTime = 0.1f;
        [BoxGroup("Variables")]
        [SerializeField] 
        private float rotationSmoothTime = 0.1f;
        
        private CharacterController _controller = null;
        private Animator _animator = null;
        private Transform _mainCameraTransform = null;
        //private float _velocityY = 0f;
        private float _speedSmoothVelocity = 0f;
        private float _currentSpeed = 0f;

        private Rigidbody rb;

        private static readonly int HashSpeedPercentage = Animator.StringToHash("SpeedPercentage");

        private void Start()
        {
            _controller = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();
            if (Camera.main != null) _mainCameraTransform = Camera.main.transform;
            rb = gameObject.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            rb.isKinematic = PauseMenu.Instance.pauseActive;
            Move();
        }

        private void Move()
        {
           var movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
           var forward = _mainCameraTransform.forward;
           var right = _mainCameraTransform.right;

           forward.y = 0;
           right.y = 0;
           
           forward.Normalize();
           right.Normalize();

           var desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;

           if (desiredMoveDirection != Vector3.zero)
           {
               transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSmoothTime);
           }

           var targetSpeed = movementSpeed * movementInput.magnitude;
           _currentSpeed = Mathf.SmoothDamp(_currentSpeed, targetSpeed, ref _speedSmoothVelocity, speedSmoothTime);
            
           _controller.Move(Time.deltaTime * _currentSpeed * desiredMoveDirection);
           
           //_animator.SetFloat(HashSpeedPercentage, 0.5f * movementInput.magnitude, speedSmoothTime, Time.deltaTime);
        }

        public void ChangeColor()
        {
            this.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
