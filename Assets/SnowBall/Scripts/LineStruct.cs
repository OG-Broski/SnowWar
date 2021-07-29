using UnityEngine;



[System.Serializable] public struct LineStruct
    {
       public LineStruct(bool canUse,Transform position){
                this.canUse = canUse;
                this.position = position;

        }
        public bool canUse;
        public Transform position;
    }

