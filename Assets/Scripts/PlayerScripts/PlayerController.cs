using System.Threading;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts 
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Animator")]
        [SerializeField] Animator animator;

        [Header("Settings")]
        [SerializeField] float speedRun = 6f;

        [Header("Character Contoller")]
        [SerializeField] CharacterController characterController;

        [Header("Player Rotation")]
        [SerializeField] Transform playerRotation;

        public float horizontalDirectional;
        public float verticalDirectional;

        Vector3 moveDirectional;

        private void Update()
        {
            Run();
        }

        private void InputKeyboards()
        {
            horizontalDirectional = Input.GetAxis("Horizontal");
            verticalDirectional = Input.GetAxis("Vertical");
        }

        private void Run()
        {
            InputKeyboards();

            if (horizontalDirectional != 0 || verticalDirectional != 0)
            {
                animator.SetBool("isRunningKeyboardInput", true);

                moveDirectional = transform.TransformDirection(new Vector3(horizontalDirectional, 0f, verticalDirectional));
                characterController.Move(moveDirectional * speedRun * Time.deltaTime);

                playerRotation.Rotate(new Vector3(0f, horizontalDirectional, 0f));
            }

            else
                animator.SetBool("isRunningKeyboardInput", false);

        }
    }
}

