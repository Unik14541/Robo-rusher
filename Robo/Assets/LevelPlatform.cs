using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPlatform : Platformsspawner
{
    [SerializeField] Platform finalPlatform;
    protected override void GenerateStart() {
        base.GenerateStart();
        SpawnPlatform(finalPlatform);
    }
    void Start() {
        GenerateStart();
    }
}
