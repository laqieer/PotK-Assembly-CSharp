// Decompiled with JetBrains decompiler
// Type: UILabelExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public static class UILabelExtension
{
  public static void SetText(this UILabel label, string text)
  {
    if (!Object.op_Implicit((Object) label))
      return;
    label.text = text;
  }

  public static void SetTextLocalize(this UILabel label, string text)
  {
    label.SetText(text.ToConverter());
  }

  public static void SetTextLocalize(this UILabel label, int num)
  {
    label.SetTextLocalize(num.ToString());
  }
}
