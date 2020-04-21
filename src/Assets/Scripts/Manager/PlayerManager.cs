using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
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

    private void Update()
    {
        ProgressLife();
        if (progressLife.value <= 0)
        {
            Die();
        }
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

    public void SetLife(int value)
    {
        progressLife.value += Mathf.Round(value);
    }

    void Die()
    {
        PlayerManager.instance.alive = false;
        Time.timeScale = 0;
        Invoke("Reload", 2);
    }

    void Reload()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

}
