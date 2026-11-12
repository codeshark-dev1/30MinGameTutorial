using UnityEngine;

public class Coin : MonoBehaviour
{
    //called when another collider enters this object's trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //only react to the player, not to other objects
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<CoinManager>().CollectCoin();
            Destroy(gameObject); //remove this coin from the scene
        }
    }
}
