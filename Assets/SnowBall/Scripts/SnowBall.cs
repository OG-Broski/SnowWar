using System.Collections;
using UnityEngine;
using System;


public class SnowBall : MonoBehaviour
{   
    
    [SerializeField] private float _lifeTime = 2f;
    [SerializeField] private GameObject _effect;

    public bool isFromcharacter {get;set;} = false;
    
    private Camera _camera;

    private void OnEnable()
    {
        StartCoroutine(LifeRoutine());
    }
    private void OnDisable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        StopCoroutine(LifeRoutine());
    }
 private void Start()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        Vector2 point = _camera.WorldToViewportPoint(transform.position); 
        if(point.y < 0f || point.y > 1f || point.x > 1f || point.x < 0f) {
         Deactivate();
        }
    }
    private IEnumerator LifeRoutine(){
        yield return new WaitForSecondsRealtime(this._lifeTime);
        this.Deactivate();
    }
    private void Deactivate(){
        this.gameObject.SetActive(false);
    }
}
