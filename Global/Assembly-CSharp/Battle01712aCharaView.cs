// Decompiled with JetBrains decompiler
// Type: Battle01712aCharaView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
