using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpaceShooter3D.Mechanics
{
    public class ShipMovement : MonoBehaviour
    {
        public CommonLogic.MoveJoystick Joystick;  
        public Button RightTilt;       
        public Button LeftTilt;        

        public float MoveSpeed = 10f;  
        public float TiltSpeed = 100f; 

        private float _verticalInput;
        private float _horizontalInput;
        private float _zRotation;
        private bool _isRotatingRight = false;
        private bool _isRotatingLeft = false; 

        void Start()
        {
            AddButtonListeners(RightTilt, () => _isRotatingRight = true, () => _isRotatingRight = false);
            AddButtonListeners(LeftTilt, () => _isRotatingLeft = true, () => _isRotatingLeft = false);
        }

        void Update()
        {
            GetInput();
            MoveSpaceship();
            HandleRotation();
        }

        private void GetInput()
        {
            InputXY();
        }

        private void InputXY()
        {
            _horizontalInput = Joystick.Horizontal();
            _verticalInput = Joystick.Vertical();

            if (_verticalInput != 0 || _horizontalInput != 0)
            {
                MoveSpaceship();
            }
        }

        private void MoveSpaceship()
        {
            Vector3 moveDirection = new Vector3(_horizontalInput, _verticalInput, 0).normalized;
            transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);
        }

        private void HandleRotation()
        {
            if (_isRotatingRight)
            {
                RotateRight();
            }
            if (_isRotatingLeft)
            {
                RotateLeft();
            }
        }

        private void RotateRight()
        {
            _zRotation -= TiltSpeed * Time.deltaTime;
            RotateSpaceship();
        }

        private void RotateLeft()
        {
            _zRotation += TiltSpeed * Time.deltaTime;
            RotateSpaceship();
        }

        private void RotateSpaceship()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, _zRotation);
        }

        private void AddButtonListeners(Button button, System.Action onPointerDown, System.Action onPointerUp)
        {
            EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
            pointerDownEntry.eventID = EventTriggerType.PointerDown;
            pointerDownEntry.callback.AddListener((eventData) => { onPointerDown(); });
            trigger.triggers.Add(pointerDownEntry);

            EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry();
            pointerUpEntry.eventID = EventTriggerType.PointerUp;
            pointerUpEntry.callback.AddListener((eventData) => { onPointerUp(); });
            trigger.triggers.Add(pointerUpEntry);
        }
    }
}
