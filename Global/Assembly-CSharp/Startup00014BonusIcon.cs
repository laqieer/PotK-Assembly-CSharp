// Decompiled with JetBrains decompiler
// Type: Startup00014BonusIcon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup00014BonusIcon
{
  [SerializeField]
  private Startup00014Menu menu;
  [SerializeField]
  private int depth = 8;
  [SerializeField]
  private float scale = 0.7f;
  private Transform trans;
  private List<Transform> iconPositionList = new List<Transform>();
  [SerializeField]
  private List<GameObject> iconList = new List<GameObject>();

  public List<GameObject> IconList
  {
    get => this.iconList;
    set => this.iconList = value;
  }

  public void Clear()
  {
    foreach (Component iconPosition in this.iconPositionList)
      Object.Destroy((Object) iconPosition.gameObject);
    foreach (Object icon in this.IconList)
      Object.Destroy(icon);
    this.iconPositionList.Clear();
    this.IconList.Clear();
  }

  [DebuggerHidden]
  public IEnumerator Initialize(
    List<Transform> IconPositionList,
    List<LoginbonusReward> loginBonusRewardList,
    int s_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014BonusIcon.\u003CInitialize\u003Ec__Iterator136()
    {
      IconPositionList = IconPositionList,
      loginBonusRewardList = loginBonusRewardList,
      s_index = s_index,
      \u003C\u0024\u003EIconPositionList = IconPositionList,
      \u003C\u0024\u003EloginBonusRewardList = loginBonusRewardList,
      \u003C\u0024\u003Es_index = s_index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator SetIcons(List<LoginbonusReward> loginBonusRewardList, int s_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup00014BonusIcon.\u003CSetIcons\u003Ec__Iterator137()
    {
      loginBonusRewardList = loginBonusRewardList,
      s_index = s_index,
      \u003C\u0024\u003EloginBonusRewardList = loginBonusRewardList,
      \u003C\u0024\u003Es_index = s_index,
      \u003C\u003Ef__this = this
    };
  }

  private void AddObj(GameObject iconPrefab)
  {
    iconPrefab.GetComponent<UIWidget>().depth = this.depth;
    iconPrefab.transform.localScale = new Vector3(this.scale, this.scale, 1f);
    this.IconList.Add(iconPrefab);
  }

  public void ListEnable(bool flag)
  {
    this.IconList.ForEach((Action<GameObject>) (x => x.SetActive(flag)));
  }
}
