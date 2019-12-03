using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public List<Vector3> EnemyPos;
    public int timer = 180;
    public Vector3 LastPos;
    public int NextPos = 1;
    public float l = 0;
    // Start is called before the first frame update
    void Start()
    {
        EnemyPos.Add(new Vector3());
        EnemyPos.Add(new Vector3());
        EnemyPos.Add(new Vector3());
        EnemyPos.Add(new Vector3());
        EnemyPos.Add(new Vector3());
    }

    // Update is called once per frame
    void Update()
    {
        EnemyPos[0]=(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, Screen.height - 100, 8)));
        EnemyPos[1]=(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width - 100), Screen.height - 100, 8)));
        EnemyPos[2]=(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width - 100), Screen.height - (Screen.height - 100), 8)));
        EnemyPos[3]=(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 100, Screen.height - (Screen.height - 100), 8)));
        EnemyPos[4]=(Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width / 2), Screen.height - (Screen.height / 2), 8)));

        if (NextPos > 0) {
            LastPos = ((EnemyPos[NextPos - 1]));
        }
        else {
            LastPos = ((EnemyPos[4]));
        }

        if (this.transform.localPosition != EnemyPos[NextPos])
        {
            this.transform.localPosition = lerppppp();
            if (l < 1)
            {
                l += 0.002f;
            }
        }
        else
        {
            l = 0;
            LastPos = EnemyPos[NextPos];
            NextPos++;
            if (NextPos == 5)
            {
                NextPos = 0;
            }
        }
    }

    Vector3 lerppppp() {
        return new Vector3
                (Mathf.Lerp(LastPos.x, EnemyPos[NextPos].x, l),
                Mathf.Lerp(LastPos.y, EnemyPos[NextPos].y, l),
                Mathf.Lerp(LastPos.z, EnemyPos[NextPos].z, l));
    }

    public void SetStart() {
        //this.transform.localPosition = EnemyPos[1];
        LastPos = transform.localPosition;

        NextPos = Random.Range(0,4);
    }
}
