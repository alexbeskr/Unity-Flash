using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SnakeS : MonoBehaviour 
{
    public List<GameObject> Snake = new List<GameObject>();

    int TicTime;
    public int TicTimeLimit;
    public string dir = "w";
    public Vector3 tempPos;
    public GameObject Food;

    void SpawnFood()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        Instantiate(Food, new Vector3(Random.Range(-22, 22), 0, Random.Range(-22, 22)), Quaternion.identity);
       
    }

    void Inputs()
    {
        if (Input.GetKeyDown("w"))
        {
            dir = "w";
            TicTime = TicTimeLimit;
        }
        if (Input.GetKeyDown("s"))
        {
            dir = "s";
            TicTime = TicTimeLimit;
        }
        if (Input.GetKeyDown("a"))
        {
            dir = "a";
            TicTime = TicTimeLimit;
        }
        if (Input.GetKeyDown("d"))
        {
            dir = "d";
            TicTime = TicTimeLimit;
        }
    }

    void appenedToSnake()
    {
        GameObject part = Instantiate(Resources.Load<GameObject>("part")) as GameObject;
        if (!Snake.Contains(part))
        {
            Snake.Add(part);
        }
    }

    void updateSnake()
    {
        TicTime++;
        if (TicTime >= TicTimeLimit)
        {
            for (int j = Snake.Count - 1; j > 0; j--)
            {
                if (j > 0)
                    Snake[j].transform.position = Snake[j - 1].transform.position;
            }
            Snake[0].transform.position = transform.position;
                switch (dir)
                {
                    case "w":
                        tempPos.z++;
                        break;
                    case "s":
                        tempPos.z--;
                        break;
                    case "a":
                        tempPos.x--;
                        break;
                    case "d":
                        tempPos.x++;
                        break;
                }
            TicTime = 0;
        }
        transform.position = tempPos;
    }

	// Use this for initialization
	void Start () 
    {
        SpawnFood();
        for (int i = 0; i < 1; i++)
            appenedToSnake();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Inputs();
        updateSnake();
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name.StartsWith("Food"))
        {
            Destroy(collider.gameObject);
            SpawnFood();
            appenedToSnake();
        }
        if (collider.name.StartsWith("Wall1") || collider.name.StartsWith("Wall2") || collider.name.StartsWith("Wall3") || collider.name.StartsWith("Wall4"))
        {
			SceneManager.LoadScene ("snake1");
        }
    }
}
