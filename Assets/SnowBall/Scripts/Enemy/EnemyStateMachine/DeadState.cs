using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class DeadState : IBehavior
{
    private Enemy _npc;
     private Camera _camera;
     private SkeletonAnimation _skeletonAnimation;
    public void Enter(Enemy npc)
    {
      if(_npc == null){
          _npc = npc;
          this._camera = _npc.camera;
          _skeletonAnimation = _npc.GetComponent<SkeletonAnimation>();
          _skeletonAnimation.AnimationName = "run";
      }
    }
      public void DoState()
    {
        _npc.transform.Translate(Vector2.up * Time.fixedDeltaTime,Space.World); 
        Vector3 point = _camera.WorldToViewportPoint(_npc.transform.position); 
        if(point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f) {
          _npc.gameObject.SetActive(false);
        }
    }
}
