using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    int nextPos = 0;
    Transform lastPos;
    public Vector3 lastFacing;
    public List<GameObject> Pos = new List<GameObject>();
    public float interv;
    public float angleLerp;
    public TutorialController tc;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = this.gameObject.transform;
        lastFacing = new Vector3(0f, 0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (tc.tutorial == false)
        {
            
            if (this.transform.position != Pos[nextPos].transform.position)
            {
                Movement();
                interv += 0.003f;
            }
            else {
                interv = 0;
                //trigger();
            }
        }
        //currentPos = new Vector3()
    }

    void Movement()
    {
        Camera.main.transform.position = new Vector3
            (Mathf.Lerp(lastPos.position.x, Pos[nextPos].transform.position.x, interv),
            Mathf.Lerp(lastPos.position.y, Pos[nextPos].transform.position.y, interv), 
            Mathf.Lerp(lastPos.position.z, Pos[nextPos].transform.position.z, interv));
    }

    public bool isMoving() {
        if (this.transform.position != Pos[nextPos].transform.position)
        {
            return true;
        }
        else {
            return false;
        }
    
    }

    public void trigger() { 
        lastPos = this.gameObject.transform;
        nextPos++;
        if (nextPos >= 4) {
            nextPos = 0;
        }
        transform.LookAt(Pos[nextPos].transform.position);
    }
}
