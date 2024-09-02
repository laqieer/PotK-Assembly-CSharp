// Decompiled with JetBrains decompiler
// Type: CommonColosseumHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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

  private void Awake()
  {
  }

  private void Start() => this.Init();

  protected override void Update()
  {
    base.Update();
    this.UpdateApRecoveryTime();
    if (!this.UpdateApGauge())
      return;
    this.bp.setValue(this.player.Value.bp);
  }

  [DebuggerHidden]
  public IEnumerator SetInfo(CommonColosseumHeader.BtnMode mode, System.Action buttonEvent)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new CommonColosseumHeader.\u003CSetInfo\u003Ec__IteratorB3A()
    {
      mode = mode,
      buttonEvent = buttonEvent,
      \u003C\u0024\u003Emode = mode,
      \u003C\u0024\u003EbuttonEvent = buttonEvent,
      \u003C\u003Ef__this = this
    };
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
