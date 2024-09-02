// Decompiled with JetBrains decompiler
// Type: Popup004813Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System.Collections;
using UnityEngine;

#nullable disable
public class Popup004813Menu : BackButtonMenuBase
{
  [SerializeField]
  protected UILabel txtDescription1;
  private System.Action callback;

  public void SetText(PlayerUnit baseUnit, int medal, GrowthParameter parameterPanel)
  {
    this.txtDescription1.SetText(Consts.Format(Consts.GetInstance().POPUP_004813_DESCRIPT_TEXT, (IDictionary) new Hashtable()
    {
      {
        (object) "Count",
        (object) medal.ToLocalizeNumberText()
      }
    }));
  }

  public void SetIbtnOKCallback(System.Action callback) => this.callback = callback;

  public virtual void IbtnPopupOk()
  {
    if (this.IsPushAndSet())
      return;
    if (this.callback != null)
      this.callback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnPopupOk();
}
