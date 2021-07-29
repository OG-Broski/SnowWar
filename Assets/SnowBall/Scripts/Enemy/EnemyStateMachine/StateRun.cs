
using UnityEngine;
using Spine.Unity;

public class StateRun : IBehavior
{
    private Enemy _npc;
    private float _speed => _npc.dataEnemy.speed;
    private Vector2 _direction = Vector2.up;
    private SkeletonAnimation _skeletonAnimation;
    private float _timeToStateIdle = 5f;
     private float _currentTimeToStateIdle;

    public void Enter(Enemy npc)
    {
        SetTimeToStateIdle();
       if(_npc==null){
            _npc = npc;
            _skeletonAnimation = npc.GetComponent<SkeletonAnimation>();
        }
        _skeletonAnimation.AnimationName = "run";

    }
    public void DoState()
    {
        _currentTimeToStateIdle -= Time.deltaTime;
        Runing();
        if(_currentTimeToStateIdle<=0){
            _npc.SetBehaviorIdle();
        }
    }
    private void Runing(){
        _npc.transform.Translate(_direction * _speed * Time.fixedDeltaTime);

        if(_npc.transform.position.y >= Random.Range(2.5f,3.5f)){
            _direction = Vector2.down;
        }

        if(_npc.transform.position.y <= Random.Range(-2.5f,-3.5f)){
            _direction = Vector2.up;
        }
    }
    private void SetTimeToStateIdle(){
        _currentTimeToStateIdle = _timeToStateIdle;
    }
}
