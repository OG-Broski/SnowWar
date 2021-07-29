using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventConteiner 
{
    
    private void OnEnable()
    {
        GameSetting.GameRestar +=UnRegisterAllEvent;
    }
    private void UnRegisterAllEvent(){
        StateShoot.OnTookSnowBall = null;
        Character.OnCanShoot = null;
        Helth.OnCharacterDead = null;
        Score.ScoreUpdated = null;
        Hit.OnHitEnemy = null;
        Hit.OnHitCharacter = null;
        PoolEnemy.PassedStartingPoint = null;
        SpawnEnemyManager.EnemySpawned = null;
        GameSetting.GameTheEnd = null;
    }
}
