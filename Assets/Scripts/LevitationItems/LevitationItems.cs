using UnityEngine;

public class LevitationItems : MonoBehaviour
{
    [SerializeField] float hoverHeight = 2f;
    [SerializeField] float hoverForce = 12f;
    [SerializeField] float spinTorque = 5f;

    [SerializeField] Rigidbody rb;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, hoverHeight)) 
        {
            float distanceRatio = 1f - (hit.distance / hoverHeight);
            Vector3 liftForce = Vector3.up * hoverForce * distanceRatio;
            rb.AddForce(liftForce, ForceMode.Force);
        }

        rb.AddTorque(Vector3.up * spinTorque, ForceMode.Force);
    }
}
