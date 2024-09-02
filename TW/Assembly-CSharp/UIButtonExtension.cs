// Decompiled with JetBrains decompiler
// Type: UIButtonExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class UIButtonExtension
{
  public static void SetPossibility(this UIButton button, bool enabled)
  {
    UISprite component = ((Component) button).GetComponent<UISprite>();
    UISprite[] componentsInChildren = ((Component) button).GetComponentsInChildren<UISprite>();
    Color color = !enabled ? Color.gray : Color.white;
    component.color = color;
    ((IEnumerable<UISprite>) componentsInChildren).ForEach<UISprite>((Action<UISprite>) (x => x.color = color));
    ((Behaviour) button).enabled = enabled;
  }
}
