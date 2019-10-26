using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject currentPos;
    public GameObject nextPos;
    public float interv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position != nextPos.transform.position)
        {
            Movement();
            interv += 0.003f;
        }
        //currentPos = new Vector3()
    }

    void Movement()
    {
        Camera.main.transform.position = new Vector3
            (Mathf.Lerp(currentPos.transform.position.x, nextPos.transform.position.x, interv),
            Mathf.Lerp(currentPos.transform.position.y, nextPos.transform.position.y, interv), 
            Mathf.Lerp(currentPos.transform.position.z, nextPos.transform.position.z, interv));
    }

    public void trigger(GameObject cur, GameObject next)
    {
        currentPos = cur;
        nextPos = next;

        Movement();
    }

}
