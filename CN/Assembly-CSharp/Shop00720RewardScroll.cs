// Decompiled with JetBrains decompiler
// Type: Shop00720RewardScroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop00720RewardScroll : MonoBehaviour
{
  [SerializeField]
  private GameObject Pattern;
  [SerializeField]
  private int RewardListMargin;
  [SerializeField]
  private int RewardListMarginLastBottom;
  [SerializeField]
  private int RewardListHeight;

  [DebuggerHidden]
  public IEnumerator Init(Shop00720RewardPatternData data, Shop00720Prefabs prefabs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720RewardScroll.\u003CInit\u003Ec__Iterator45B()
    {
      data = data,
      prefabs = prefabs,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u003Ef__this = this
    };
  }

  private void SetReelPattern(List<Sprite> pattern, string txt, Shop00720Prefabs prefabs)
  {
    prefabs.DirSlotPattern.Clone(this.Pattern.transform).GetComponent<Shop00720ReelPattern>().Init(pattern, txt);
  }

  [DebuggerHidden]
  private IEnumerator SetReward(List<Shop00720RewardData> data, Shop00720Prefabs prefabs)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720RewardScroll.\u003CSetReward\u003Ec__Iterator45C()
    {
      prefabs = prefabs,
      data = data,
      \u003C\u0024\u003Eprefabs = prefabs,
      \u003C\u0024\u003Edata = data,
      \u003C\u003Ef__this = this
    };
  }

  private void SetRewardPosition(GameObject reward, int index)
  {
    int num = (this.RewardListHeight + this.RewardListMargin) * -index;
    reward.transform.localPosition = new Vector3(0.0f, (float) num);
  }

  private void AdjastHeight(int times)
  {
    UIWidget component1 = ((Component) this).gameObject.GetComponent<UIWidget>();
    BoxCollider component2 = ((Component) this).gameObject.GetComponent<BoxCollider>();
    foreach (int num in Enumerable.Range(1, times))
    {
      component1.height += !num.Equals(1) ? this.RewardListHeight + this.RewardListMargin : this.RewardListHeight;
      if (num.Equals(times))
        component1.height += this.RewardListMarginLastBottom;
    }
    component2.center = new Vector3(component2.center.x, (float) component1.height / -2f, component2.center.z);
    component2.size = new Vector3(component2.size.x, (float) component1.height, component2.size.z);
  }
}
