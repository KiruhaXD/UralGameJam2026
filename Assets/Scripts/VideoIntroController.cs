using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoIntroController : MonoBehaviour
{
    public int timeVideoIntro;

    private void Awake()
    {
        StartCoroutine(VideoIntroLoadSceneCoroutine());
    }

    IEnumerator VideoIntroLoadSceneCoroutine() 
    {
        yield return new WaitForSeconds(timeVideoIntro);
        SceneManager.LoadScene("MenuScene");
    }
}
