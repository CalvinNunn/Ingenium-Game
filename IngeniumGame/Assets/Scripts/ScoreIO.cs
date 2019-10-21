using System.Collections;
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
            saveScore(saveload.GetComponent<RayTest>().score / saveload.GetComponent<RayTest>().e.Enemies.Count);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
             saveload.GetComponent<RayTest>().score = loadScore() * saveload.GetComponent<RayTest>().e.Enemies.Count;
        }
    }
}
