using UnityEngine;

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

    private void Update()
    {
        RotateBody();
    }

    private void InputMouse() 
    {
        mouseX = Input.GetAxisRaw("Mouse X") * mouseSensivity * Time.deltaTime;
    }

    private void RotateBody() 
    {
        InputMouse();

        if (mouseX != 0) 
        {
            xRotationLimit += mouseX;
            xRotationLimit = Mathf.Clamp(xRotationLimit, -20f, 20f);

            playerRotation.Rotate(new Vector3(0f, mouseX, 0f));

            animator.SetBool("isRunning", true);
        }

        else
            animator.SetBool("isRunning", false);

    }
}
