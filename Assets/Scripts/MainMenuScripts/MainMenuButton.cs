using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MainMenu
{
    [SerializeField] AudioSource audioEnterButton;

    [SerializeField] TMP_Text currentText;

    private void Start()
    {
        this.name = currentText.name;
    }

    public void OnMouseDown()
    {
        switch (currentText.name) 
        {
            case "Text (TMP) PLAY":
                SceneManager.LoadScene("GameScene");
                break;

            case "Text (TMP) SETTINGS":
                menuWindow.SetActive(false);
                settingsWindow.SetActive(true);
                break;

            case "Text (TMP) EXIT GAME":
                Application.Quit();
                break;
        }
    }

    private void OnMouseEnter()
    {
        audioEnterButton.Play();
        currentText.rectTransform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), .2f);
    }

    private void OnMouseExit()
    {
        currentText.rectTransform.DOScale(new Vector3(0.15f, 0.15f, 0.15f), .2f);
    }
}
