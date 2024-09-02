// Decompiled with JetBrains decompiler
// Type: Guild0286Scroll
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Guild0286Scroll : BackButtonMenuBase
{
  public NGxScroll2 scroll;
  [SerializeField]
  protected GuildMemberGift[] memberGifts;
  [SerializeField]
  private List<GuildGiftScrollParts> allScroll = new List<GuildGiftScrollParts>();
  [SerializeField]
  private List<GuildGiftInfo> allGuildGiftInfos = new List<GuildGiftInfo>();
  private bool isInitialize;
  private float scrool_start_y;
  private ScrollAreaSetting setting;
  private System.Action initEndAction;
  private Action<GuildMemberGift> buttonAction;
  private GameObject prefab;

  public ScrollAreaSetting Setting
  {
    set => this.setting = value;
  }

  public override void onBackButton()
  {
  }

  public void SetInitEndAction(System.Action initEndAction) => this.initEndAction = initEndAction;

  public void SetPrefab(GameObject prefab) => this.prefab = prefab;

  [DebuggerHidden]
  public IEnumerator Init(GuildMemberGift[] gifts, Action<GuildMemberGift> action)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Scroll.\u003CInit\u003Ec__Iterator7B4()
    {
      action = action,
      gifts = gifts,
      \u003C\u0024\u003Eaction = action,
      \u003C\u0024\u003Egifts = gifts,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator UpdateList(GuildMemberGift[] gifts)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Scroll.\u003CUpdateList\u003Ec__Iterator7B5()
    {
      gifts = gifts,
      \u003C\u0024\u003Egifts = gifts,
      \u003C\u003Ef__this = this
    };
  }

  public void Initialize()
  {
    this.isInitialize = false;
    this.scroll.Clear();
  }

  private void InitializeEnd()
  {
    this.scrool_start_y = ((Component) this.scroll.scrollView).transform.localPosition.y;
    this.isInitialize = true;
  }

  protected override void Update()
  {
    base.Update();
    this.ScrollUpdate();
  }

  protected void ScrollUpdate()
  {
    if (!this.isInitialize || this.allGuildGiftInfos.Count <= this.setting.iconScreenValue)
      return;
    int num1 = this.setting.iconHeight * 2;
    float num2 = ((Component) this.scroll.scrollView).transform.localPosition.y - this.scrool_start_y;
    float num3 = (float) (Mathf.Max(0, this.allGuildGiftInfos.Count - this.setting.iconScreenValue - 1) / this.setting.iconColumnValue * this.setting.iconHeight);
    float num4 = (float) (this.setting.iconHeight * this.setting.iconRowValue);
    if ((double) num2 < 0.0)
      num2 = 0.0f;
    if ((double) num2 > (double) num3)
      num2 = num3;
    bool flag;
    do
    {
      flag = false;
      int num5 = 0;
      foreach (GameObject gameObject in this.scroll)
      {
        GameObject unit = gameObject;
        float num6 = unit.transform.localPosition.y + num2;
        if ((double) num6 > (double) num1)
        {
          int? nullable = this.allGuildGiftInfos.FirstIndexOrNull<GuildGiftInfo>((Func<GuildGiftInfo, bool>) (v => Object.op_Inequality((Object) v.scroll, (Object) null) && Object.op_Equality((Object) ((Component) v.scroll).gameObject, (Object) unit)));
          int info_index = !nullable.HasValue ? this.allGuildGiftInfos.Count : nullable.Value + this.setting.iconMaxValue;
          if (nullable.HasValue && info_index < this.allGuildGiftInfos.Count)
          {
            unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y - num4, 0.0f);
            if (info_index >= this.allGuildGiftInfos.Count)
            {
              unit.SetActive(false);
            }
            else
            {
              this.ResetScroll(num5);
              this.StartCoroutine(this.CreateScroll(info_index, num5));
            }
            flag = true;
          }
        }
        else if ((double) num6 < -((double) num4 - (double) num1))
        {
          int num7 = this.setting.iconMaxValue;
          if (!unit.activeSelf)
          {
            unit.SetActive(true);
            num7 = 0;
          }
          int? nullable = this.allGuildGiftInfos.FirstIndexOrNull<GuildGiftInfo>((Func<GuildGiftInfo, bool>) (v => Object.op_Inequality((Object) v.scroll, (Object) null) && Object.op_Equality((Object) ((Component) v.scroll).gameObject, (Object) unit)));
          int info_index = !nullable.HasValue ? -1 : nullable.Value - num7;
          if (nullable.HasValue && info_index >= 0)
          {
            unit.transform.localPosition = new Vector3(unit.transform.localPosition.x, unit.transform.localPosition.y + num4, 0.0f);
            this.ResetScroll(num5);
            this.StartCoroutine(this.CreateScroll(info_index, num5));
            flag = true;
          }
        }
        ++num5;
      }
    }
    while (flag);
  }

  private void InitializeGuildGiftInfo(GuildMemberGift[] gifts)
  {
    this.allGuildGiftInfos.Clear();
    foreach (GuildMemberGift gift in gifts)
      this.allGuildGiftInfos.Add(new GuildGiftInfo()
      {
        gift = gift
      });
  }

  private void ResetScroll(int index)
  {
    GuildGiftScrollParts scroll = this.allScroll[index];
    ((Component) scroll).gameObject.SetActive(false);
    this.allGuildGiftInfos.Where<GuildGiftInfo>((Func<GuildGiftInfo, bool>) (a => Object.op_Equality((Object) a.scroll, (Object) scroll))).ForEach<GuildGiftInfo>((Action<GuildGiftInfo>) (b => b.scroll = (GuildGiftScrollParts) null));
  }

  [DebuggerHidden]
  private IEnumerator CreateScrollBase(GameObject prefab)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Scroll.\u003CCreateScrollBase\u003Ec__Iterator7B6()
    {
      prefab = prefab,
      \u003C\u0024\u003Eprefab = prefab,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator CreateScroll(int info_index, int unit_index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Guild0286Scroll.\u003CCreateScroll\u003Ec__Iterator7B7()
    {
      unit_index = unit_index,
      info_index = info_index,
      \u003C\u0024\u003Eunit_index = unit_index,
      \u003C\u0024\u003Einfo_index = info_index,
      \u003C\u003Ef__this = this
    };
  }
}
