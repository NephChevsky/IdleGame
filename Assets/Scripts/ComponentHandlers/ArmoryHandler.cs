using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmoryHandler : MonoBehaviour
{
    public GameObject ItemSlotPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float GetWidth(float height)
    {
        float itemSlotHeight = height / 4.5f;
        return itemSlotHeight * 3;
    }
}
