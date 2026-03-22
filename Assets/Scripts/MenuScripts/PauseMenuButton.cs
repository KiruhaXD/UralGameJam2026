using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButton : MonoBehaviour
{
    [SerializeField] AudioSource audioInterface;

    [SerializeField] Button currentButton;

    public void PointerEnterBtn() 
    {
        audioInterface.Play();

        currentButton.transform.DOScale(new Vector3(2f, 2f, 2f), .2f);
    }

    public void PointerExitBtn() 
    {
        currentButton.transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), .2f);
    }
}
