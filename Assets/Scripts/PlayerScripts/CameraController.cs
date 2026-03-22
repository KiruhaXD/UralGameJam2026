using Unity.Cinemachine;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class CameraController : MonoBehaviour
    {
        [Header("Audio")]
        [SerializeField] AudioSource audioRun;

        [Header("Animator")]
        [SerializeField] Animator animator;

        [Header("Player Rotation")]
        [SerializeField] Transform playerRotation;

        [Header("Brother Rotation")]
        [SerializeField] Transform brotherRotation;

        [Header("Settings")]
        [SerializeField] float mouseSensivity = 100f;

        float mouseX;

        float xRotationLimit;

        private void Update()
        {
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
                animator.SetBool("isRunningMouseInput", true);

                xRotationLimit += mouseX;
                //xRotationLimit = Mathf.Clamp(xRotationLimit, -40f, 40f);

                playerRotation.Rotate(new Vector3(0f, mouseX, 0f));

                brotherRotation.Rotate(new Vector3(0f, mouseX, 0f));
                //playerRotation.localRotation = Quaternion.Euler(0f, xRotationLimit, 0f);

                if (audioRun.isPlaying) return;
                audioRun.PlayDelayed(0.1f);

            }

            else 
            {
                animator.SetBool("isRunningMouseInput", false);
                audioRun.Stop();
            }


        }
    }
}
