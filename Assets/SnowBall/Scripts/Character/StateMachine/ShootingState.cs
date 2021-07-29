using UnityEngine;
using System;

public class ShootingState : IPlayerBehavior
{
    public static event Func<GameObject> OnTookSnowBall;
    public static event Func<float> TookPowerOfTheThrow;
    public static event Action OnAfterShot;


    [SerializeField] private float _constantForce = 20f;
    private bool _canShoot = false;
    private Vector3 _offsetSpawnSnowBall = new Vector3 (0.5f,0.5f,0f);
    private Character _character;


    public void Enter(Character character)
    {
        if(_character == null){
            _character = character;
        }
        _canShoot = _character._canShoot;
        Shoot();
    }

  

    public void Update()
    {

    }

    private void Shoot(){
        if(_canShoot){
            var snowBall = OnTookSnowBall?.Invoke();
            snowBall.GetComponent<SnowBall>().isFromcharacter = true;
            var extraForce = TookPowerOfTheThrow.Invoke();
            snowBall.transform.position = _character.transform.position + _offsetSpawnSnowBall;
            snowBall.GetComponent<Rigidbody2D>().AddForce(-Vector2.left *_constantForce * extraForce , ForceMode2D.Impulse);
            AfterShoot();
        }
    }
    private void AfterShoot(){
        OnAfterShot?.Invoke();
    }

    public void Exit()
    {
    }
  
}

