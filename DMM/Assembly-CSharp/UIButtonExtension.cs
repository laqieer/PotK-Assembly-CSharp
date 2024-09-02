// Decompiled with JetBrains decompiler
// Type: UIButtonExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using GameCore;
using System.Collections.Generic;
using UnityEngine;

public static class UIButtonExtension
{
  public static void SetPossibility(this UIButton button, bool enabled)
  {
    UISprite component = button.GetComponent<UISprite>();
    UISprite[] componentsInChildren = button.GetComponentsInChildren<UISprite>();
    Color color = enabled ? Color.white : Color.gray;
    Color color1 = color;
    component.color = color1;
    ((IEnumerable<UISprite>) componentsInChildren).ForEach<UISprite>((System.Action<UISprite>) (x => x.color = color));
    button.enabled = enabled;
  }
}
