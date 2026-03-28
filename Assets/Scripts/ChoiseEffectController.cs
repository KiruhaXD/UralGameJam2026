using Assets.Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseEffectController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BrotherRobotController brotherRobotController;
    [SerializeField] CameraController cameraController;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator brotherAnimator;

    [SerializeField] ChoiseEffectAttack[] choiseEffectAttack;
    [SerializeField] EffectItemTrigger[] effectItemsTrigger; // done

    [SerializeField] Sprite[] sprites; // done
    [SerializeField] Image[] imagesSlotEffects; // done

    [Header("Background")]
    [SerializeField] Sprite[] spritesBoards;
    [SerializeField] Image[] imagesSlotEffectsBackground; // done

    [SerializeField] GameObject[] imagesEffectsWindowChoise; // done

    [SerializeField] GameObject choiseEffectAttackWindow;

    public int currentChoiseCharacterIndex = 0;  // 0 - Player, 1 - Brother

    public bool isPickUpEffectIce, isPickUpEffectShock, isPickUpEffectFire = false;

    public bool menuChoiseEffectActive = false;

    private void Update()
    {
        if (choiseEffectAttackWindow.activeSelf == true) 
        {
            menuChoiseEffectActive = true;

            for (int i = 0; i < imagesEffectsWindowChoise.Length; i++)
            {
                for (int j = 0; j < effectItemsTrigger.Length; j++)
                {
                    imagesEffectsWindowChoise[i].SetActive(false); // hide not use icons in window choise effect

                    switch (effectItemsTrigger[j].tagCurrentEffect)
                    {
                        case "EffectIce":
                            imagesEffectsWindowChoise[0].SetActive(true); // show icon in window choise effect
                            break;

                        case "EffectShock":
                            imagesEffectsWindowChoise[1].SetActive(true);
                            break;

                        case "EffectFire":
                            imagesEffectsWindowChoise[2].SetActive(true);
                            break;
                    }
                }
            }
        }
    }

    public void ChoiseBrotherClickBtn(int choiseBrotherIndex) 
    {
        currentChoiseCharacterIndex = 1;

        menuChoiseEffectActive = false;

        if (currentChoiseCharacterIndex == choiseBrotherIndex)
            UseEffectAttack(currentChoiseCharacterIndex);

        EnableScriptsAndHideCursor();
    }

    public void ChoisePlayerClickBtn(int choisePlayerIndex) 
    {
        currentChoiseCharacterIndex = 0;

        menuChoiseEffectActive = false;

        if (currentChoiseCharacterIndex == choisePlayerIndex)
            UseEffectAttack(currentChoiseCharacterIndex);

        EnableScriptsAndHideCursor();
    }

    public void UseEffectAttack(int choiseIndex) 
    {
        imagesSlotEffects[choiseIndex].gameObject.SetActive(true);

        for (int i = 0; i < effectItemsTrigger.Length; i++)
        {
            for (int k = 0; k < choiseEffectAttack[choiseIndex].particleSystemsAttack.Length; k++)
            {
                switch (effectItemsTrigger[i].tagCurrentEffect)
                {
                    case "EffectIce":

                        isPickUpEffectIce = true;

                        imagesSlotEffects[choiseIndex].sprite = sprites[0];
                        imagesSlotEffectsBackground[choiseIndex].sprite = spritesBoards[0];

                        effectItemsTrigger[0].tagCurrentEffect = "";

                        choiseEffectAttack[choiseIndex].currentEffect = 1;
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[0].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[2].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[3].gameObject.SetActive(false);

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[1].gameObject.SetActive(true);
                        break;

                    case "EffectShock":

                        isPickUpEffectShock = true;

                        imagesSlotEffects[choiseIndex].sprite = sprites[1];
                        imagesSlotEffectsBackground[choiseIndex].sprite = spritesBoards[1];

                        effectItemsTrigger[1].tagCurrentEffect = "";

                        choiseEffectAttack[choiseIndex].currentEffect = 2;

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[0].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[1].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[3].gameObject.SetActive(false);

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[2].gameObject.SetActive(true);
                        break;

                    case "EffectFire":

                        isPickUpEffectFire = true;

                        imagesSlotEffects[choiseIndex].sprite = sprites[2];
                        imagesSlotEffectsBackground[choiseIndex].sprite = spritesBoards[2];

                        effectItemsTrigger[2].tagCurrentEffect = "";

                        choiseEffectAttack[choiseIndex].currentEffect = 3;

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[0].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[1].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[2].gameObject.SetActive(false);

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[3].gameObject.SetActive(true);
                        break;
                }
            }
        }

    }

    public void EnableScriptsAndHideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerController.enabled = true;
        brotherRobotController.enabled = true;
        cameraController.enabled = true;
        playerAnimator.enabled = true;
        brotherAnimator.enabled = true;

        choiseEffectAttackWindow.SetActive(false);
    }
}
