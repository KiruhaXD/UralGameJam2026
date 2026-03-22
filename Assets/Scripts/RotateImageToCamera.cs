using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class RotateImageToCamera : MonoBehaviour
{
    [SerializeField] CinemachineCamera cinemachineCamera;
    [SerializeField] Image currentImage;

    void Update()
    {
        currentImage.rectTransform.rotation = cinemachineCamera.transform.rotation;        
    }
}
