using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Outline")]
    [SerializeField] Outline outlineInteractObject;

    [Header("Ray")]
    [SerializeField] Transform rayPoint;

    [Header("Settings")]
    [SerializeField] float interactDistanceRay = 3f;

    [Header("Image")]
    [SerializeField] Image imageInteraction;

    public static bool isActiveRay = false;

    private void Start()
    {
        isActiveRay = true;
    }

    private void Update()
    {
        if(isActiveRay == true)
            InteractionRay();

        else
            imageInteraction.gameObject.SetActive(isActiveRay);
    }

    private void InteractionRay()
    {
        Vector3 positionRay = rayPoint.transform.position;
        Vector3 directionRay = rayPoint.transform.forward;

        RaycastHit hit;

        bool hitSomething = false;

        Debug.DrawRay(positionRay, directionRay, Color.red);

        if (Physics.Raycast(positionRay, directionRay, out hit, interactDistanceRay))
        {
            IInteract interact = hit.collider.GetComponent<IInteract>();

            //Debug.Log($" позиция луча: {positionRay} / направление луча: {directionRay}, сам луч: {hit}");

            if (interact != null && hit.collider.tag == "BrokenRobot")
            {
                //Debug.Log($"луч столкнулся с тегом: {hit.collider.tag}");

                interact.Description();
                hitSomething = true;

                if (Input.GetKeyDown(KeyCode.F))
                    interact.Interact();
            }
        }

        imageInteraction.gameObject.SetActive(hitSomething);
        outlineInteractObject.enabled = hitSomething;


    }
}
