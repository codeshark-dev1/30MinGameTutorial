using System.Collections;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab; //the particle object to spawn, assigned in the Inspector
    [SerializeField] private float spawnDelay = 0.3f; //seconds between spawns

    private void Start()
    {
        //a coroutine can pause itself (with yield) without freezing the game
        StartCoroutine(SpawnParticlePrefab());
    }

    private IEnumerator SpawnParticlePrefab()
    {
        //infinite loop
        //WARNING: if no delay is active and no break is set than this WILL freeze / crash your game!
        while (true)
        {
            //object clean up is handled in ObjectDestroyer.cs
            Instantiate(prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay); //wait until spawnDelay is passed before running this code again
        }
    }
}
