// Decompiled with JetBrains decompiler
// Type: BattleUI05ScoreRewardPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BattleUI05ScoreRewardPopup : MonoBehaviour
{
  [SerializeField]
  private UILabel point;
  [SerializeField]
  private UILabel description;
  public System.Action callback;
  private bool effectEnd;
  [SerializeField]
  private GameObject[] iconParentOne;
  [SerializeField]
  private GameObject[] iconParentTwo;
  [SerializeField]
  private GameObject[] iconParentThree;
  [SerializeField]
  private GameObject[] iconParentFour;
  [SerializeField]
  private GameObject[] iconParentFive;
  [SerializeField]
  private GameObject[] iconParentSix;
  [SerializeField]
  private GameObject[] iconParentSeven;
  private Dictionary<int, GameObject[]> iconParents;
  [SerializeField]
  private GameObject popupObj;

  [DebuggerHidden]
  public IEnumerator Init(
    QuestScoreBattleFinishContextScore_achivement_rewards rewardList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopup.\u003CInit\u003Ec__Iterator8D9()
    {
      rewardList = rewardList,
      \u003C\u0024\u003ErewardList = rewardList,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateRewardIcon(GameObject parent, QuestScoreAchivementRewardReceived reward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopup.\u003CCreateRewardIcon\u003Ec__Iterator8DA()
    {
      parent = parent,
      reward = reward,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Ereward = reward
    };
  }

  [DebuggerHidden]
  public IEnumerator Init(
    QuestScoreBattleFinishContextScore_total_rewards rewardList)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopup.\u003CInit\u003Ec__Iterator8DB()
    {
      rewardList = rewardList,
      \u003C\u0024\u003ErewardList = rewardList,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateRewardIcon(GameObject parent, QuestScoreTotalRewardReceived reward)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BattleUI05ScoreRewardPopup.\u003CCreateRewardIcon\u003Ec__Iterator8DC()
    {
      parent = parent,
      reward = reward,
      \u003C\u0024\u003Eparent = parent,
      \u003C\u0024\u003Ereward = reward
    };
  }

  public void SetTapCallBack(System.Action callback) => this.callback = callback;

  public void onTap()
  {
    if (this.callback == null || !this.effectEnd)
      return;
    TweenAlpha component = this.popupObj.GetComponent<TweenAlpha>();
    if (Object.op_Inequality((Object) component, (Object) null))
      component.PlayForward();
    this.callback();
  }

  public void onFinish() => this.effectEnd = true;
}
