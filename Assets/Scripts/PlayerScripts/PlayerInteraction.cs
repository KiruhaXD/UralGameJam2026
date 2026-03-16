using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Ray")]
    [SerializeField] Transform rayPoint;

    [Header("Settings")]
    [SerializeField] float interactDistance = 3f;

    [Header("Image")]
    [SerializeField] Image imageInteraction;

    private void Update()
    {
        InteractionRay();
    }

    private void InteractionRay()
    {
        Vector3 positionRay = rayPoint.transform.position;
        Vector3 directionRay = rayPoint.transform.forward;

        RaycastHit hit;

        bool hitSomething = false;

        Debug.DrawRay(positionRay, directionRay, Color.red);

        if (Physics.Raycast(positionRay, directionRay, out hit, interactDistance))
        {
            IInteract interact = hit.collider.GetComponent<IInteract>();

            Debug.Log($" позиция луча: {positionRay} / направление луча: {directionRay}, сам луч: {hit}");

            if (interact != null && hit.collider.tag == "BrokenRobot")
            {
                Debug.Log($"луч столкнулся с тегом: {hit.collider.tag}");

                interact.Description();
                hitSomething = true;

                if(Input.GetKeyDown(KeyCode.F))
                    interact.Interact();
            }

        }

        imageInteraction.gameObject.SetActive(hitSomething);
    }
}
