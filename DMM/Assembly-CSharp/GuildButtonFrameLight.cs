﻿// Decompiled with JetBrains decompiler
// Type: GuildButtonFrameLight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class GuildButtonFrameLight : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite sprFrame;
  [SerializeField]
  private UI2DSprite sprColor;

  public IEnumerator Init(Color color)
  {
    if ((Object) this.sprFrame != (Object) null)
      this.sprFrame.color = color;
    if ((Object) this.sprColor != (Object) null)
    {
      this.sprColor.color = color;
      yield break;
    }
  }
}
