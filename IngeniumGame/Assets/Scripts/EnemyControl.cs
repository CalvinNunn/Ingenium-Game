using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
    public List<Vector3> pos = new List<Vector3>();
    public GameObject prefab;
    public Control c;
    public TutorialController tut;
    public bool active;
    public GameObject cameraP;
    int x;
    int y;
    int z;
    // Start is called before the first frame update
    void Start()
    {
        //int rand = Random.Range(2, 4);

        //for (int i = 0; i < Enemies.Count; i++)
        //{
        //    Enemies.Add(prefab);
        //}

        for (int i = 0; i < Enemies.Count; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height),
          Camera.main.nearClipPlane * 20));
            pos.Add(screenPosition);
            //x = Random.Range(-3, 3);
            //y = Random.Range(1, 3);
            //z = Random.Range(-3, 0);
           // pos.Add(new Vector3(x, y, z));//adds a random position to the vector list of positions
        }
    }

    public void initializeEnemies()//instantiates enemies based on how many we plan to create
    {
      
        for (int i = 0; i <= Enemies.Count - 1; i++)
        {
            Enemies[i] = prefab;
            Enemies[i] = Instantiate(Enemies[i], pos[i], cameraP.transform.rotation);
            Enemies[i].name = "Enemy" + i; 
            Enemies[i].GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1, 0.5f, 1f);
            Enemies[i].transform.parent = cameraP.transform;
        }
        active = true;
        c.health = 3;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
