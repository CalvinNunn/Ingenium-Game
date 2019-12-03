using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class ReticleControl : MonoBehaviour
{
    public bool eyeTracking = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        if (eyeTracking == true)
        {
            transform.position = TobiiAPI.GetGazePoint().Screen;//Input.mousePosition;
        }
        else
        {
            transform.position = Input.mousePosition;
        }
    }

    public void changeEyeTracker()
    {
        eyeTracking = !eyeTracking;
    }
}
