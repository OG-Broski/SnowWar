using UnityEngine;
using UnityEngine.UI;

public class ChangeForce : MonoBehaviour
{
   [SerializeField] Image _forceBar;
   [SerializeField] float _maxTime = 3f;
   [SerializeField] float _timeleft;

   private void Start()
   {
       _forceBar = GetComponent<Image>();
       _timeleft = 0;
       ShootingState.TookPowerOfTheThrow+= GetForce;
   }

   private void Update()
   {
       if(_timeleft < _maxTime){
           _timeleft += Time.deltaTime;
            _forceBar.fillAmount = _timeleft / _maxTime;
       }
       else{
           _timeleft = 0;
       }
   }

   private float GetForce(){
       return _timeleft;
   }
}
