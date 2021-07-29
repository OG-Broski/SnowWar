using System;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public static Action OnCanShoot;

    [SerializeField] private float _speed;
    public float speed =>_speed;
    [SerializeField] private float _shootDelay;
    private float _currentTime;
    public bool _canShoot{get;private set;} = false;
    private Dictionary<Type, IPlayerBehavior> _behaviorMap;
    private IPlayerBehavior _behaviorCurrent;

private void OnEnable()
{
    ShootingState.OnAfterShot += AfterShoot;
}
private void OnDisable()
{
    ShootingState.OnAfterShot -= AfterShoot;
}
private void Start()
{
    this.InitBehaviors();
    this.SetBehaviorByDefault();
    _currentTime = _shootDelay;
}

private void Update()
{
    _currentTime -= Time.deltaTime;
    if(_currentTime <= 0){
        _currentTime = _shootDelay;
        _canShoot = true;
        OnCanShoot?.Invoke();
    } 
    _behaviorCurrent.Update();
}

        private void InitBehaviors(){
            this._behaviorMap = new Dictionary<Type, IPlayerBehavior>();
            this._behaviorMap[typeof(MoveState)] =new MoveState();
            this._behaviorMap[typeof(IdleState)] =new IdleState();
            this._behaviorMap[typeof(ShootingState)] =new ShootingState();
        }
        private void SetBehavior(IPlayerBehavior _newBehavior){  
            if(this._behaviorCurrent !=null){
                this._behaviorCurrent.Exit();
            }
                this._behaviorCurrent = _newBehavior;
                this._behaviorCurrent.Enter(this);

        }

        private void SetBehaviorByDefault(){
            this.SetBehaviorShoot();
        }

        private IPlayerBehavior GetBehavior<T>() where T : IPlayerBehavior{
            var _type = typeof(T);
            return this._behaviorMap[_type];
        }

        public void SetBehaviorIdle(){
            var _behavior = this.GetBehavior<IdleState>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
        }
        public void SetBehaviorMove(){
            var _behavior = this.GetBehavior<MoveState>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
        }


        public void SetBehaviorShoot(){
            var _behavior = this.GetBehavior<ShootingState>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
        }
        private void AfterShoot(){
            _canShoot = false;
        }
}
