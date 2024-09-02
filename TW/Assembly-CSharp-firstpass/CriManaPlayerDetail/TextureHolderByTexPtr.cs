// Decompiled with JetBrains decompiler
// Type: CriManaPlayerDetail.TextureHolderByTexPtr
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
namespace CriManaPlayerDetail
{
  internal class TextureHolderByTexPtr : TextureHolder
  {
    private const float constOffsetTexels = 1f;
    private Texture2D[] m_Texture_y;
    private Texture2D[] m_Texture_u;
    private Texture2D[] m_Texture_v;

    public TextureHolderByTexPtr(int argWidth, int argHeight, uint argTexNumber, bool alphaMode)
      : base(argWidth, argHeight, argTexNumber, false, 1f)
    {
    }

    [DebuggerHidden]
    public override IEnumerator CreateTexture()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new TextureHolderByTexPtr.\u003CCreateTexture\u003Ec__Iterator4()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override bool UpdateTexture(
      Material material,
      int playerId,
      CriManaPlayer.FrameInfo frameInfo)
    {
      bool flag = CriManaPlayer.criManaUnityPlayer_UpdateTextureYuvByPtr_APIv1(playerId, ((Texture) this.m_Texture_y[(IntPtr) this.texIndex]).GetNativeTexturePtr(), ((Texture) this.m_Texture_u[(IntPtr) this.texIndex]).GetNativeTexturePtr(), ((Texture) this.m_Texture_v[(IntPtr) this.texIndex]).GetNativeTexturePtr(), frameInfo);
      if (flag)
      {
        material.SetTexture("Texture_y", (Texture) this.m_Texture_y[(IntPtr) this.texIndex]);
        material.SetTexture("Texture_u", (Texture) this.m_Texture_u[(IntPtr) this.texIndex]);
        material.SetTexture("Texture_v", (Texture) this.m_Texture_v[(IntPtr) this.texIndex]);
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
      }
      this.m_Texture_y = (Texture2D[]) null;
      this.m_Texture_u = (Texture2D[]) null;
      this.m_Texture_v = (Texture2D[]) null;
    }
  }
}
