using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommandPattern;
using ObserverPattern;
using UnityEngine.UI;


    public class RayTest : MonoBehaviour
    {
        InputControl inp;
        public EnemyControl e;
        RaycastHit hit;
        Ray ray;
        public Text t;
        public int score;
        Subject subject = new Subject();
        EnemyCube testing;
        // Start is called before the first frame update
        void Start()
        {
        for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
        {
            testing = new EnemyCube(e.Enemies[i], new returnScore());
            subject.AddObserver(testing);
        }
    }

        // Update is called once per frame
        void Update()
        {

            ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            t.text = "Score: " + score / e.Enemies.Count;
        }

        public void mouse()
        {
            //Debug.DrawRay(ray.origin, Camera.main.transform.forward * 10, Color.red);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                //Debug.Log(objectHit);
                if (hit.transform.tag == "Enemy")
                {

                    Debug.Log(hit.transform.GetInstanceID());
                    for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
                    {
                        if (hit.transform.name == "Enemy" + i)
                        {
                            e.GetComponent<EnemyControl>().Enemies[i].SetActive(false);
                            //score = score + 1;
                            subject.Notify();
                        }
                    }
                }


            }


        }

        //public int returnScore()
        //{
        //    return score;
        //}
    }

