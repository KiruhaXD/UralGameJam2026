using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthCount = 100;

    public TMP_Text textHealth;

    [SerializeField] Animator playerAnimator;

    public void TakeHit() 
    {
        playerAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit() 
    {
        yield return new WaitForSeconds(1);
        playerAnimator.SetBool("isHit", false);
    }
}
