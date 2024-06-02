using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealm.Type.Fitur
{
    public class GateOpened : MonoBehaviour
    {
        [SerializeField] private Gate _gate;
        [SerializeField] private Sprite[] _gateStateSprite;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private int count;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") )
            {
                _spriteRenderer.sprite = _gateStateSprite[1];
                _gate.OpenGate();
                count++;
            }
        }
        
        private void OnTriggerExit2D(Collider2D col)
        {
            
            if (col.CompareTag("Player"))
            {
                count--;
                if (count < 0) count = 0;

                if (count <= 0)
                {
                    _gate.CloseGate();
                    _spriteRenderer.sprite = _gateStateSprite[0];
                }
            }
        }
    }
}
