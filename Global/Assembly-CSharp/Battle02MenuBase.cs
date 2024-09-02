// Decompiled with JetBrains decompiler
// Type: Battle02MenuBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public abstract class Battle02MenuBase : BattleBackButtonMenuBase
{
  public Color mGreen = new Color(0.0f, 0.863f, 0.118f);
  public Color mRed = new Color(0.98f, 0.0f, 0.0f);
  protected BL.BattleModified<BL.Unit> modified;
  private static Dictionary<BL.Unit, Sprite> spriteCache = new Dictionary<BL.Unit, Sprite>();

  public static void ClearCache() => Battle02MenuBase.spriteCache.Clear();

  [DebuggerHidden]
  public static IEnumerator LoadIcon(BL.Unit v)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Battle02MenuBase.\u003CLoadIcon\u003Ec__Iterator73B()
    {
      v = v,
      \u003C\u0024\u003Ev = v
    };
  }

  public void CreateUnitSprite(UI2DSprite sp)
  {
    BL.Unit v = this.modified.value;
    Sprite sprite1;
    if (Battle02MenuBase.spriteCache.TryGetValue(v, out sprite1))
      sp.sprite2D = sprite1;
    else
      v.unit.LoadSpriteThumbnail().RunOn<Sprite>((MonoBehaviour) this, (Action<Sprite>) (sprite =>
      {
        sp.sprite2D = sprite;
        Battle02MenuBase.spriteCache.Add(v, sp.sprite2D);
      }));
  }

  public void setParentText(UILabel label, int v)
  {
    if (v >= 0)
    {
      label.SetTextLocalize(v.ToString() + string.Empty);
    }
    else
    {
      if (v >= 0)
        return;
      label.SetTextLocalize(Mathf.Abs(v));
      label.SetText("-" + label.text);
    }
  }

  public void setBDText(UILabel label, int v)
  {
    if (v > 0)
    {
      label.SetTextLocalize(Mathf.Abs(v));
      label.SetText("( +" + label.text + " )");
      label.color = this.mGreen;
    }
    else if (v < 0)
    {
      label.SetTextLocalize(Mathf.Abs(v));
      label.SetText("( -" + label.text + " )");
      label.color = this.mRed;
    }
    else
      label.SetText(" ");
  }

  public void setBDTextWrraper(UILabel label, int v)
  {
    if (v > 0)
    {
      label.SetTextLocalize(Mathf.Abs(v));
      label.SetText("( +" + label.text + " )");
      label.color = this.mGreen;
    }
    else if (v < 0)
    {
      label.SetTextLocalize(Mathf.Abs(v));
      label.SetText("( -" + label.text + " )");
      label.color = this.mRed;
    }
    else
      label.SetText(" ");
  }

  public void setColordText(UILabel label, int v, int bd)
  {
    this.setParentText(label, v);
    if (bd > 0)
    {
      label.color = this.mGreen;
    }
    else
    {
      if (bd >= 0)
        return;
      label.color = this.mRed;
    }
  }

  public void setUnit(BL.Unit unit) => this.modified = BL.Observe<BL.Unit>(unit);

  public BL.Unit getUnit() => this.modified.value;

  public virtual void UpdateData()
  {
  }
}
