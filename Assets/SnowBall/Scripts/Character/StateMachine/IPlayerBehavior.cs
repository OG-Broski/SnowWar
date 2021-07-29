using UnityEngine;
public interface IPlayerBehavior {
    void Enter(Character character);
    void Update();
    void Exit();
}