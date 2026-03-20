using System;
using Assets.Scripts.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseEffectController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] BrotherRobotController brotherRobotController;
    [SerializeField] CameraController cameraController;

    [SerializeField] ChoiseEffectAttack[] choiseEffectsAttacks;
    [SerializeField] EffectItemTrigger[] effectItemsTrigger; // done

    [SerializeField] Sprite[] sprites;
    [SerializeField] Image[] imagesSlotEffects;
    [SerializeField] GameObject[] imagesEffectsWindowChoise; // done

    [SerializeField] GameObject choiseEffectAttackWindow;

    //public int currentEffectTag = 0;

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
        int curentChoiseIndex = 1;

        if(curentChoiseIndex == choiseBrotherIndex)
            PickUpEffectAttack(curentChoiseIndex);

        EnableScriptsAndHideCursor();
    }

    public void ChoisePlayerClickBtn(int choisePlayerIndex) 
    {
        int curentChoiseIndex = 0;

        if(curentChoiseIndex == choisePlayerIndex)
            PickUpEffectAttack(curentChoiseIndex);

        EnableScriptsAndHideCursor();
    }

    public void PickUpEffectAttack(int choiseIndex) 
    {
        imagesSlotEffects[choiseIndex].gameObject.SetActive(true);

        for (int k = 0; k < effectItemsTrigger.Length; k++)
        {
            switch (effectItemsTrigger[k].tagCurrentEffect)
            {
                case "EffectIce":
                    
                    imagesSlotEffects[choiseIndex].sprite = sprites[0];
                    effectItemsTrigger[0].tagCurrentEffect = "";
                    break;

                case "EffectShock":
                    imagesSlotEffects[choiseIndex].sprite = sprites[1];
                    effectItemsTrigger[1].tagCurrentEffect = "";
                    break;

                case "EffectFire":
                    imagesSlotEffects[choiseIndex].sprite = sprites[2];
                    effectItemsTrigger[2].tagCurrentEffect = "";
                    break;
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

        choiseEffectAttackWindow.SetActive(false);
    }
}
