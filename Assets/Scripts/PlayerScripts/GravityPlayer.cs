using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class GravityPlayer : MonoBehaviour
    {
        [Header("Check Ground")]
        [SerializeField] LayerMask groundMask;
        [SerializeField] float groundDistance;
        [SerializeField] Transform groundPoint;

        [Header("Character Controller")]
        [SerializeField] CharacterController characterController;

        bool isGrounded = false;

        Vector3 velocity;

        float gravity = -9.81f;

        private void Update()
        {
            CheckGround();
        }

        private void CheckGround()
        {
            isGrounded = Physics.CheckSphere(groundPoint.position, groundDistance, groundMask);

            if (isGrounded == true && velocity.y < 0)
                velocity.y = -2f;

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);


        }
    }
}