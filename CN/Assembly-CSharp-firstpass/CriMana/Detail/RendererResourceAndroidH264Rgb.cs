// Decompiled with JetBrains decompiler
// Type: CriMana.Detail.RendererResourceAndroidH264Rgb
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

#nullable disable
namespace CriMana.Detail
{
  public class RendererResourceAndroidH264Rgb : RendererResource
  {
    private int playerId;
    private bool attached;
    private int width;
    private int height;
    private bool hasAlpha;
    private bool additive;
    private bool useUserShader;
    private Shader shader;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    private float[] movieUvTransformRaw = new float[16];
    private Matrix4x4 movieUvTransform = Matrix4x4.identity;
    private uint oesTexture;
    private Texture2D texture;

    public RendererResourceAndroidH264Rgb(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader)
    {
      if (movieInfo.hasAlpha)
        Debug.LogError((object) "[CRIWARE] H.264 with Alpha is unsupported");
      this.playerId = playerId;
      this.width = (int) movieInfo.width;
      this.height = (int) movieInfo.height;
      this.hasAlpha = movieInfo.hasAlpha;
      this.additive = additive;
      this.useUserShader = Object.op_Inequality((Object) userShader, (Object) null);
      this.shader = !Object.op_Inequality((Object) userShader, (Object) null) ? Shader.Find(!this.hasAlpha ? (!additive ? "CriMana/AndroidH264Rgb" : "CriMana/AndroidH264RgbAdditive") : (!additive ? "Diffuse" : "Diffuse")) : userShader;
      this.oesTexture = RendererResourceAndroidH264Rgb.criManaUnity_MediaCodecCreateTexture_ANDROID();
      this.texture = Texture2D.CreateExternalTexture(this.width, this.height, (TextureFormat) 5, false, false, (IntPtr) (long) this.oesTexture);
    }

    protected override void OnDisposeManaged()
    {
    }

    protected override void OnDisposeUnmanaged()
    {
      if (Object.op_Inequality((Object) this.texture, (Object) null))
      {
        Object.Destroy((Object) this.texture);
        if (this.attached)
        {
          RendererResourceAndroidH264Rgb.criManaUnityPlayer_MediaCodecDetachTexture_ANDROID(this.playerId, this.oesTexture);
          this.attached = false;
        }
        RendererResourceAndroidH264Rgb.criManaUnity_MediaCodecDeleteTexture_ANDROID(this.oesTexture);
        this.oesTexture = 0U;
      }
      this.texture = (Texture2D) null;
      this.movieUvTransformRaw = (float[]) null;
    }

    public override bool IsPrepared() => true;

    public override bool ContinuePreparing() => true;

    public override bool IsSuitable(
      int playerId,
      MovieInfo movieInfo,
      bool additive,
      Shader userShader)
    {
      bool flag1 = playerId == this.playerId;
      bool flag2 = movieInfo.codecType == CodecType.H264;
      bool flag3 = this.width == (int) movieInfo.width && this.height == (int) movieInfo.height;
      bool flag4 = this.hasAlpha == movieInfo.hasAlpha;
      bool flag5 = this.additive == additive;
      bool flag6 = !this.useUserShader || Object.op_Equality((Object) userShader, (Object) this.shader);
      return flag1 && flag2 && flag3 && flag4 && flag5 && flag6;
    }

    public override void AttachToPlayer(int playerId)
    {
      if (this.playerId == playerId)
      {
        RendererResourceAndroidH264Rgb.criManaUnityPlayer_MediaCodecAttachTexture_ANDROID(playerId, this.oesTexture);
        this.attached = true;
      }
      else
        Debug.LogError((object) "[CRIWARE] Internal logic error");
    }

    public override bool UpdateFrame(int playerId, FrameInfo frameInfo)
    {
      bool flag = RendererResourceAndroidH264Rgb.criManaUnityPlayer_MediaCodecUpdateTexture_ANDROID(playerId, frameInfo, this.movieUvTransformRaw);
      if (flag)
        this.UpdateMatrix();
      return flag;
    }

    public override bool UpdateMaterial(Material material)
    {
      material.shader = this.shader;
      material.mainTexture = (Texture) this.texture;
      material.SetTexture("TextureRgb", (Texture) this.texture);
      material.SetMatrix("MovieUvTransform", this.movieUvTransform);
      return true;
    }

    private void UpdateMatrix()
    {
      this.movieUvTransform.m00 = this.movieUvTransformRaw[0];
      this.movieUvTransform.m10 = this.movieUvTransformRaw[1];
      this.movieUvTransform.m20 = this.movieUvTransformRaw[2];
      this.movieUvTransform.m30 = this.movieUvTransformRaw[3];
      this.movieUvTransform.m01 = this.movieUvTransformRaw[4];
      this.movieUvTransform.m11 = this.movieUvTransformRaw[5];
      this.movieUvTransform.m21 = this.movieUvTransformRaw[6];
      this.movieUvTransform.m31 = this.movieUvTransformRaw[7];
      this.movieUvTransform.m02 = this.movieUvTransformRaw[8];
      this.movieUvTransform.m12 = this.movieUvTransformRaw[9];
      this.movieUvTransform.m22 = this.movieUvTransformRaw[10];
      this.movieUvTransform.m32 = this.movieUvTransformRaw[11];
      this.movieUvTransform.m03 = this.movieUvTransformRaw[12];
      this.movieUvTransform.m13 = this.movieUvTransformRaw[13];
      this.movieUvTransform.m23 = this.movieUvTransformRaw[14];
      this.movieUvTransform.m33 = this.movieUvTransformRaw[15];
    }

    [DllImport("cri_ware_unity")]
    private static extern uint criManaUnity_MediaCodecCreateTexture_ANDROID();

    [DllImport("cri_ware_unity")]
    private static extern void criManaUnity_MediaCodecDeleteTexture_ANDROID(uint oes_texture);

    [DllImport("cri_ware_unity")]
    private static extern bool criManaUnityPlayer_MediaCodecAttachTexture_ANDROID(
      int player_id,
      uint oes_texture);

    [DllImport("cri_ware_unity")]
    private static extern void criManaUnityPlayer_MediaCodecDetachTexture_ANDROID(
      int player_id,
      uint oes_texture);

    [DllImport("cri_ware_unity")]
    private static extern bool criManaUnityPlayer_MediaCodecUpdateTexture_ANDROID(
      int player_id,
      [In, Out] FrameInfo frame_info,
      [MarshalAs(UnmanagedType.LPArray)] float[] uvTransformMatrix);
  }
}
