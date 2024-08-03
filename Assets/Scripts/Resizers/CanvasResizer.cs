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
        Resize();
    }
    
    void Update()
    {
        if (OldScreenSize != (Screen.width, Screen.height))
        {
            Resize();
            OldScreenSize = (Screen.width, Screen.height);
        }
    }

    void Resize()
    {
        RectTransform menuPanelRT = MenuPanel.GetComponent<RectTransform>();
        RectTransform globalPanelRT = GlobalPanel.GetComponent<RectTransform>();
        RectTransform gameEnginePanelRT = GameEnginePanel.GetComponent<RectTransform>();
        RectTransform menuItemPanelRT = MenuItemPanel.GetComponent<RectTransform>();

        float horizontalRatio = (float)Screen.width / OldScreenSize.Item1;
        float verticalRatio = (float)Screen.height / OldScreenSize.Item2;

        
        /*menuPanelRT.anchorMin = new Vector2(0f, 0f);
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
        menuItemPanelRT.anchorMax = new Vector2(1f, 0.5f);*/
    }
}
