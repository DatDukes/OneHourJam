using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class BezierEnemy : MonoBehaviour
{
    public GameObject[] Path;
    public float PathDuration;

    public bool DoIShoot;
    public float FireRate;
    public float projectileParSalve;
    public GameObject projectile;

    private Vector3[] path;
    private float timer = 0;

    void Start()
    {
        path = Path.Select(p => p.transform.position).ToArray();
        transform.DOPath(path, PathDuration, PathType.CubicBezier).onComplete = () => Destroy(gameObject);
        timer = Random.Range(0, FireRate);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > FireRate) 
        {
            Fire();
            timer = 0;
        }
    }

    public IEnumerator Salve() 
    {
        int i = 0;
        while(i < projectileParSalve)
        {
            Fire();
            i++;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void Fire() 
    {
        GameObject go = Instantiate(projectile);
        Vector3 target = transform.position;
        go.transform.position = transform.position;
        go.transform.DOMove(target + Vector3.down * 10, 3.0f).onComplete = () => Destroy(go);
    }
}
