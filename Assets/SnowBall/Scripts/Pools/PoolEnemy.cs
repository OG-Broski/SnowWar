using UnityEngine;
using System;

public class PoolEnemy : MonoBehaviour
{
    public static Action<Transform,int> PassedStartingPoint;
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Enemy[] _prefabs;
    
    private PoolMono<Enemy> _pool;

    private void OnEnable()
    {
         SpawnEnemyManager.EnemySpawned += CreateEnemy;
    }
        private void OnDisable()
    {
        SpawnEnemyManager.EnemySpawned -= CreateEnemy;
    }

    private void Start()
    {
        this._pool = new PoolMono<Enemy>(this._prefabs,this._poolCount,this.transform);
        this._pool.autoExpand = this._autoExpand;
    }

    private void CreateEnemy(Transform line,Transform spawnStart,int indexLine){
        var enemy = this._pool.GetFreeElement();
        enemy.transform.position = spawnStart.position;
        PassedStartingPoint?.Invoke(line,indexLine);
    }

}
