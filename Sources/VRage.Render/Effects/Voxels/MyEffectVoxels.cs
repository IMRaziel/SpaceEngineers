﻿using SharpDX.Direct3D9;

namespace VRageRender.Effects
{
    using Vector2 = VRageMath.Vector2;
    using Vector3 = VRageMath.Vector3;
    using Vector4 = VRageMath.Vector4;
    using Matrix = VRageMath.Matrix;
    using System.Diagnostics;

    class MyEffectVoxels : MyEffectVoxelsBase
    {    
        readonly EffectHandle m_viewMatrix;
        readonly EffectHandle m_diffuseColor;
        
        readonly EffectHandle m_worldMatrix;
        readonly EffectHandle m_enablePerVertexAmbient;

        readonly EffectHandle m_sunColorAndIntensity;
        readonly EffectHandle m_sunDirection;
        readonly EffectHandle m_ambientMinimumAndIntensity;
        readonly EffectHandle m_backlightColorAndIntensity;
        readonly EffectHandle m_enableFog;
        readonly EffectHandle m_sunSpecularColor;

        readonly EffectHandle m_positionToLefBottomOffset;

        readonly EffectHandle m_hasAtmosphere;

        public MyEffectVoxels()
            : base("Effects2\\Voxels\\MyEffectVoxels")
        {
            m_viewMatrix = m_D3DEffect.GetParameter(null, "ViewMatrix");
            m_diffuseColor = m_D3DEffect.GetParameter(null, "DiffuseColor");

            m_worldMatrix = m_D3DEffect.GetParameter(null, "WorldMatrix");
            m_enablePerVertexAmbient = m_D3DEffect.GetParameter(null, "EnablePerVertexAmbient");
            m_sunDirection = m_D3DEffect.GetParameter(null, "LightDirection");
            m_sunColorAndIntensity = m_D3DEffect.GetParameter(null, "LightColorAndIntensity");
            m_backlightColorAndIntensity = m_D3DEffect.GetParameter(null, "BacklightColorAndIntensity");
            m_enableFog = m_D3DEffect.GetParameter(null, "EnableFog");
            m_ambientMinimumAndIntensity = m_D3DEffect.GetParameter(null, "AmbientMinimumAndIntensity");
            m_sunSpecularColor = m_D3DEffect.GetParameter(null, "LightSpecularColor");
            
            m_positionToLefBottomOffset = m_D3DEffect.GetParameter(null, "PositionToLefBottomOffset");

            m_hasAtmosphere = m_D3DEffect.GetParameter(null, "HasAtmosphere");
        }

        public void EnablePerVertexAmbient(bool bEnable)
        {
            m_D3DEffect.SetValue(m_enablePerVertexAmbient, bEnable ? 1 : 0);
        }

        public override void SetViewMatrix(ref Matrix matrix)
        {
            m_D3DEffect.SetValue(m_viewMatrix, matrix);
        }

        public override void SetDiffuseColor(Vector3 diffuseColorAdd)
        {
            m_D3DEffect.SetValue(m_diffuseColor, diffuseColorAdd);
        }

        public void SetWorldMatrix(ref Matrix matrix)
        {
            m_D3DEffect.SetValue(m_worldMatrix, matrix);
        }

        public void SetAmbientMinimumAndIntensity(Vector4 minimumAmbientAndIntensity)
        {
            m_D3DEffect.SetValue(m_ambientMinimumAndIntensity, minimumAmbientAndIntensity);
        }

        public void SetSunDirection(Vector3 lightDirection)
        {
            m_D3DEffect.SetValue(m_sunDirection, lightDirection);
        }

        public void SetSunColorAndIntensity(Vector3 lightColor, float intensity)
        {
            m_D3DEffect.SetValue(m_sunColorAndIntensity, new Vector4(lightColor.X, lightColor.Y, lightColor.Z, intensity));
        }

        public void SetBacklightColorAndIntensity(Vector3 lightColor, float intensity)
        {
            m_D3DEffect.SetValue(m_backlightColorAndIntensity, new Vector4(lightColor.X, lightColor.Y, lightColor.Z, intensity));
        }

        public void EnableFog(bool enable)
        {
            m_D3DEffect.SetValue(m_enableFog, enable ? 1 : 0);
        }

        public void SetSunSpecularColor(Vector3 lightColor)
        {
            m_D3DEffect.SetValue(m_sunSpecularColor, lightColor);
        }

        public void SetPositonToLeftBottomOffset(Vector3 offset)
        {
            m_D3DEffect.SetValue(m_positionToLefBottomOffset, offset);
        }

        public void SetHasAtmosphere(bool hasAtmosphere)
        {
            m_D3DEffect.SetValue(m_hasAtmosphere, hasAtmosphere);
        }
    }
}
