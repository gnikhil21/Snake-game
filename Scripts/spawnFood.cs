using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class spawnFood : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    //bool dead=false;
    public Snake snake;
    void Start()
    {
        InvokeRepeating("spawn",2,4);   
    }

    public void spawn()
    {
        if(!Snake.dead)
        {
            int x=(int)Random.Range(borderLeft.position.x+1,borderRight.position.x-1);
            int y=(int)Random.Range(borderTop.position.y-1,borderBottom.position.y+1);

            Instantiate(foodPrefab,new Vector2(x,y),Quaternion.identity);
        }
    }

    
}
