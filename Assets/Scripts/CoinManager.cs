using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject coinParticlesPrefab;
    [SerializeField] private TMP_Text coinsText;

    [SerializeField] private float minXBound;
    [SerializeField] private float maxXBound;
    [SerializeField] private float minYBound;
    [SerializeField] private float maxYBound;

    private int coins = 0;
    private CameraShaker cameraShaker;

    private void Start()
    {
        //the CameraShaker sits on the parent of the main camera
        cameraShaker = Camera.main.transform.parent.GetComponent<CameraShaker>();

        SpawnCoin();
    }

    //called by Coin.cs when the player picks up a coin
    public void CollectCoin()
    {
        coins++;
        //$"..." is string interpolation: {coins} is replaced by its value
        coinsText.text = $"Coins: {coins}";

        cameraShaker.ShakeCamera();
        GameObject newCoinParticles = Instantiate(coinParticlesPrefab, transform.position, Quaternion.identity);
        Destroy(newCoinParticles, 1f); //destroy newly spawned object after 1s

        SpawnCoin();
    }

    //places a new coin at a random position inside the bounds set in the Inspector
    private void SpawnCoin()
    {
        float newSpawnX = Random.Range(minXBound, maxXBound);
        float newSpawnY = Random.Range(minYBound, maxYBound);

        Vector2 newSpawnPosition = new Vector2(newSpawnX, newSpawnY);
        Instantiate(coinPrefab, newSpawnPosition, Quaternion.identity);
    }
}
