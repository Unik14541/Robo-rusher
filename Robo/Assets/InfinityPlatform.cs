using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class InfinityPlatform : Platformsspawner
{
    Transform playerTransform;
    List<GameObject> activePlatform = new List<GameObject>();
    [SerializeField] int maxCountToSpawn;
    [SerializeField] Platform bustPlatform;
    int curCountToSpawnBust;

    private void Start() {
        playerTransform = FindObjectOfType<Playermove>().transform;
        GenerateStart();

    }
    protected override void SpawnPlatform(Platform spawnPlatform) {
        GameObject newPlatform = Instantiate(spawnPlatform, transform.forward * spawnDirection, transform.rotation).gameObject;
        spawnDirection += platformLength;
        activePlatform.Add(newPlatform);
    }
    void RemoveActivePlatform() {
        GameObject LostPlatform = activePlatform[0];
        activePlatform.RemoveAt(0);
        Destroy(LostPlatform);
    }
    private void Update() {
        if (playerTransform.position.z > spawnDirection - (maxPlatformCount * platformLength)) {
          for(int i = 0; i < maxPlatformCount; i++) {
            if(curCountToSpawnBust == maxCountToSpawn){
                SpawnPlatform(bustPlatform);
                curCountToSpawnBust = 0;
            }
            else{
                SpawnPlatform(GetRandomPlatform());
                curCountToSpawnBust++;
            }
            RemoveActivePlatform();
          }
        }
    }
    protected override void GenerateStart()
    {
        SpawnPlatform(startPlatform);
        for(int i = 0; i < maxPlatformCount; i++) {
            if(curCountToSpawnBust == maxCountToSpawn){
                SpawnPlatform(bustPlatform);
                curCountToSpawnBust = 0;
            }
            else{
                SpawnPlatform(GetRandomPlatform());
                curCountToSpawnBust++;
            }
          }
    }
}
