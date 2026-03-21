using System;
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
    [SerializeField] GameObject[] imagesEffectsWindowChoise; // done

    [SerializeField] GameObject choiseEffectAttackWindow;

    public int currentChoiseIndex = 0;

    private void Update()
    {
        if (choiseEffectAttackWindow.activeSelf == true) 
        {
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
        currentChoiseIndex = 1;

        if(currentChoiseIndex == choiseBrotherIndex)
            UseEffectAttack(currentChoiseIndex);

        EnableScriptsAndHideCursor();
    }

    public void ChoisePlayerClickBtn(int choisePlayerIndex) 
    {
        currentChoiseIndex = 0;

        if(currentChoiseIndex == choisePlayerIndex)
            UseEffectAttack(currentChoiseIndex);

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
                        imagesSlotEffects[choiseIndex].sprite = sprites[0];
                        effectItemsTrigger[0].tagCurrentEffect = "";

                        choiseEffectAttack[choiseIndex].currentEffect = 1;
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[0].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[2].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[3].gameObject.SetActive(false);

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[1].gameObject.SetActive(true);
                        break;

                    case "EffectShock":
                        imagesSlotEffects[choiseIndex].sprite = sprites[1];
                        effectItemsTrigger[1].tagCurrentEffect = "";

                        choiseEffectAttack[choiseIndex].currentEffect = 2;

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[0].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[1].gameObject.SetActive(false);
                        choiseEffectAttack[choiseIndex].particleSystemsAttack[3].gameObject.SetActive(false);

                        choiseEffectAttack[choiseIndex].particleSystemsAttack[2].gameObject.SetActive(true);
                        break;

                    case "EffectFire":
                        imagesSlotEffects[choiseIndex].sprite = sprites[2];
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
