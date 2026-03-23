using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    public void ExitToMenu() => SceneManager.LoadScene("MenuScene");
}
