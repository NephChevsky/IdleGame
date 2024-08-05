using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngineResizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*RectTransform rt = GetComponent<RectTransform>();
        float gameEnginePanelWidth = rt.rect.width;
        float gameEnginePanelHeight = rt.rect.height;
        LivingThing[] livingThings = GetComponentsInChildren<LivingThing>();
        foreach (LivingThing thing in livingThings)
        {
            RectTransform ltRT = thing.GetComponent<RectTransform>();
            thing.transform.localScale = new Vector2(gameEnginePanelWidth / 600f, gameEnginePanelWidth / 600f);
            thing.transform.localPosition = new Vector2(thing.transform.localPosition.x * oldGameEngineWidth / gameEnginePanelWidth, -25);
        }*/
    }
}
