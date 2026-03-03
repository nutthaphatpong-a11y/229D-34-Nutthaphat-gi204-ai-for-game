using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {

    }


    void Update()
    {

        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;
        if (isGameOver)
        {
            speed = 0;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);

    }
}
