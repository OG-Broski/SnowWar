using UnityEngine;
using SimpleInputNamespace;

public class CharacterInput : MonoBehaviour
{
    [SerializeField] private Character _character;
     [SerializeField] private Joystick _joystick;
     public Joystick joystick =>_joystick;

    private void Update()
    {
        float direction = _joystick.yAxis.value;   
        if(direction != 0){
            _character.SetBehaviorMove();
        }
        else {
            _character.SetBehaviorIdle();
        }

    }
}
