using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PaperRealm.System.CameraPost
{
    public class VirtualCameraPost : MonoBehaviour
    {
        [Header("Post-Processing")]
        [SerializeField] private Volume postProcessingVolume;

        private ColorAdjustments colorAdjustments;

        private void Awake()
        {
            postProcessingVolume.profile.TryGet(out colorAdjustments);
        }

        public void SetCameraEffect(bool isActive)
        {
            colorAdjustments.postExposure.value = isActive ? 0.2f : -0.2f;
            colorAdjustments.saturation.value = isActive ? 55f : -55f;
        }
    }
}
