// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResourceSofdecPrimeYuv
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace CriMana.Detail
{
  public class RendererResourceSofdecPrimeYuv : RendererResource
  {
    private int width;
    private int height;
    private bool hasAlpha;
    private bool additive;
    private bool useUserShader;
    private Shader shader;
    private Matrix4x4 movieUvTransform = Matrix4x4.identity;
    private Texture2D textureY;
    private Texture2D textureU;
    private Texture2D textureV;
    private Texture2D textureA;

    public RendererResourceSofdecPrimeYuv(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader)
    {
      this.width = RendererResource.NextPowerOfTwo(RendererResource.Ceiling64((int) movieInfo.width));
      this.height = RendererResource.NextPowerOfTwo(RendererResource.Ceiling16((int) movieInfo.height));
      this.hasAlpha = movieInfo.hasAlpha;
      this.additive = additive;
      this.useUserShader = Object.op_Inequality((Object) userShader, (Object) null);
      this.shader = !this.useUserShader ? Shader.Find(!this.hasAlpha ? (!additive ? "CriMana/SofdecPrimeYuv" : "CriMana/SofdecPrimeYuvAdditive") : (!additive ? "CriMana/SofdecPrimeYuva" : "CriMana/SofdecPrimeYuvaAdditive")) : userShader;
      this.UpdateMatrix(movieInfo.dispWidth, movieInfo.dispHeight);
      this.textureY = new Texture2D(this.width, this.height, (TextureFormat) 1, false);
      ((Texture) this.textureY).wrapMode = (TextureWrapMode) 1;
      this.textureU = new Texture2D(this.width / 2, this.height / 2, (TextureFormat) 1, false);
      ((Texture) this.textureU).wrapMode = (TextureWrapMode) 1;
      this.textureV = new Texture2D(this.width / 2, this.height / 2, (TextureFormat) 1, false);
      ((Texture) this.textureV).wrapMode = (TextureWrapMode) 1;
      if (!this.hasAlpha)
        return;
      this.textureA = new Texture2D(this.width, this.height, (TextureFormat) 1, false);
      ((Texture) this.textureA).wrapMode = (TextureWrapMode) 1;
    }

    protected override void OnDisposeManaged()
    {
    }

    protected override void OnDisposeUnmanaged()
    {
      if (Object.op_Inequality((Object) this.textureY, (Object) null))
      {
        Object.Destroy((Object) this.textureY);
        this.textureY = (Texture2D) null;
      }
      if (Object.op_Inequality((Object) this.textureU, (Object) null))
      {
        Object.Destroy((Object) this.textureU);
        this.textureU = (Texture2D) null;
      }
      if (Object.op_Inequality((Object) this.textureV, (Object) null))
      {
        Object.Destroy((Object) this.textureV);
        this.textureV = (Texture2D) null;
      }
      if (!Object.op_Inequality((Object) this.textureA, (Object) null))
        return;
      Object.Destroy((Object) this.textureA);
      this.textureA = (Texture2D) null;
    }

    public override bool IsPrepared() => true;

    public override bool ContinuePreparing() => true;

    public override bool IsSuitable(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader)
    {
      bool flag1 = movieInfo.codecType == CodecType.SofdecPrime;
      bool flag2 = this.width >= (int) movieInfo.width && this.height >= (int) movieInfo.height;
      bool flag3 = this.hasAlpha == movieInfo.hasAlpha;
      bool flag4 = this.additive == additive;
      bool flag5 = !this.useUserShader || Object.op_Equality((Object) userShader, (Object) this.shader);
      return flag1 && flag2 && flag3 && flag4 && flag5;
    }

    public override void AttachToPlayer(int playerId)
    {
    }

    public override bool UpdateFrame(int playerId, FrameInfo frameInfo)
    {
      bool flag = !this.hasAlpha ? RendererResourceSofdecPrimeYuv.criManaUnityPlayer_UpdateTextureYuvByPtr(playerId, ((Texture) this.textureY).GetNativeTexturePtr(), ((Texture) this.textureU).GetNativeTexturePtr(), ((Texture) this.textureV).GetNativeTexturePtr(), frameInfo) : RendererResourceSofdecPrimeYuv.criManaUnityPlayer_UpdateTextureYuvaByPtr(playerId, ((Texture) this.textureY).GetNativeTexturePtr(), ((Texture) this.textureU).GetNativeTexturePtr(), ((Texture) this.textureV).GetNativeTexturePtr(), ((Texture) this.textureA).GetNativeTexturePtr(), frameInfo);
      if (flag)
        this.UpdateMatrix(frameInfo.dispWidth, frameInfo.dispHeight);
      return flag;
    }

    public override bool UpdateMaterial(Material material)
    {
      material.shader = this.shader;
      material.SetTexture("TextureY", (Texture) this.textureY);
      material.SetTexture("TextureU", (Texture) this.textureU);
      material.SetTexture("TextureV", (Texture) this.textureV);
      if (this.hasAlpha)
        material.SetTexture("TextureA", (Texture) this.textureA);
      material.SetMatrix("MovieUvTransform", this.movieUvTransform);
      return true;
    }

    private void UpdateMatrix(uint dispWidth, uint dispHeight)
    {
      float num1 = (float) (dispWidth - 1U) / (float) this.width;
      float num2 = (float) (dispHeight - 1U) / (float) this.height;
      this.movieUvTransform.m00 = num1;
      this.movieUvTransform.m11 = -num2;
      this.movieUvTransform.m13 = num2;
    }

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern bool criManaUnityPlayer_UpdateTextureYuvByPtr(
      int player_id,
      IntPtr texid_y,
      IntPtr texid_u,
      IntPtr texid_v,
      [In, Out] FrameInfo frame_info);

    [DllImport("cri_ware_unity", CallingConvention = CallingConvention.Winapi)]
    private static extern bool criManaUnityPlayer_UpdateTextureYuvaByPtr(
      int player_id,
      IntPtr texid_y,
      IntPtr texid_u,
      IntPtr texid_v,
      IntPtr texid_a,
      [In, Out] FrameInfo frame_info);
  }
}
