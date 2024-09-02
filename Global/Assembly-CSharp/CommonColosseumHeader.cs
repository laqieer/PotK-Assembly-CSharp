// Decompiled with JetBrains decompiler
// Type: CommonColosseumHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class CommonColosseumHeader : CommonHeaderBase
{
  public UIButton ibtnHome;
  public UIButton ibtnBackColosseum;
  public UILabel txtTitleColosseum;
  public UI2DSprite emblemImg;
  private int emblemID = -1;

  [DebuggerHidden]
  private IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonColosseumHeader.\u003CStart\u003Ec__Iterator8CA()
    {
      \u003C\u003Ef__this = this
    };
  }

  protected override void Update()
  {
    base.Update();
    this.UpdateApRecoveryTime();
    if (!this.UpdateApGauge())
      return;
    this.bp.setValue(this.player.Value.bp);
  }

  public void SetInfo(CommonColosseumHeader.BtnMode mode, System.Action buttonEvent)
  {
    if (mode == CommonColosseumHeader.BtnMode.Back)
      this.EnableBackBtn(buttonEvent);
    else
      this.EnableHomeBtn(buttonEvent);
  }

  public void EnableHomeBtn(System.Action buttonEvent)
  {
    this.ibtnHome.isEnabled = true;
    EventDelegate.Set(this.ibtnHome.onClick, new EventDelegate.Callback(buttonEvent.Invoke));
    ((Component) this.ibtnHome).gameObject.SetActive(true);
    ((Component) this.ibtnBackColosseum).gameObject.SetActive(false);
  }

  public void EnableBackBtn(System.Action buttonEvent)
  {
    this.ibtnBackColosseum.isEnabled = true;
    this.ibtnBackColosseum.onClick.Clear();
    EventDelegate.Set(this.ibtnBackColosseum.onClick, new EventDelegate.Callback(buttonEvent.Invoke));
    ((Component) this.ibtnHome).gameObject.SetActive(false);
    ((Component) this.ibtnBackColosseum).gameObject.SetActive(true);
  }

  public void DisableBtn()
  {
    this.ibtnHome.isEnabled = false;
    this.ibtnBackColosseum.isEnabled = false;
  }

  public enum BtnMode
  {
    Back,
    Home,
  }
}
