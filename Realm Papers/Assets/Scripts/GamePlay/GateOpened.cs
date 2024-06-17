using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealm.System.Gate
{
    public class GateOpened : MonoBehaviour
    {
        [SerializeField] private Gate gate;
        [SerializeField] private Sprite[] gateStateSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private int count;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") )
            {
                spriteRenderer.sprite = gateStateSprite[1];
                gate.OpenGate();
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
                    gate.CloseGate();
                    spriteRenderer.sprite = gateStateSprite[0];
                }
            }
        }
    }
}
