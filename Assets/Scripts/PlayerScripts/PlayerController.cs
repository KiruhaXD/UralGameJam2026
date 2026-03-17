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

                animator.SetBool("isRunning", true);

                moveDirectional = transform.TransformDirection(new Vector3(horizontalDirectional, 0f, verticalDirectional));
                characterController.Move(moveDirectional * speedRun * Time.deltaTime);
            }

            else
                animator.SetBool("isRunning", false);

        }
    }
}

