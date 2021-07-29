using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGoToStart : IBehavior
{
    private Enemy _npc;
    private float _speed = 4f;
    public void DoState()
    {
       float y = Mathf.Lerp(_npc.transform.position.y,_npc.startPoint.position.y,Time.fixedDeltaTime / _speed);
       float x = Mathf.Lerp(_npc.transform.position.x,_npc.startPoint.position.x,Time.fixedDeltaTime / _speed);


        _npc.transform.position = new Vector3(x, y ,_npc.transform.position.z);

        if(_npc.transform.position.y <= _npc.startPoint.position.y + 0.5f && _npc.transform.position.x <= _npc.startPoint.position.x +0.2f){
         
          _npc.SetBehaviorMove();
  
        }
    }

    public void Enter(Enemy npc)
    {
       if(_npc == null){
           _npc = npc;
       }
    }
}
