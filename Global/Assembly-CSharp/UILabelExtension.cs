// Decompiled with JetBrains decompiler
// Type: UILabelExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using UnityEngine;

#nullable disable
public static class UILabelExtension
{
  public static void SetText(this UILabel label, string text)
  {
    if (!Object.op_Implicit((Object) label))
      return;
    label.text = text;
    Localize component = ((Component) label).GetComponent<Localize>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    Debug.LogWarning((object) ("Unnecessary localization tag found on " + ((Object) ((Component) label).gameObject).name));
    ((Behaviour) component).enabled = false;
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
