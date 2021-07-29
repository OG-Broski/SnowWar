
using UnityEngine;
using Spine.Unity;
public class StateIdle : IBehavior
{
    private SkeletonAnimation _skeletonanimation;
    private Enemy _npc;
    private float _timeToStateMove;
    private float _minTime = 1f;
    private float _maxTime = 3f;

    public void Enter(Enemy npc)
    {
        if(_npc==null){
            _npc = npc;
            _skeletonanimation = npc.GetComponent<SkeletonAnimation>();
        }
        RandomTime();
        Idle();
    }
    public void DoState()
    {
        _timeToStateMove -= Time.deltaTime;
        if(_timeToStateMove<=0){
            _npc.SetBehaviorMove();
        }

    }

    private void Idle(){
        _skeletonanimation.AnimationName = "Idle";
    }

    private void  RandomTime(){
        _timeToStateMove = Random.Range(_minTime,_maxTime);
    }

}
