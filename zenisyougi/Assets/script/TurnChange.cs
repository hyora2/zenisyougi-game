using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChange : MonoBehaviour
{
    GameObject TC;
    Vector3 t1pos, t2pos;
    float speed;
    bool move;

    private void Start()
    {

        speed = 30.0f;
        move = false;
        t1pos = new Vector3(0f,0f,2f);
        t2pos = new Vector3(10f, -10f, 2f);

       
    }

    private void Update()
    {
        if (transform.position.x >= 0f && transform.position.x <= 10f)
        {
            transform.position += new Vector3( -speed * Time.deltaTime,  speed * Time.deltaTime, 0f);
        }
    }


    public　void MoveTurnObj(int tp)
    {

        speed = speed * (-1);
        if(tp == 1)
        {
            transform.position = t2pos;
        }else if(tp == 2)
        {
            transform.position = t1pos;
        }


    }

}
