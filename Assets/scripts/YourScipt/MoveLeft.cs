using UnityEngine;

public class MoveLeft : MonoBehaviour
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

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -30 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
