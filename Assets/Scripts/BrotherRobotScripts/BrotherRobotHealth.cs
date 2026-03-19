using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrotherRobotHealth : MonoBehaviour
{
    public Slider sliderHealth;

    [SerializeField] Animator brotherAnimator;

    public void TakeHit()
    {
        brotherAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.5f);
        brotherAnimator.SetBool("isHit", false);
    }
}
