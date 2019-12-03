using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public float ping = 0;
    public float tempPos;
    float timer;
    public List<Sprite> tempSprite;
    public GameObject timerSprite;
    // Start is called before the first frame update
    void Start()
    {
        tempPos = Random.value * 4 + 4;
        timer = 90 * tempPos;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        ping = Mathf.PingPong(Time.time / tempPos, 1);
       this.transform.localPosition = new Vector3
                (Mathf.Lerp(pos1.transform.localPosition.x, pos2.transform.localPosition.x, ping),
                Mathf.Lerp(pos1.transform.localPosition.y, pos2.transform.localPosition.y, ping),
                Mathf.Lerp(pos1.transform.localPosition.z, pos2.transform.localPosition.z, ping));

        timerSprite.GetComponent<SpriteRenderer>().sprite = tempSprite[(int)((90 * tempPos) / (timer * 9)) / 9];

        if(timer <= 0)
        {
            this.transform.parent.gameObject.GetComponent<Control>().health--;
            timer = 90 * tempPos;
        }
       
    }

    public void randomize()
    {
        tempPos = Random.value * 4 + 4;
        ping = Mathf.PingPong(Time.time / tempPos, 1);
    }

    public void resetTimer()
    {
        timer = 90 * tempPos;
    }

}
