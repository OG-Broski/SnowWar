using System.Collections.Generic;
using UnityEngine;
using System;



public class SpawnEnemyManager : MonoBehaviour
{
    public static Action<Transform,Transform,int> EnemySpawned;
    [SerializeField] private Transform _parentLines;
    [SerializeField] private List<LineStruct> _lines = new List<LineStruct>();
    [SerializeField] private float _spawnDelay = 10f;
    [SerializeField] private float _currentSpawnTime;

    private int _curentIndex;
    private void OnEnable()
    {
        _currentSpawnTime = 0;
        Hit.OnHitEnemy += ChangeTrueLine;      
        InitLines(); 
    }

    private void InitLines(){
        for(int i = 0 ; i<_parentLines.childCount ; i++){
            _lines.Add(new LineStruct(true , _parentLines.GetChild(i)));
        }
    }
    private Transform GetFreeLine(){
        for(int i = 0;i<_lines.Count;i++){
            if(_lines[i].canUse){
                ChangeFalseLine(i);
                _curentIndex = i;
                return _lines[i].position; 
            }
        }
        return null;
    }

    private void Update()
    {
        _currentSpawnTime -=Time.deltaTime;
        if(_currentSpawnTime<=0){
            RestTimer();
            Spawn();    
            
        }
    }
    private void Spawn(){
        Transform freeLine = GetFreeLine();
            if(freeLine != null ){
                EnemySpawned?.Invoke(freeLine,this.transform,_curentIndex);
            }
    }
    private void ChangeFalseLine(int index){
        var str = _lines[index];
        str.canUse = false;
        _lines[index] = str;
    }
    private void ChangeTrueLine(Enemy _npc){
        var index = _npc.indexLine;
        var str = _lines[index];
        str.canUse = true;
        _lines[index] = str;
        CheakLineActive();
    }

    
  
    private void CheakLineActive(){
        int notActveLine= 0;
        for(int i = 0;i<_lines.Count;i++){
            if(_lines[i].canUse){
                notActveLine++;
            }
            if(notActveLine >= _lines.Count){
                RestTimer();
                Spawn();
            }
        }
    }
    private void RestTimer(){
        _currentSpawnTime = _spawnDelay;
    }

      private void OnDisable()
    {
        // _currentSpawnTime = 0;
        Hit.OnHitEnemy -= ChangeTrueLine;
    }
}
