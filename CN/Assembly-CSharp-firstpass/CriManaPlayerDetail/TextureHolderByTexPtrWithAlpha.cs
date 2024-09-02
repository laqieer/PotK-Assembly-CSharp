// Decompiled with JetBrains decompiler
// Type: CriManaPlayerDetail.TextureHolderByTexPtrWithAlpha
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace CriManaPlayerDetail
{
  internal class TextureHolderByTexPtrWithAlpha : TextureHolder
  {
    private const float constOffsetTexels = 1f;
    private Texture2D[] m_Texture_y;
    private Texture2D[] m_Texture_u;
    private Texture2D[] m_Texture_v;
    private Texture2D[] m_Texture_a;

    public TextureHolderByTexPtrWithAlpha(
      int argWidth,
      int argHeight,
      uint argTexNumber,
      bool alphaMode)
      : base(argWidth, argHeight, argTexNumber, true, 1f)
    {
    }

    [DebuggerHidden]
    public override IEnumerator CreateTexture()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new TextureHolderByTexPtrWithAlpha.\u003CCreateTexture\u003Ec__Iterator5()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override bool UpdateTexture(
      Material material,
      int playerId,
      CriManaPlayer.FrameInfo frameInfo)
    {
      bool flag = CriManaPlayer.criManaUnityPlayer_UpdateTextureYuvaByPtr_APIv1(playerId, ((Texture) this.m_Texture_y[(IntPtr) this.texIndex]).GetNativeTexturePtr(), ((Texture) this.m_Texture_u[(IntPtr) this.texIndex]).GetNativeTexturePtr(), ((Texture) this.m_Texture_v[(IntPtr) this.texIndex]).GetNativeTexturePtr(), ((Texture) this.m_Texture_a[(IntPtr) this.texIndex]).GetNativeTexturePtr(), frameInfo);
      if (flag)
      {
        material.SetTexture("Texture_y", (Texture) this.m_Texture_y[(IntPtr) this.texIndex]);
        material.SetTexture("Texture_u", (Texture) this.m_Texture_u[(IntPtr) this.texIndex]);
        material.SetTexture("Texture_v", (Texture) this.m_Texture_v[(IntPtr) this.texIndex]);
        material.SetTexture("Texture_a", (Texture) this.m_Texture_a[(IntPtr) this.texIndex]);
        this.texIndex = (this.texIndex + 1U) % this.texNumber;
      }
      return flag;
    }

    public override void DestroyTexture()
    {
      for (int index = 0; (long) index < (long) this.texNumber; ++index)
      {
        Object.Destroy((Object) this.m_Texture_y[index]);
        Object.Destroy((Object) this.m_Texture_u[index]);
        Object.Destroy((Object) this.m_Texture_v[index]);
        Object.Destroy((Object) this.m_Texture_a[index]);
      }
      this.m_Texture_y = (Texture2D[]) null;
      this.m_Texture_u = (Texture2D[]) null;
      this.m_Texture_v = (Texture2D[]) null;
      this.m_Texture_a = (Texture2D[]) null;
    }
  }
}
