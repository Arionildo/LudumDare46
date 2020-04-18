using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager: MonoBehaviour
{
    public static PlayerManager instance = null;
    public static float gameSpeed;
    public static int score;

    public bool alive = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    
        DontDestroyOnLoad(gameObject);
        gameSpeed = 1f;
    }

    internal static void ResetValues()
    {
        score = 0;
    }
}
