using System;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
public class Enemy : MonoBehaviour
{
    private Dictionary<Type, IBehavior> _behaviorMap;
    private IBehavior _behaviorCurrent;
    private SkeletonAnimation  _skeletonAnimation;

    public StateRun stateRun = new StateRun();
    public DeadState deadState = new DeadState();
    public StateIdle stateIdle = new StateIdle();
    public StateShoot stateShoot = new StateShoot();

    [SerializeField]private DataConteinerEnemy _dataEnemy;
    public DataConteinerEnemy dataEnemy => _dataEnemy;
    
    private float _timeToStateShoot => dataEnemy.timeToStateShoot;
    private float _currentTimeToStateShoot;
    
    public int indexLine { get; private set;}

    public Transform startPoint {get;private set;}

    [SerializeField] private Camera _camera ;
    public new Camera camera => _camera;

    private bool _isDead;

    private void OnEnable()
    {
        Timer.OnPause += SetBehaviorIdle;
         PoolEnemy.PassedStartingPoint += SetStartPoint;
         this.InitBehaviors();
        this.SetBehaviorByDefault();
        _currentTimeToStateShoot = _timeToStateShoot;
        _isDead = false;
    }
   private void Start()
       { 
            _camera = Camera.main;
            _skeletonAnimation = GetComponent<SkeletonAnimation>();
            _skeletonAnimation.skeleton.SetSkin(dataEnemy.skin);
       }

       private void Update()
       {
            if(!_isDead){
                _currentTimeToStateShoot -= Time.deltaTime;
                if(_currentTimeToStateShoot<=0){
                    this.SetBehaviorShoot();
                    SetTimeToStateShoot();
                }
            }
            _behaviorCurrent.DoState();
       }

       private void InitBehaviors(){
            this._behaviorMap = new Dictionary<Type, IBehavior>();
            this._behaviorMap[typeof(StateRun)] =new StateRun();
            this._behaviorMap[typeof(StateIdle)] =new StateIdle();
            this._behaviorMap[typeof(StateShoot)] =new StateShoot();
             this._behaviorMap[typeof(DeadState)] =new DeadState();
             this._behaviorMap[typeof(StateGoToStart)] =new StateGoToStart();
        }
        private void SetBehavior(IBehavior _newBehavior){  
            if(_newBehavior!=this._behaviorCurrent){
                this._behaviorCurrent = _newBehavior;
                this._behaviorCurrent.Enter(this);
            }

        }

        private void SetBehaviorByDefault(){
            SetBehaviorGoToStart();
        }

        private IBehavior GetBehavior<T>() where T : IBehavior{
            var _type = typeof(T);
            return this._behaviorMap[_type];
        }

        public void SetBehaviorIdle(){
            var _behavior = this.GetBehavior<StateIdle>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
        }
        public void SetBehaviorMove(){
            var _behavior = this.GetBehavior<StateRun>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
        }


        public void SetBehaviorShoot(){
            var _behavior = this.GetBehavior<StateShoot>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
        }
        public void SetBehaviorDead(){
            var _behavior = this.GetBehavior<DeadState>();
            if(_behaviorCurrent != _behavior)
                this.SetBehavior(_behavior);
                _isDead= true;
        }
         public void SetBehaviorGoToStart(){
            var _behavior = this.GetBehavior<StateGoToStart>();
            if(_behaviorCurrent != _behavior){
                this.SetBehavior(_behavior);
            }

        }

        private void SetTimeToStateShoot(){
        _currentTimeToStateShoot = _timeToStateShoot;
    }

    private void SetStartPoint(Transform line,int lineIndex){
        startPoint = line;
        indexLine = lineIndex;        
    }
        private void OnDisable()
    {
        PoolEnemy.PassedStartingPoint -= SetStartPoint;
        Timer.OnPause -= SetBehaviorIdle;
    }
}
