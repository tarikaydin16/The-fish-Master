using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    private GameObject currentScreen;
    
    public GameObject endScreen;
    public GameObject gameScreen;
    public GameObject returnScreen;
    public GameObject mainScreen;


    public Button lengthButton;
    public Button strengthButton;
    public Button offlineButton;

    public Text gameScreenMoney;
    public Text lengthCostText;
    public Text lengthValueText;
    public Text strengthCostText;
    public Text strengthValueText;
    public Text offlineCostText;
    public Text offlineValueText;
    public Text endScreenMoney;
    public Text returnScreenMoney;


    private int gameCount;
    void Awake()
    {
        if (ScreenManager.instance)
            Destroy(gameObject);
        else
            ScreenManager.instance = this;

        currentScreen = mainScreen;
    }

    private void Start()
    {
        CheckIdles();
        UpdateTexts();
    }

    public void ChangeScreen(Screens screen)
    {
        currentScreen.SetActive(false);
        switch (screen)
        {
            case Screens.MAIN:
                currentScreen = mainScreen;
                UpdateTexts();
                CheckIdles();
                break;
            case Screens.GAME:
                currentScreen = gameScreen;
                gameCount++;
                break;
            case Screens.END:
                currentScreen = endScreen;
                //SetEndScreenMoney();
                break;
            case Screens.RETURN:
                currentScreen = returnScreen;
                //SetReturnScreenMoney();
                break;
        }
        currentScreen.SetActive(true);
    }
    public void SetEndScreenMoney()
    {
        endScreenMoney.text = "$" + IdleManager.instance.totalGain;

    }
    public void SetReturnScreenMoney()
    {
        returnScreenMoney.text = "$" + IdleManager.instance.totalGain+" gained while waiting!";

    }
    public void CheckIdles()
    {
        int lengthCost = IdleManager.instance.lengthCost;
        int strengthCost = IdleManager.instance.strengthCost;
        int offlineEarningsCost = IdleManager.instance.offlineEarningsCosts;
        int wallet = IdleManager.instance.wallet;

        if (wallet < lengthCost)
            lengthButton.interactable = false;
        else
            lengthButton.interactable = true;

        if (wallet < strengthCost)
            strengthButton.interactable = false;
        else
            strengthButton.interactable = true;


        if (wallet < offlineEarningsCost)
            offlineButton.interactable = false;
        else
            offlineButton.interactable = true;
    }
    public void UpdateTexts()
    {
        gameScreenMoney.text = "$" + IdleManager.instance.wallet;
        lengthCostText.text = "$" + IdleManager.instance.lengthCost;
        lengthValueText.text = -IdleManager.instance.lengthCost+"m";
        strengthCostText.text = "$" + IdleManager.instance.strengthCost;
        strengthValueText.text = "$" + IdleManager.instance.strength+" fishes.";
        offlineCostText.text = "$" + IdleManager.instance.offlineEarningsCosts;
        offlineValueText.text = "$" + IdleManager.instance.offlineEarnings + "/min";

    }
}
