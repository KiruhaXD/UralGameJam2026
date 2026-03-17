using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider sliderHealth;

    [SerializeField] Animator enemyAnimator;

    public int currentNumberEnemy;

    public void TakeHit()
    {
        enemyAnimator.SetBool("isHit", true);

        StartCoroutine(AfterHit());
    }

    IEnumerator AfterHit()
    {
        yield return new WaitForSeconds(.5f);
        enemyAnimator.SetBool("isHit", false);
    }
}
