using UnityEngine;

public class GameLoopHandler : MonoBehaviour
{

    void Start()
    {
        GameEngine.Init();
    }

    void FixedUpdate()
    {
        GameEngine.Advance(Time.fixedDeltaTime);
    }
}
