using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveBall : MonoBehaviour
{
    public float speed = 30;
    public int scoreLeft, scoreRight;
    public Text score;
    public AudioClip HitWall;
    public AudioClip HitPlayer;
    public AudioClip point;
    public AudioSource music;
    float time = 0;
    public string Win;

    void Start()
    {
        music = GetComponent<AudioSource>();
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        scoreLeft = 0;
        scoreRight = 0;
    }
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time>=5)
        {
            speed += 5;
            time = 0;
        }
    }

    void FixedUpdate()
    {
        score.text = Convert.ToString(scoreLeft) + "      " + Convert.ToString(scoreRight);
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "PlayerLeft")
        {
            music.PlayOneShot(HitPlayer);
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "PlayerRight")
        {
            music.PlayOneShot(HitPlayer);
            float y = hitFactor(transform.position,col.transform.position,col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (col.gameObject.name == "WallLeft")
        {
            scoreRight++;
            music.PlayOneShot(point);
            speed = 30;
            GetComponent<Transform>().position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            if (scoreRight >= 5)
            {
                SceneManager.LoadSceneAsync(Win);
            }
        }
        if (col.gameObject.name == "WallRight")
        {
            scoreLeft++;
            music.PlayOneShot(point);
            speed = 30;
            GetComponent<Transform>().position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            if (scoreLeft >= 5)
            {
                SceneManager.LoadSceneAsync(Win);
            }
        }
        if (col.gameObject.name == "WallTop" || col.gameObject.name == "WallBottom")
        {
            music.PlayOneShot(HitWall);
        }

    }
}
