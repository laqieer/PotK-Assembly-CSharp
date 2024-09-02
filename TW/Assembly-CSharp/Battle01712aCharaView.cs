// Decompiled with JetBrains decompiler
// Type: Battle01712aCharaView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
