using UnityEngine;
using System;

public class Hit : MonoBehaviour
{
    public static Action<Enemy> OnHitEnemy;
    public static Action OnHitCharacter;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.TryGetComponent<SnowBall>(out SnowBall snowBall)){
            if(this.TryGetComponent<Enemy>(out Enemy enemy) && snowBall.isFromcharacter){
                enemy.SetBehaviorDead();
                OnHitEnemy?.Invoke(enemy);
                snowBall.gameObject.SetActive(false);
            }   


            else if(this.TryGetComponent<Character>(out Character character) && !snowBall.isFromcharacter){
                OnHitCharacter?.Invoke();
                snowBall.gameObject.SetActive(false);
            }
       }
   }
}
