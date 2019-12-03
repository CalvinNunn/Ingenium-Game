using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ObserverPattern;
using Tobii.Gaming;

public class Control : MonoBehaviour
{
    public EnemyControl e;
    RaycastHit hit;
    Ray ray;
    public Text t;
    public int score;
    public Text h;
    public int health;
    public Text s;
    Subject subject = new Subject();
    EnemyCube testing;
    EnemyCube healthTesting;
    GameObject enemy;
    public bool reset;
    int x; 
    int y;
    int z;
    public int timer;
    public ParticleManager pm;
    public List<Vector3> positions;
    public ReticleControl rc;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
        {
            enemy = e.Enemies[i];//assigns the prefab object to the list of enemies
        }
        health = 3;
        testing = new EnemyCube(enemy, new returnScore());//assigns observer object to the function it needs
        healthTesting = new EnemyCube(enemy, new returnScore());//assigns observer object to the function it needs
        subject.AddObserver(testing);
        subject.AddObserver(healthTesting);

        
    }

    // Update is called once per frame
    void Update()
    {

       

        Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;

        timer++;

        if (rc.eyeTracking == true)
        {
            ray = GetComponent<Camera>().ScreenPointToRay(gazePoint);//sets the raycast to where the mouse is pointing on screen
        }
        else
        {
            ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        }
        t.text = "Score: " + score;
        h.text = "Health: " + health;
        if (health > 0)
            mouse();

        if (health == 0)
        {
            s.color = new Vector4(0, 0, 0, 1);
            s.text = "You lost all Health Points. Your Score is " + score + " Press S to Save your Score, or Q to exit the game or R to restart. If you want to see the last saved score, press L";

            if (Input.GetKey("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (Input.GetKey("q"))
            {
                #if UNITY_EDITOR
                                UnityEditor.EditorApplication.isPlaying = false;
                #else
                          Application.Quit();
                #endif
            }
            for (int i = 0; i < e.GetComponent<EnemyControl>().Enemies.Count; i++)
            {
                e.GetComponent<EnemyControl>().Enemies[i].SetActive(false);
            }
        }
        
    }

    public void mouse()// calculates where the raycast is pointing if hitting an object
    {
        //Debug.DrawRay(ray.origin, Camera.main.transform.forward * 10, Color.red);
        if (e.GetComponent<EnemyControl>().active == true)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Transform objectHit = hit.transform;
                //Debug.Log(objectHit);
                if (hit.transform.tag == "Enemy")
                {
                    //Debug.Log(hit.transform.name);
                    for (int i = 0; i <= e.GetComponent<EnemyControl>().Enemies.Count - 1; i++)
                    {
                        if (hit.transform.name == "Enemy" + i && Input.GetMouseButtonUp(0))//an object is destroyed and then reset back to the screen
                        {
                            pm.setPosition(e.GetComponent<EnemyControl>().Enemies[i].transform.position);
                            pm.startPlay();
                            subject.Notify();//updates the score by notifying the subject
                            
                            e.GetComponent<EnemyControl>().Enemies[i].SetActive(false);
                            //score = score + 1;

                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButtonUp(0)) { }
                        //subject.NotifyHealth(); //updates health in case player hits the platform
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0)) { }
                   // subject.NotifyHealth(); //updates health in case player misses al objects on scene
            }

            for (int i = 0; i <= e.Enemies.Count - 1; i++)//when the enemy has been destory this resets them back to the screen
            {
                if (e.GetComponent<EnemyControl>().Enemies[i].activeInHierarchy == false && score % 3 == 0)
                {
                    
                        e.Enemies[i].SetActive(true);

                    e.GetComponent<EnemyAI>().randomize();
                    e.GetComponent<EnemyAI>().resetTimer();
                    e.Enemies[i].GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1, 0.5f, 1f);
                        timer = 0;
                    if (this.gameObject.GetComponent<CameraMove>().isMoving() == false) {
                    this.gameObject.GetComponent<CameraMove>().trigger();
                    }
                }

            }
        }
    }
}
