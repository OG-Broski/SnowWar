using System.Linq;
using UnityEngine;
using  Spine.Unity;

public class IdleState : IPlayerBehavior
{
    private  SkeletonAnimation _skeletonAnimation;
    public void Enter(Character character)
    {

        if(_skeletonAnimation == null){
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
        }
        _skeletonAnimation.AnimationName = "Idle";
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
       
    }

    public void Update()
    {
        
    }
}
