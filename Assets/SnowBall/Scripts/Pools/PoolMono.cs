using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T: MonoBehaviour
{
    public T prefab;
    public T[] prefabs{get;} = null;
    public bool autoExpand{get;set;}
    public Transform conteiner {get;}
    private List<T> _poll;

    public PoolMono(T prefab,int count ){
        this.prefab = prefab;
        this.conteiner = null;
        this.CreatePool(count);

    }

    public PoolMono(T prefab,int count,Transform conteiner){
        this.prefab = prefab;
        this.conteiner = conteiner;
        this.CreatePool(count);
    }
    public PoolMono(T[] prefabs,int count,Transform conteiner){
        this.prefabs = prefabs;
        this.conteiner = conteiner;
        this.CreatePool(count,true);
    }

    private void CreatePool(int count,bool isArray = false){
        this._poll = new List<T>();
            if(isArray){
                for(int i = 0; i < this.prefabs.Length; i++){
                    prefab = prefabs[i];
                    for(int z= 0;z<count;z++){
                        this.CreateObject();
                    }
                }
            }
            else
            {
            for(int z= 0;z<count;z++){
            this.CreateObject();
            }
        }
    }
        


    private T CreateObject(bool isActiveByDefault = false){
        var createObject = UnityEngine.Object.Instantiate(this.prefab,this.conteiner);
        createObject.gameObject.SetActive(false);
        this._poll.Add(createObject);
        return createObject;
    }

    public bool HasFreeElement(out T element){
        foreach(var mono in _poll){
            if(!mono.gameObject.activeInHierarchy){
                element=mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public T GetFreeElement(){
        if(this.HasFreeElement(out var element))
            return element;
        if(this.autoExpand){
            return this.CreateObject(true);
        }
        throw new Exception($"There is not free elements in pool of type {typeof(T)}");
    }

}
