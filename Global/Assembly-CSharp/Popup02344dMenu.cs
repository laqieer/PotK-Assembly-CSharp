// Decompiled with JetBrains decompiler
// Type: Popup02344dMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  private UILabel[] itemNames;
  [SerializeField]
  private Transform[] iconBases;

  [DebuggerHidden]
  public IEnumerator Init(RankUpInfoRank_up_rewards[] rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02344dMenu.\u003CInit\u003Ec__Iterator7DA()
    {
      rewards = rewards,
      \u003C\u0024\u003Erewards = rewards,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetEmblem(RankUpInfoRank_up_rewards reward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Popup02344dMenu.\u003CSetEmblem\u003Ec__Iterator7DB()
    {
      reward = reward,
      \u003C\u0024\u003Ereward = reward,
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
