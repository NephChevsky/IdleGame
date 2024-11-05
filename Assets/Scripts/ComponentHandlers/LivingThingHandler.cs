using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivingThingHandler : MonoBehaviour
{
    public float LifeRatio;
    public bool IsPlayer;

    void Start()
    {
		ResizeUI();
    }

    void Update()
    {
        ResizeUI();
    }

    void ResizeUI()
    {
		Image image = GetComponent<Image>();
		image.color = IsPlayer ? new Color(1f - LifeRatio, LifeRatio, 0) : new Color(LifeRatio, LifeRatio, LifeRatio);
		TMP_Text text = GetComponentInChildren<TMP_Text>();
		text.text = $"{Mathf.RoundToInt(LifeRatio * 100f)} %";

        RectTransform RT = GetComponent<RectTransform>();
		RectTransform textRT = text.rectTransform;
        textRT.sizeDelta = new Vector2(RT.rect.height * 0.80f, RT.rect.width * 0.80f);
	}
}
