using System.Threading;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts 
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] AttackRangePlayer attackRangePlayer;

        [SerializeField] MenuPause menuPause;

        [Header("Audio")]
        [SerializeField] AudioSource audioRun;

        [Header("Animator")]
        [SerializeField] Animator animator;

        [Header("Settings")]
        [SerializeField] float speedRun = 6f;

        [Header("Player Character Contoller")]
        [SerializeField] CharacterController playerCharacterController;

        [Header("Player Rotation")]
        [SerializeField] Transform playerRotation;

        public float horizontalDirectional;
        public float verticalDirectional;

        Vector3 moveDirectional;

        private void Update()
        {
            if (menuPause.countPressKeyEscape == 1)
            {
                horizontalDirectional = 0;
                verticalDirectional = 0;
            }

            else if(attackRangePlayer.isPunch == false)
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

                playerCharacterController.Move(moveDirectional * speedRun * Time.deltaTime);

                playerRotation.Rotate(new Vector3(0f, horizontalDirectional, 0f));

                if (audioRun.isPlaying) return;
                audioRun.Play();
            }

            else
            {
                animator.SetBool("isRunningKeyboardInput", false);
                audioRun.Stop();
            }


        }
    }
}

