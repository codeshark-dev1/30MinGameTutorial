using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f;

    private Transform target;

    private void Start()
    {
        //find the player once at the start, instead of every frame
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //Time.deltaTime keeps the speed the same on fast and slow computers
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    //called when this object's (non-trigger) collider hits another collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //reload the current scene to restart the game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
