using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealm.System.Gate
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private GameObject gateGO;
    
        [Header("set up parameter")]
        [SerializeField] private Vector3 targetLocation;
        [SerializeField] private float speed;
        
        private bool isAbleToMove;
        private Vector3 firstLocation;
        private Vector3 currentTarget;

        private void Awake()
        {
            firstLocation = transform.localPosition;
        }

        private void Update()
        {
            if(!isAbleToMove) return;
            transform.localPosition = Vector3.Lerp(transform.localPosition, currentTarget, speed * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition, currentTarget) < 0.01f) isAbleToMove = false;
        }

        public void OpenGate()
        {
            isAbleToMove = true;
            currentTarget = targetLocation;          
        }
        
        public void CloseGate()
        {
            isAbleToMove = true;
            currentTarget = firstLocation;
        }
    }
}
