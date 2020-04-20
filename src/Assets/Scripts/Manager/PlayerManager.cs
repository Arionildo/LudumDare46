using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager: MonoBehaviour
{
    public static PlayerManager instance = null;
    public Slider progressLife;

    public static float gameSpeed;
    public static int score;

    public bool alive = false;

    public float targetProgressLife;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        gameSpeed = 1f;
    }

    private void Update() {
        ProgressLife();
    }

    internal static void ResetValues()
    {
        score = 0;
    }


    private void DecrementProgress(float newProgress)
    {
        targetProgressLife = progressLife.value - newProgress;
    }

    void ProgressLife()
    {
        if (progressLife.value > targetProgressLife)
        {
            progressLife.value -= Time.deltaTime;
        }
        DecrementProgress(0.75f);
    }

    public void SetLife(int value) {
        progressLife.value += Mathf.Round(value);
    }

}
