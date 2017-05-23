using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    public static bool isPaused;

    void Start()
    {
        isPaused = false;
    }

    public void Pause()
    {
        isPaused = !isPaused;
    }
}
