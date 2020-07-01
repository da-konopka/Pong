using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAI : MonoBehaviour {
    public float speed = 20;
    public GameObject Ball;
    public GameObject AI;
    void Update()
    {
        float yBall,yAI;
        yBall = Ball.transform.position.y;
        yAI = AI.transform.position.y;
        if (yBall>yAI)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;
        }
        if(yBall<yAI)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * speed;
        }
    }
}
