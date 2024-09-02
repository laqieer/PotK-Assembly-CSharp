// Decompiled with JetBrains decompiler
// Type: Shop00720ReelPattern
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
    foreach (\u003C\u003E__AnonType3<UI2DSprite, int> anonType3 in ((IEnumerable<UI2DSprite>) this.Icons).Select<UI2DSprite, \u003C\u003E__AnonType3<UI2DSprite, int>>((Func<UI2DSprite, int, \u003C\u003E__AnonType3<UI2DSprite, int>>) ((s, i) => new \u003C\u003E__AnonType3<UI2DSprite, int>(s, i))))
      this.SetIcon(anonType3.s, sprites[anonType3.i]);
    this.SetDiscription(txt);
  }

  private void SetIcon(UI2DSprite target, Sprite sprite) => target.sprite2D = sprite;

  private void SetDiscription(string txt) => this.Description.SetTextLocalize(txt);
}
