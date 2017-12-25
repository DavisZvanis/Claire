﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Wave[] waves;
    public Enemy enemy;

    Wave currentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;

    private void Start()
    {
        NextWave();
    }

    private void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy,Vector3.zero,Quaternion.identity) as Enemy;
            spawnedEnemy.OnDeath += OnEnemyDeath; //When on death happnes notify this and OnEnemyDeath is called
        }
    }

    void OnEnemyDeath()
    {
        enemiesRemainingAlive--;
        if(enemiesRemainingAlive == 0)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        
        currentWaveNumber++;
        print("wave: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
        }
        enemiesRemainingToSpawn = currentWave.enemyCount;
        enemiesRemainingAlive = currentWave.enemyCount;
    }

    //To embed class variables in the inspector
    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;

    }
}