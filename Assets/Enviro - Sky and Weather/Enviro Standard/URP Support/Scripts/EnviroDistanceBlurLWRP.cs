﻿using System.Collections.Generic;
using UnityEngine.Serialization;
#if ENVIRO_LWRP
namespace UnityEngine.Rendering.LWRP
{
    public class EnviroDistanceBlurLWRP : ScriptableRendererFeature
    {
        EnviroDistanceBlurPass blitPass;

        private Camera myCam;
        private Material postProcessMat;
        private Texture2D distributionTexture;

        private void CreateMaterialsAndTextures()
        {
            if (postProcessMat == null)
                postProcessMat = new Material(Shader.Find("Hidden/EnviroDistanceBlur"));

            if (distributionTexture == null)
                distributionTexture = Resources.Load("tex_enviro_linear", typeof(Texture2D)) as Texture2D;
        }

        public override void Create()
        {
            if (EnviroSkyMgr.instance == null || EnviroSky.instance == null)
                return;

            CreateMaterialsAndTextures();
            blitPass = new EnviroDistanceBlurPass(RenderPassEvent.BeforeRenderingTransparents, postProcessMat, distributionTexture);
        }

        public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
        {
            if (renderingData.cameraData.camera.cameraType == CameraType.Preview || renderingData.cameraData.camera.cameraType == CameraType.Reflection)
                return;

            myCam = renderingData.cameraData.camera;

            if (EnviroSkyMgr.instance != null && EnviroSky.instance != null && EnviroSkyMgr.instance.useDistanceBlur)
            {

                if (renderingData.cameraData.isSceneViewCamera && !EnviroSky.instance.showDistanceBlurInEditor)
                    return;

                var src = renderer.cameraColorTarget;
                var dest = RenderTargetHandle.CameraTarget;

                if(blitPass == null)
                    blitPass = new EnviroDistanceBlurPass(RenderPassEvent.BeforeRenderingTransparents, postProcessMat, distributionTexture);

                blitPass.Setup(myCam, src, dest);
                renderer.EnqueuePass(blitPass);
            }
        }
    }
}
#endif