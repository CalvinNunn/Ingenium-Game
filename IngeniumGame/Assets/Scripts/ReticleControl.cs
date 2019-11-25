using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class ReticleControl : MonoBehaviour
{
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

        //transform.position = TobiiAPI.GetGazePoint().Screen;//Input.mousePosition;
        transform.position = Input.mousePosition;
    }

}
