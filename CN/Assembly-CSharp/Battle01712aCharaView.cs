﻿// Decompiled with JetBrains decompiler
// Type: Battle01712aCharaView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Battle01712aCharaView : MonoBehaviour
{
  public void setSprite(Sprite sprite)
  {
    ((Component) this).GetComponent<NGxMaskSpriteWithScale>().MainUI2DSprite.sprite2D = sprite;
    ((Component) this).GetComponent<NGxMaskSpriteWithScale>().FitMask();
  }
}
