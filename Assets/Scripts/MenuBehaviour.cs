using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    private enum MenuScreen
    {
        HOME_SCREEN,
        REWARD_SCREEN,
        PROGRESSIVE_REWARD_SCREEN,
        PROGRESSIVE_REWARD_UNLOCK
    };

    [SerializeField]
    private MenuScreen menuScreen = MenuScreen.HOME_SCREEN;

    readonly private Dictionary<string, GameObject> homeScreenButtons = new();
    readonly private Dictionary<string, UnityEngine.Events.UnityAction> homeScreenActions = new();
    
    readonly private Dictionary<string, GameObject> rewardScreenButtons = new();
    readonly private Dictionary<string, UnityEngine.Events.UnityAction> rewardScreenActions = new();

    //private void OnGUI()
    //{
    //    if (GameObject.Find("Modal").TryGetComponent<ModalBehaviour>(out ModalBehaviour modal))
    //    {
    //        modal.IsActive = false;
    //    }
    //}

    private void Start()
    {
        if (menuScreen == MenuScreen.HOME_SCREEN)
        {
            homeScreenButtons.Add("settings", GameObject.Find("Settings"));
            homeScreenButtons.Add("spinWheel", GameObject.Find("Spin Wheel"));
            homeScreenButtons.Add("noAds", GameObject.Find("No ads"));
            homeScreenButtons.Add("lootBox", GameObject.Find("Loot Box"));
            homeScreenButtons.Add("tapToPlay", GameObject.Find("Tap To Play"));
            homeScreenButtons.Add("upgrade", GameObject.Find("Upgrade"));
            homeScreenButtons.Add("shop", GameObject.Find("Shop"));
            homeScreenButtons.Add("buildLevel", GameObject.Find("Build Level"));
            homeScreenButtons.Add("achievments", GameObject.Find("Achievments"));

            homeScreenActions.Add("settings", () => Settings());
            homeScreenActions.Add("spinWheel", () => SpinWheel());
            homeScreenActions.Add("noAds", () => NoAds());
            homeScreenActions.Add("lootBox", () => LootBox());
            homeScreenActions.Add("tapToPlay", () => TapToPlay());
            homeScreenActions.Add("upgrade", () => Upgrade());
            homeScreenActions.Add("shop", () => Shop());
            homeScreenActions.Add("buildLevel", () => BuildLevel());
            homeScreenActions.Add("achievments", () => Achievements());

            foreach (KeyValuePair<string, GameObject> keyValuePair in homeScreenButtons)
            {
                BindFunctionWithObjects(keyValuePair.Key, homeScreenButtons, homeScreenActions[keyValuePair.Key]);
            }
        }

        if (menuScreen == MenuScreen.REWARD_SCREEN)
        {
            rewardScreenButtons.Add("continue", GameObject.Find("Continue"));
            rewardScreenButtons.Add("noThanks", GameObject.Find("No Thanks"));
            rewardScreenButtons.Add("softCurrency", GameObject.Find("Soft Currency"));
            rewardScreenButtons.Add("hardCurrency", GameObject.Find("Hard Currency"));
            rewardScreenButtons.Add("claimAd", GameObject.Find("Claim Ad"));
            rewardScreenButtons.Add("claimNoThanks", GameObject.Find("Claim No Thanks"));

            rewardScreenActions.Add("continue", () => Continue());
            rewardScreenActions.Add("noThanks", () => NoThanks());
            rewardScreenActions.Add("softCurrency", () => SoftCurrency());
            rewardScreenActions.Add("hardCurrency", () => HardCurrency());
            rewardScreenActions.Add("claimAd", () => ClaimAd());
            rewardScreenActions.Add("claimNoThanks", () => ClaimNoThanks());

            foreach (KeyValuePair<string, GameObject> keyValuePair in rewardScreenButtons)
            {
                try
                {
                    BindFunctionWithObjects(keyValuePair.Key, rewardScreenButtons, rewardScreenActions[keyValuePair.Key]);
                }
                catch (NullReferenceException e)
                {
                    Debug.Log($"Exception {e.Message} for object {keyValuePair.Key}");
                }
            }
        }
    }

    private void BindFunctionWithObjects(string key, Dictionary<string, GameObject> dict, UnityEngine.Events.UnityAction callback)
    {
        if (dict.TryGetValue(key, out GameObject val))
        {
            
            if (val.TryGetComponent<Button>(out var currentButton))
            {
                currentButton.onClick.AddListener(callback);
            } else
            {
                Debug.Log("Button not found");
            }
        } else
        {
            Debug.Log("No dictionary value founf");
        }
    }

    private void Achievements()
    {
        Debug.Log("Achievments clicked");
    }

    private void BuildLevel()
    {
        Debug.Log("Build level Clicked");
    }

    private void Shop()
    {
        Debug.Log("Shop Clicked");
    }

    private void Upgrade()
    {
        Debug.Log("Upgrade clicked");
    }

    private void LootBox()
    {
        Debug.Log("Loot Box clicked");
    }
    
    private void TapToPlay()
    {
        Debug.Log("Tap to Play clicked");
    }

    private void NoAds()
    {
        Debug.Log("No Ads clicked");
    }

    private void SpinWheel()
    {
        Debug.Log("Spin wheel clicked");
    }

    private void Settings ()
    {
        if (GameObject.Find("Modal").TryGetComponent<ModalBehaviour>(out ModalBehaviour modal))
        {
            modal.IsActive = true;
        }
    }

    private void ClaimNoThanks()
    {
        Debug.Log("Claim no thanks clicked");
    }

    private void ClaimAd()
    {
        Debug.Log("Claim Ad clicked");
    }

    private void HardCurrency()
    {
        Debug.Log("Hard Currency clicked");
    }

    private void  SoftCurrency()
    {
        Debug.Log("Soft currency clicked");
    }

    private void NoThanks()
    {
        Debug.Log("No thanks clicked");
    }

    private void Continue()
    {
        Debug.Log("Continue clicked");
    }
}
