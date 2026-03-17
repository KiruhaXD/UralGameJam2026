using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider sliderHealth;

    [SerializeField] Animator playerAnimator;

    public void TakeHit() 
    {
        playerAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit() 
    {
        yield return new WaitForSeconds(.5f);
        playerAnimator.SetBool("isHit", false);
    }
}
