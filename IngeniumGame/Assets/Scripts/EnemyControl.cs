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
    public GameObject pos1;
    public GameObject pos2;
    public GameObject spritePrefab;
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

        
        //  Vector3 screenPosition1 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 500, Screen.height - 400,
        //    8));
        //  pos.Add(screenPosition1);
        //  Vector3 screenPosition2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 300, Screen.height - 200,
        //    8));
        //  pos.Add(screenPosition2);
        //  Vector3 screenPosition3 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 400, Screen.height - 400,
        //    8));
        //  pos.Add(screenPosition3);
        //x = Random.Range(-3, 3);
        //y = Random.Range(1, 3);
        //z = Random.Range(-3, 0);
        // pos.Add(new Vector3(x, y, z));//adds a random position to the vector list of positions

    }

    public void initializeEnemies()//instantiates enemies based on how many we plan to create
    {
      
        for (int i = 0; i <= Enemies.Count - 1; i++)
        {
            Enemies[i] = Instantiate(prefab, new Vector3(0f,0f,0f), cameraP.transform.rotation);
            Enemies[i].name = "Enemy" + i;
            Enemies[i].transform.rotation = Quaternion.Euler(0, 180, 0);
            Enemies[i].GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1, 0.5f, 1f);
            Enemies[i].transform.parent = cameraP.transform;
            Enemies[i].GetComponent<EnemyAI>().pos1 = pos1;
            Enemies[i].GetComponent<EnemyAI>().pos2 = pos2;
            Enemies[i].GetComponent<EnemyAI>().timerSprite = Instantiate(spritePrefab, Enemies[i].transform);
            Enemies[i].GetComponent<EnemyAI>().timerSprite.transform.localPosition = new Vector3(0f, 20f, 0f);
        }

        active = true;
        c.health = 3;
    }

  

    // Update is called once per frame
    void Update()
    {


    }
}
