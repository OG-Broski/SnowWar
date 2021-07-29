using UnityEngine;

public class PoolSnowBall : MonoBehaviour
{
    [SerializeField] private int _poolCount = 10;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private SnowBall _prefab;
    
    private PoolMono<SnowBall> _pool;
    private void Start()
    {
        this._pool = new PoolMono<SnowBall>(this._prefab,this._poolCount,this.transform);
        this._pool.autoExpand = this._autoExpand;

        ShootingState.OnTookSnowBall += CreateBall;
        StateShoot.OnTookSnowBall += CreateBall;
    }


    private GameObject CreateBall(){
        var ball = this._pool.GetFreeElement();
        return ball.gameObject;
    }
    private void OnDisable()
    {
         ShootingState.OnTookSnowBall -= CreateBall;
         StateShoot.OnTookSnowBall -= CreateBall;
    }


}
