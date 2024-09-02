// Decompiled with JetBrains decompiler
// Type: Popup02344dMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Popup02344dMenu : NGMenuBase
{
  protected System.Action onCallback;
  [SerializeField]
  private UI2DSprite TitleImg;
  [SerializeField]
  private UILabel TxtDescription1;
  [SerializeField]
  private UILabel TxtDescription2;
  [SerializeField]
  private GameObject link_Icon;

  [DebuggerHidden]
  public IEnumerator Init(RankUpInfoRank_up_rewards[] rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02344dMenu.\u003CInit\u003Ec__IteratorA1F()
    {
      rewards = rewards,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u003Ef__this = this
    };
  }

  public void SetCallback(System.Action callback) => this.onCallback = callback;

  public virtual void IbtnOK()
  {
    if (this.onCallback != null)
      this.onCallback();
    Singleton<PopupManager>.GetInstance().onDismiss();
  }
}
