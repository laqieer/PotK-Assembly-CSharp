// Decompiled with JetBrains decompiler
// Type: Shop99915Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using UnityEngine;

#nullable disable
public class Shop99915Menu : BackButtonMenuBase
{
  [SerializeField]
  private UILabel TxtTitle;
  [SerializeField]
  private UILabel TxtDescription;

  public void SetText(string name)
  {
    string str = name != null ? name : Consts.Lookup("UNIQUE_ICON_KEY");
    string text1 = Consts.Lookup("SHOP_99915_TXT_TITLE");
    string text2 = Consts.Lookup("SHOP_99915_TXT_DESCRIPTION", (IDictionary) new Hashtable()
    {
      {
        (object) nameof (name),
        (object) str
      }
    });
    this.TxtTitle.SetText(text1);
    this.TxtDescription.SetText(text2);
  }

  public void IbtnOK()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnOK();
}
