using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaperRealm.Type.Fitur
{
    public class AnimCurveExample : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve curve;

        [SerializeField]
        private GameObject objectToSpawn;

        [SerializeField]
        private Vector3 start;

        [Range(1, 100)]
        [SerializeField]
        private float curveLength;

        [Range(2, 100)]
        [SerializeField]
        private int spawnCount;

        [Range(1, 100)]
        [SerializeField]
        private float heightMultiplier;

        private void Start()
        {
            for (int i = 0; i < spawnCount; ++i)
            {
                float deltaSpawn = i / (float)spawnCount;

                GameObject go = GameObject.Instantiate(objectToSpawn);
                go.transform.position = new Vector3(
                    Mathf.Lerp(start.x, start.x + curveLength, deltaSpawn),
                    start.y + (curve.Evaluate(deltaSpawn) * heightMultiplier),
                    start.z);
            }
        }
    }
}
