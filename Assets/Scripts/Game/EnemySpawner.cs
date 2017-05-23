using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Spawns the enemies, given the time between each spawn
public class EnemySpawner : MonoBehaviour {

    [Range(1, 5)]
    public int delayBetweenSpawns = 2;

    private float timer;

	void Start () {
        timer = delayBetweenSpawns;
	}
	
	void Update () {
        timer -= Time.deltaTime;

        if(timer <= 0 && !PauseManager.isPaused)
        {
            GameObject enemy = ObjectPoolingManager.Instance.GetObject("Zombie_Temp");
            enemy.transform.position = transform.position;
            enemy.transform.rotation = Quaternion.identity;
            enemy.SetActive(true);

            SolveOperations.operations.Add(enemy);

            timer = delayBetweenSpawns;
        }
	}
}
