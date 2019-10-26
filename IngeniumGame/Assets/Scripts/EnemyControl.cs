using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<Vector3> pos;
    public GameObject prefab;
    float x;
    float y;
    float z;
    public int timer = 120;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(2, 4);

        for (int i = 0; i < rand; i++)
        {
            Enemies.Add(prefab);
        }


        for (int i = 0; i < Enemies.Count; i++)
        {
            x = Random.Range(-3, 3);
            y = Random.Range(1, 3);
            z = Random.Range(-3, 2);

            pos.Add(new Vector3(x, y, z));
        }

        for (int i = 0; i <= Enemies.Count - 1; i++)
        {
            Enemies[i] = Instantiate(Enemies[i], pos[i], Quaternion.identity);
            Enemies[i].transform.parent = Camera.main.transform;
            Enemies[i].name = "Enemy" + i;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 120) {
            timer = 0;
        }
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (timer == 0)
            {
                x = Random.Range(-0.01f, 0.01f);
                y = Random.Range(-0.01f, 0.01f);
                z = Random.Range(-0.01f, 0.01f);
            }
            
            Enemies[i].transform.position = new Vector3
                (Enemies[i].transform.position.x + x, 
                Enemies[i].transform.position.y + y, 
                Enemies[i].transform.position.z + z);
        }
        timer++;
    }
}
