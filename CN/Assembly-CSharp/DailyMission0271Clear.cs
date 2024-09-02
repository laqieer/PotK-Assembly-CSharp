// Decompiled with JetBrains decompiler
// Type: DailyMission0271Clear
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DailyMission0271Clear : BackButtonMenuBase
{
  [SerializeField]
  private List<GameObject> linkObjects;
  [SerializeField]
  private UISprite slcTxtBox;
  [SerializeField]
  private UILabel txtRwardMessage;
  [SerializeField]
  private GameObject[] objTragerBox;
  [SerializeField]
  private GameObject objHimeishi;
  [SerializeField]
  private GameObject dirEffect;
  private UniqueIcons uniqueIcon;

  public void IbtnNo()
  {
    if (this.IsPushAndSet())
      return;
    Debug.Log((object) "[dailymission] call close button");
    Singleton<PopupManager>.GetInstance().onDismiss();
  }

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator CreateThumbnail(Hashtable reward, GameObject linkTarget)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Clear.\u003CCreateThumbnail\u003Ec__Iterator669()
    {
      reward = reward,
      linkTarget = linkTarget,
      \u003C\u0024\u003Ereward = reward,
      \u003C\u0024\u003ElinkTarget = linkTarget
    };
  }

  [DebuggerHidden]
  public IEnumerator SetClearBonus(Hashtable[] Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Clear.\u003CSetClearBonus\u003Ec__Iterator66A()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator SetClearBonus(DailyMission0272Panel.RewardViewModel[] Rewards)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DailyMission0271Clear.\u003CSetClearBonus\u003Ec__Iterator66B()
    {
      Rewards = Rewards,
      \u003C\u0024\u003ERewards = Rewards,
      \u003C\u003Ef__this = this
    };
  }
}
