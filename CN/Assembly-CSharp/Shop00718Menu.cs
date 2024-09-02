// Decompiled with JetBrains decompiler
// Type: Shop00718Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
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

  public void setData() => this.txtList.Add(Consts.GetInstance().COMMISSION_ON_TRADE);

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
