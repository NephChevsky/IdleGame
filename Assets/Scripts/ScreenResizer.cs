using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class ScreenResizer : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject GlobalPanel;
    public GameObject GameEnginePanel;
    public GameObject MenuItemPanel;

    private (int, int) OldScreenSize;

    void Start()
    {
        OldScreenSize = (Screen.width, Screen.height);
        ResizeUI();
    }
    
    void Update()
    {
        if (OldScreenSize != (Screen.width, Screen.height))
        {
            ResizeUI();
            OldScreenSize = (Screen.width, Screen.height);
        }
    }

    void ResizeUI()
    {
        RectTransform menuPanelRT = MenuPanel.GetComponent<RectTransform>();
        RectTransform globalPanelRT = GlobalPanel.GetComponent<RectTransform>();
        RectTransform gameEnginePanelRT = GameEnginePanel.GetComponent<RectTransform>();
        RectTransform menuItemPanelRT = MenuItemPanel.GetComponent<RectTransform>();

        bool horizontalScreen = Screen.height * 0.8f < Screen.width;
        float oldGameEngineWidth = gameEnginePanelRT.rect.width;

        if (horizontalScreen)
        {
            float ratio = Screen.height * Settings.Global.MenuRatio / Screen.width;

            menuPanelRT.anchorMin = new Vector2(0f, 0f);
            menuPanelRT.anchorMax = new Vector2(ratio, 1f);
            globalPanelRT.anchorMin = new Vector2(ratio, 0f);
            globalPanelRT.anchorMax = new Vector2(1f, 1f);

            float gameEngineHeight = Screen.height / 2f;
            float gameEngineWidth = gameEngineHeight * Settings.Global.GameEngineRatio;
            if (gameEngineWidth > (1 - Settings.Global.MenuRatio) * Screen.width)
            {
                gameEngineWidth = (1 - Settings.Global.MenuRatio) * Screen.width;
                gameEngineHeight = gameEngineWidth * (1 / Settings.Global.GameEngineRatio);
            }

            float horizontalRatio = (1 - (gameEngineWidth / ((1 - Settings.Global.MenuRatio) * Screen.width))) / 2;
            float verticalRatio = (1 - (gameEngineHeight / (Screen.height / 2))) / 2;

            gameEnginePanelRT.anchorMin = new Vector2(horizontalRatio, 0.5f + verticalRatio);
            gameEnginePanelRT.anchorMax = new Vector2(1 - horizontalRatio, 1f - verticalRatio);
            menuItemPanelRT.anchorMin = new Vector2(0f, 0f);
            menuItemPanelRT.anchorMax = new Vector2(1f, 0.5f);
            
        }
        else
        {
            float ratio = (Screen.width * Settings.Global.MenuRatio) / Screen.height;

            menuPanelRT.anchorMin = new Vector2(0f, 0f);
            menuPanelRT.anchorMax = new Vector2(1f, ratio);
            globalPanelRT.anchorMin = new Vector2(0f, ratio);
            globalPanelRT.anchorMax = new Vector2(1f, 1f);

            float gameEngineWidth = Screen.width;
            float gameEngineHeight = gameEngineWidth * (1 / Settings.Global.GameEngineRatio);

            float verticalRatio = 1 - (gameEngineHeight / ((1 - ratio) * Screen.height));
            gameEnginePanelRT.anchorMin = new Vector2(0f, verticalRatio);
            gameEnginePanelRT.anchorMax = new Vector2(1f, 1f);
            menuItemPanelRT.anchorMin = new Vector2(0f, 0f);
            menuItemPanelRT.anchorMax = new Vector2(1f, verticalRatio);
        }

        float gameEnginePanelWidth = gameEnginePanelRT.rect.width;
        float gameEnginePanelHeight = gameEnginePanelRT.rect.height;
        LivingThing[] livingThings = gameEnginePanelRT.GetComponentsInChildren<LivingThing>();
        foreach (LivingThing lt in livingThings)
        {
            lt.transform.localScale = new Vector2(gameEnginePanelWidth / 600f, gameEnginePanelWidth / 600f);
            lt.transform.localPosition = new Vector2(lt.transform.localPosition.x * oldGameEngineWidth / gameEnginePanelWidth, -0.12f * gameEnginePanelHeight);
        }
    }
}
