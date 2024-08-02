using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    public Player Player;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Player.Move();
    }
}
