using Unity.Cinemachine;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class CameraController : MonoBehaviour
    {
        [Header("Animator")]
        [SerializeField] Animator animator;

        [Header("Player Rotation")]
        [SerializeField] Transform playerRotation;

        [Header("Settings")]
        [SerializeField] float mouseSensivity = 100f;

        float mouseX;

        float xRotationLimit;

        public static bool isCanRotateBody = false;

        private void Awake()
        {
            isCanRotateBody = true;
        }

        private void Update()
        {
            if (isCanRotateBody == true)
                RotateBody();

        }

        private void InputMouse()
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        }

        private void RotateBody()
        {
            InputMouse();

            if (mouseX != 0)
            {
                animator.SetBool("isRunning", true);

                xRotationLimit += mouseX;
                xRotationLimit = Mathf.Clamp(xRotationLimit, -40f, 40f);

                playerRotation.Rotate(new Vector3(0f, mouseX, 0f));

                playerRotation.localRotation = Quaternion.Euler(0f, xRotationLimit, 0f);

            }

            else
                animator.SetBool("isRunning", false);

        }
    }
}
