// Decompiled with JetBrains decompiler
// Type: Mypage00113Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using UnityEngine;

#nullable disable
public class Mypage00113Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;
  [SerializeField]
  private UILabel bodyText;

  public void Initialize()
  {
    this.bodyText.SetTextLocalize(LocalizationManager.GetTermTranslation("consts_ConstsConsts_description_14"));
    this.scroll.ResolvePosition();
  }

  public void IbtnBack()
  {
    if (this.IsPushAndSet())
      return;
    this.backScene();
  }

  public override void onBackButton() => this.IbtnBack();
}
