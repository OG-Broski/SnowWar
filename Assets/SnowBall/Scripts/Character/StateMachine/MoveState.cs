
using UnityEngine;
using  Spine.Unity;
using SimpleInputNamespace;

public class MoveState : IPlayerBehavior
{
    private Character _character;
    private  SkeletonAnimation _skeletonAnimation;
    private Joystick _joystick;
    private Rigidbody2D _rigidBody2D;
    private Vector2 moveVelocity;
    private float _speed = 5f;
    private float _maxHeight = 2.5f;
    private float _minHeight = -2.8f;
    public void Enter(Character character)
    {
        if(_skeletonAnimation == null){
            
            _skeletonAnimation = character.GetComponent<SkeletonAnimation>();
           _joystick = character.GetComponent<CharacterInput>().joystick;
           _rigidBody2D = character.GetComponent<Rigidbody2D>();
           _character = character;
        }
        _skeletonAnimation.AnimationName = "run";
        _speed = _character.speed;
    }

    public void Exit()
    {
        _rigidBody2D.velocity = Vector2.zero;
    }



    public void Update()
    {
        float direction = _joystick.yAxis.value;
        moveVelocity = new Vector2(0f,direction).normalized  * _speed;

        _rigidBody2D.MovePosition(_rigidBody2D.position + moveVelocity * Time.fixedDeltaTime);
        if(_character.transform.position.y > _maxHeight){
            _character.transform.position = new Vector2(_character.transform.position.x,2.5f);
        }
        else if(_character.transform.position.y < _minHeight){
            _character.transform.position = new Vector2(_character.transform.position.x,-2.8f);
        }
        
    }

}

