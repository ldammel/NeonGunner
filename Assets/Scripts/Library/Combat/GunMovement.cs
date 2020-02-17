using Library.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Library.Combat
{
    public class GunMovement : MonoBehaviour
    {
        [SerializeField]
        private float rotationSpeed = 2.0f;
        private Vector3 _rotation = Vector3.zero;
        
        [SerializeField] private Image crosshair;
        [SerializeField] private Slider sensitivitySlider;

        [SerializeField] private float sphereCastSize;
        
        public Camera mainCamera;
        public Ray crossHairRay;
        
        public bool isFlame;

        private void Start()
        {
            rotationSpeed = sensitivitySlider.value;
            crosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        public void ChangeSpeed()
        {
            rotationSpeed = sensitivitySlider.value;
        }

        private float ClampAngle(float angle, float from, float to)
        {
            if (angle < 0f) angle = 360 + angle;
            return angle > 180f ? Mathf.Max(angle, 360+@from) : Mathf.Min(angle, to);
        }

        private void FixedUpdate()
        {
            if (PauseMenu.Instance.pauseActive) return;
            _rotation.x = Input.GetAxis("Mouse X")* Time.deltaTime * rotationSpeed;
            _rotation.y = Input.GetAxis("Mouse Y")* Time.deltaTime * rotationSpeed;
            _rotation.z = 0;

            var rot = transform.localRotation.eulerAngles + new Vector3(-_rotation.y, _rotation.x, 0f);
            rot.x = ClampAngle(rot.x, -40f, isFlame? 5 : 30f);
            if(isFlame)rot.y = ClampAngle(rot.y, -30f, 40f);

            gameObject.transform.localEulerAngles = rot;
        }
        
        private void Update()
        {
            if (PauseMenu.Instance.pauseActive) return;
            var centerOfCrosshair = crosshair.transform.position;
            crossHairRay = mainCamera.ScreenPointToRay(centerOfCrosshair);

            if (Physics.SphereCast(crossHairRay, sphereCastSize,out RaycastHit hitInfo, 2000f, LayerMask.GetMask("Enemy")))
            {
                crosshair.color = Color.red;
            }
            else if (Physics.SphereCast(crossHairRay, 0.1f, 300f, LayerMask.GetMask("Player")))
            {
                crosshair.color = Color.green;
            }
            else
            {
                crosshair.color = Color.white;
            }
        }
    }
}
