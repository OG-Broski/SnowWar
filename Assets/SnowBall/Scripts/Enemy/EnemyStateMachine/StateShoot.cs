using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateShoot : IBehavior
{   
    public static Func<GameObject> OnTookSnowBall;

    private float _offsetSpawnX = 1.5f;

    private float _constantForce = 20f;
    private Enemy _npc;
    public void DoState()
    {
        Shooting();
        _npc.SetBehaviorIdle();
    }

    public void Enter(Enemy npc)
    {
      if(_npc == null){
          _npc = npc;
      }
    }

    private void Shooting(){
        var snowBall = OnTookSnowBall?.Invoke();
        if(snowBall != null){
            snowBall.GetComponent<SnowBall>().isFromcharacter = false;
            snowBall.transform.position = new Vector2(_npc.transform.position.x - _offsetSpawnX,_npc.transform.position.y);
            var rigidbodySnow = snowBall.GetComponent<Rigidbody2D>();
            rigidbodySnow.gravityScale = 0;
            rigidbodySnow.AddForce(Vector2.left * _constantForce , ForceMode2D.Impulse);
        }
    }
}
