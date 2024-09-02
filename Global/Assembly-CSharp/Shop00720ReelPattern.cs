// Decompiled with JetBrains decompiler
// Type: Shop00720ReelPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop00720ReelPattern : MonoBehaviour
{
  [SerializeField]
  private UI2DSprite[] Icons;
  [SerializeField]
  private UILabel Description;

  public void Init(List<Sprite> sprites, string txt)
  {
    // ISSUE: object of a compiler-generated type is created
    foreach (\u003C\u003E__AnonType2<UI2DSprite, int> anonType2 in ((IEnumerable<UI2DSprite>) this.Icons).Select<UI2DSprite, \u003C\u003E__AnonType2<UI2DSprite, int>>((Func<UI2DSprite, int, \u003C\u003E__AnonType2<UI2DSprite, int>>) ((s, i) => new \u003C\u003E__AnonType2<UI2DSprite, int>(s, i))))
      this.SetIcon(anonType2.s, sprites[anonType2.i]);
    this.SetDiscription(txt);
  }

  private void SetIcon(UI2DSprite target, Sprite sprite) => target.sprite2D = sprite;

  private void SetDiscription(string txt) => this.Description.SetTextLocalize(txt);
}
