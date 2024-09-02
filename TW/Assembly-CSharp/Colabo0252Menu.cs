// Decompiled with JetBrains decompiler
// Type: Colabo0252Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using gu3.Device;
using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Colabo0252Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtTitle;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private UIScrollView scrollview;
  private string url;

  public virtual void Foreground()
  {
  }

  public virtual void IbtnConfirm()
  {
  }

  public virtual void VScrollBar()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init(
    CrossFestaCampaign colaboData,
    CrossFestaAchieve[] campaignDatas,
    PlayerCrossFestaSerial[] serials)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0252Menu.\u003CInit\u003Ec__Iterator64F()
    {
      colaboData = colaboData,
      campaignDatas = campaignDatas,
      serials = serials,
      \u003C\u0024\u003EcolaboData = colaboData,
      \u003C\u0024\u003EcampaignDatas = campaignDatas,
      \u003C\u0024\u003Eserials = serials,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ScrollCreate(
    GameObject prefab,
    CrossFestaAchieve data,
    int colaboID,
    bool unlock)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Colabo0252Menu.\u003CScrollCreate\u003Ec__Iterator650()
    {
      prefab = prefab,
      data = data,
      colaboID = colaboID,
      unlock = unlock,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003EcolaboID = colaboID,
      \u003C\u0024\u003Eunlock = unlock,
      \u003C\u003Ef__this = this
    };
  }

  public virtual void IbtnSend()
  {
    if (string.IsNullOrEmpty(this.url))
      return;
    DeviceManager.OpenUrl(this.url);
  }

  public virtual void IbtnBack() => this.backScene();
}
