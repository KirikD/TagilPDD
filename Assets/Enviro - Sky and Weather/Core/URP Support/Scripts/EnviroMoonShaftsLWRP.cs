﻿using System.Collections.Generic;
using UnityEngine.Serialization;
#if ENVIRO_LWRP
namespace UnityEngine.Rendering.LWRP
{
    public class EnviroMoonShaftsLWRP : ScriptableRendererFeature
    {
        EnviroBlitPassShafts blitPass;
        private Camera myCam;

        #region Shafts Var
        /// LightShafts
        public enum ShaftsScreenBlendMode
        {
            Screen = 0,
            Add = 1,
        }

        [HideInInspector]
        public int radialBlurIterations = 2;
        private Material shaftsMaterial;
        private Material clearMaterial;
        #endregion

        void CreateMaterialsAndTextures()
        {
            shaftsMaterial = new Material(Shader.Find("Enviro/Effects/LightShafts"));
            clearMaterial = new Material(Shader.Find("Enviro/Effects/ClearLightShafts"));
        }

        void CleanupMaterials()
        {
            if (shaftsMaterial != null)
                DestroyImmediate(shaftsMaterial);
            if (clearMaterial != null)
                DestroyImmediate(clearMaterial);
        }

        public override void Create()
        {
            if (EnviroSkyMgr.instance == null || !EnviroSkyMgr.instance.HasInstance())
                return;

            CreateMaterialsAndTextures();

            blitPass = new EnviroBlitPassShafts(RenderPassEvent.AfterRenderingTransparents, shaftsMaterial, clearMaterial);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (renderingData.cameraData.camera.cameraType == CameraType.Preview || renderingData.cameraData.camera.cameraType == CameraType.SceneView || renderingData.cameraData.camera.cameraType == CameraType.Reflection)
                return;

            myCam = renderingData.cameraData.camera;

            if (EnviroSkyMgr.instance != null && EnviroSkyMgr.instance.HasInstance() && EnviroSkyMgr.instance.useMoonShafts)
            {

                if (renderingData.cameraData.isSceneViewCamera)
                    return;

                var src = renderer.cameraColorTarget;
                var dest = RenderTargetHandle.CameraTarget;

                blitPass.Setup(myCam, src, dest, EnviroSkyMgr.instance.Components.Moon.transform, EnviroSkyMgr.instance.LightShaftsSettings.thresholdColorMoon.Evaluate(EnviroSkyMgr.instance.Time.solarTime), EnviroSkyMgr.instance.LightShaftsSettings.lightShaftsColorMoon.Evaluate(EnviroSkyMgr.instance.Time.solarTime));
                renderer.EnqueuePass(blitPass);

            }
        }
    }
}
#endif