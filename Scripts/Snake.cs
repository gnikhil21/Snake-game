using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    Vector2 dir=Vector2.right;
    List<Transform> tail=new List<Transform>();
    bool ate=false;
    public static bool dead=false;
    
    public GameOver GameOver;
    //public Score Score;
    public GameObject tailPrefab;
    
    public static int score=0;
    public Text scoreText;

    void Start()
    {
        InvokeRepeating("move",0.3f,0.1f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if(!dead)
        {
            if(Input.GetKey(KeyCode.RightArrow))
            dir=Vector2.right;
            else if(Input.GetKey(KeyCode.LeftArrow))
                dir=-Vector2.right;
            else if(Input.GetKey(KeyCode.UpArrow))
                dir=Vector2.up;
            else if(Input.GetKey(KeyCode.DownArrow))
                dir=-Vector2.up;

            if(Input.touchCount>0&& Input.GetTouch(0).phase==TouchPhase.Began)
            {
                Touch touch=Input.GetTouch(0);
                //Vector2 touchPos = Input.touches[0].position;
                 Vector2 touchPos=Camera.main.ScreenToWorldPoint(touch.position);
                if(dir==Vector2.right||dir==-Vector2.right)
                {
                    if(touchPos.y-transform.position.y>0)
                        dir=Vector2.up;
                    else if(touchPos.y-transform.position.y<0)
                        dir=-Vector2.up;
                }
                else
                {
                    if(touchPos.x-transform.position.x>0)
                        dir=Vector2.right;
                    else if(touchPos.x-transform.position.x<0)
                        dir=-Vector2.right;
                }
            }
        }
    
        scoreText.text = "Score: "+score.ToString();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name.StartsWith("foodPrefab"))
        {
            ate=true;
            score++;
            Destroy(coll.gameObject);
        }
        else //if(coll.name.StartsWith("border"))
        {
            dead=true;
            //int s=Score.score;
            dir=new Vector2(0,0);
            GameOver.Setup(score);
        }
        

    }
    void move() 
    {
        Vector2 pos=transform.position;
        transform.Translate(dir);
        
        if(ate)
        {
            GameObject g=(GameObject)Instantiate(tailPrefab,pos,Quaternion.identity);
            tail.Insert(0,g.transform);
            ate=false;
            
        }
        else if(tail.Count>0)
        {
            tail.Last().position=pos;

            tail.Insert(0,tail.Last());
            tail.RemoveAt(tail.Count-1);
        }
    }
}