using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, Camera.main.transform.forward * 10, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
                        
            Debug.DrawRay(ray.origin, Camera.main.transform.TransformDirection(Vector3.forward) * 10, Color.blue);
            
            Debug.Log(objectHit);
        }


    }
}

