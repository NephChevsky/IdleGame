using UnityEngine;

public class CanvasResizer : MonoBehaviour
{
    public GameObject GlobalPanel;
    public GameObject GameEnginePanel;
    public GameObject MenuItemPanel;

    private int OldScreenWidth;
    private int OldScreenHeight;

    void Start()
    {
        Resize();
    }

    // Update is called once per frame
    void Update()
    {
        if (OldScreenHeight != Screen.height || OldScreenWidth != Screen.width)
        {
            Resize();
            OldScreenHeight = Screen.height;
            OldScreenWidth = Screen.width;
        }
    }

    void Resize()
    {
        float gameEngineHeight = (float)Screen.height / 2;
        float gameEngineWidth = gameEngineHeight * Settings.Global.GameEngineRatio;

        RectTransform globalPanelRT = GlobalPanel.GetComponent<RectTransform>();
        if (gameEngineWidth > globalPanelRT.rect.width)
        {
            gameEngineWidth = globalPanelRT.rect.width;
            gameEngineHeight = gameEngineWidth / Settings.Global.GameEngineRatio;
        }

        float horizontalRatio = 1 - gameEngineWidth / globalPanelRT.rect.width;
        float verticalRatio = 1 - gameEngineHeight / globalPanelRT.rect.height;

        RectTransform gameEnginePanelRT = GameEnginePanel.GetComponent<RectTransform>();
        RectTransform menuItemPanelRT = MenuItemPanel.GetComponent<RectTransform>();
        gameEnginePanelRT.anchorMin = new Vector2(horizontalRatio/2, verticalRatio);
        gameEnginePanelRT.anchorMax = new Vector2(1f - horizontalRatio/2, 1f);
        menuItemPanelRT.anchorMin = new Vector2(0f, 0f);
        menuItemPanelRT.anchorMax = new Vector2(1f, verticalRatio);
    }
}
