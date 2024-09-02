// Decompiled with JetBrains decompiler
// Type: Transfer01271Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using UnityEngine;

#nullable disable
public class Transfer01271Menu : BackButtonMenuBase
{
  [SerializeField]
  private NGxScroll scroll;

  public void Init() => ((Component) this.scroll.scrollView).transform.localPosition = Vector3.zero;

  public void IbtnPopupPublish()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
    Consts.GetInstance();
    Singleton<CommonRoot>.GetInstance().isLoading = true;
  }

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();
}
