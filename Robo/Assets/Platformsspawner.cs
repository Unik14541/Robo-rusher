using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformsspawner : MonoBehaviour
{
    [SerializeField]protected Platform[] platforms;
    [SerializeField]protected Platform startPlatform;
    [SerializeField]protected int maxPlatformCount;
    [SerializeField]protected float platformLength;
    protected float spawnDirection;
    protected Platform GetRandomPlatform() 
    {
        int RandomPlatform = Random.Range(0, platforms.Length);
        return platforms[RandomPlatform];
    }

    protected virtual void SpawnPlatform(Platform spawnPlatform) {
        Instantiate(spawnPlatform, transform.forward * spawnDirection, transform.rotation);
        spawnDirection += platformLength;
    }
    protected virtual void GenerateStart() 
    {
        SpawnPlatform(startPlatform);
        for(int i = 0; i < maxPlatformCount; i++) {
            SpawnPlatform(GetRandomPlatform());
        }
    }
}

