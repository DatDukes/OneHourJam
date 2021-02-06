using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public GameObject ennemyPrebab;
    public Path[] paths;
    public float SpawnRate;
    public float spawnRateIncrease;

    private float timer;
    private float timescale = 1;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime * timescale;
        timescale += spawnRateIncrease * Time.deltaTime;

        if(timer > SpawnRate) 
        {
            spawn(paths[Random.Range(0, paths.Length)]);
            timer = 0;
        }
    }

    public void spawn(Path path) 
    {
        GameObject go = Instantiate(ennemyPrebab);
        go.transform.position = path.transform.position;
        go.GetComponent<BezierEnemy>().Path = path.pathNodes;
    }
}
