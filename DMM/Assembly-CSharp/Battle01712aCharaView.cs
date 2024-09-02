// Decompiled with JetBrains decompiler
// Type: Battle01712aCharaView
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Battle01712aCharaView : MonoBehaviour
{
  public void setSprite(UnityEngine.Sprite sprite)
  {
    this.GetComponent<NGxMaskSpriteWithScale>().MainUI2DSprite.sprite2D = sprite;
    this.GetComponent<NGxMaskSpriteWithScale>().FitMask();
  }
}
