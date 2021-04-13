using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    // Use this for initialization
    public float defaultSpeed = 4.0f;
    public float speed;
    public int lastInput;
    public bool stop = false;
    public GameObject GameController;
    public string defeatMessage = "YOU WERE SMASHED BY A TANK";

    private Vector2 direction = Vector2.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Move();

        UpdateOrientation();
    }

    void CheckInput(int i)
    {
        lastInput = i;
        //left
        if (i == 1)
        {
            direction = Vector2.left;
            speed = defaultSpeed;
        }
        //right
        else if (i == 2)
        {

            direction = Vector2.right;
            speed = defaultSpeed;

        }
        //up
        else if (i == 3)
        {

            direction = Vector2.up;
            speed = defaultSpeed;

        }
        //down
        else if (i == 4 || i == 5)
        {

            direction = Vector2.down;
            speed = defaultSpeed;
        }
    }

    void Move()
    {

        transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
    }

    void UpdateOrientation()
    {

        if (direction == Vector2.left)
        {

            transform.localScale = new Vector3(-0.65f, 0.65f, 0.65f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (direction == Vector2.right)
        {

            transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        else if (direction == Vector2.up)
        {

            transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
            transform.localRotation = Quaternion.Euler(0, 0, 90);

        }
        else if (direction == Vector2.down)
        {

            transform.localScale = new Vector3(0.65f, 0.65f, 0.65f);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Enemy")
        {
            speed = 0;
            int newInput = lastInput;
            while (lastInput == newInput) {
                newInput = Random.Range(1, 5);
                Debug.Log(newInput);
            }
            CheckInput(newInput);
        } else if (coll.gameObject.tag == "Player")
        {
            GameController.GetComponent<GameControllerScript>().PlayerDefeated(defeatMessage);
        }

    }
}
