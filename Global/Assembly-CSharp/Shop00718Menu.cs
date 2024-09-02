// Decompiled with JetBrains decompiler
// Type: Shop00718Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using I2.Loc;
using UnityEngine;

#nullable disable
public class Shop00718Menu : BackButtonMenuBase
{
  [SerializeField]
  private UITextList txtList;
  [SerializeField]
  protected UILabel TxtPopuptitle;
  [SerializeField]
  protected UILabel TxtPopuptitle2;
  [SerializeField]
  protected UILabel TxtREADME;

  public void setData()
  {
    this.txtList.Add(Consts.Lookup("COMMISSION_ON_TRADE"));
    Localize component = ((Component) this.txtList.textLabel).GetComponent<Localize>();
    if (!Object.op_Implicit((Object) component))
      return;
    Debug.LogWarning((object) ("Unnecessary localize tag on " + ((Object) ((Component) this.txtList.textLabel).gameObject).name));
    ((Behaviour) component).enabled = false;
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
