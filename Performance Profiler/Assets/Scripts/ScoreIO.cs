﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class ScoreIO : MonoBehaviour
{
    const string DLL_NAME = "SaveLoadScore";
    public GameObject saveload;

    [DllImport(DLL_NAME)]
    private static extern int loadScore();

    [DllImport(DLL_NAME)]
    private static extern void saveScore(int score);
    
    [DllImport(DLL_NAME)]
    private static extern void clearFile();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveScore(saveload.GetComponent<Control>().score / saveload.GetComponent<Control>().e.Enemies.Count);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
             saveload.GetComponent<Control>().score = loadScore() * saveload.GetComponent<Control>().e.Enemies.Count;
        }
    }
}
