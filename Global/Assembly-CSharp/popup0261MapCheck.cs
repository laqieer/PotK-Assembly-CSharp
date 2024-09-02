// Decompiled with JetBrains decompiler
// Type: popup0261MapCheck
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class popup0261MapCheck : BackButtonMonoBehaiviour
{
  [SerializeField]
  private GameObject map_grid;
  [SerializeField]
  private UIWidget map_base;
  [SerializeField]
  private UILabel limit_txt;
  private readonly string chipExt = ".png__GUI__battle_mapchip__battle_mapchip_prefab";
  private readonly string formationChipExt = "slc_mapchip_ownarea";

  [DebuggerHidden]
  public IEnumerator Init(int stage_id, DateTime endTime)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new popup0261MapCheck.\u003CInit\u003Ec__Iterator81B()
    {
      stage_id = stage_id,
      endTime = endTime,
      \u003C\u0024\u003Estage_id = stage_id,
      \u003C\u0024\u003EendTime = endTime,
      \u003C\u003Ef__this = this
    };
  }

  public void IbtnNo() => Singleton<PopupManager>.GetInstance().onDismiss();

  public override void onBackButton() => this.IbtnNo();

  [DebuggerHidden]
  private IEnumerator setupMapChips(int stage_id)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new popup0261MapCheck.\u003CsetupMapChips\u003Ec__Iterator81C()
    {
      stage_id = stage_id,
      \u003C\u0024\u003Estage_id = stage_id,
      \u003C\u003Ef__this = this
    };
  }

  private UISprite cloneMapChip(string name, int size, GameObject prefab)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(this.map_grid);
    component.spriteName = name + this.chipExt;
    component.width = size;
    component.height = size;
    component.depth = this.map_base.depth + 1;
    return component;
  }

  private void clonePvPFormation(UISprite targetMap, GameObject prefab)
  {
    UISprite component = prefab.CloneAndGetComponent<UISprite>(((Component) targetMap).transform);
    component.spriteName = this.formationChipExt + this.chipExt;
    component.depth = targetMap.depth + 1;
    ((Component) component).transform.Clear();
    component.width = targetMap.width;
    component.height = targetMap.height;
  }

  public void SetTime(DateTime serverTime, DateTime EndTime)
  {
    TimeSpan timeSpan = EndTime - serverTime;
    string empty = string.Empty;
    string text;
    if (timeSpan.TotalDays >= 99.0)
      text = Consts.Lookup("VERSUS_00261REMAIN_MAP_MESSAGE_DAY", (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) 99
        }
      });
    else if (timeSpan.TotalDays >= 1.0)
      text = Consts.Lookup("VERSUS_00261REMAIN_MAP_MESSAGE_DAY", (IDictionary) new Hashtable()
      {
        {
          (object) "day",
          (object) (int) timeSpan.TotalDays
        }
      });
    else if (timeSpan.TotalHours >= 1.0)
      text = Consts.Lookup("VERSUS_00261REMAIN_MAP_MESSAGE_HOUR", (IDictionary) new Hashtable()
      {
        {
          (object) "hour",
          (object) ((int) (timeSpan.TotalMinutes / 60.0) + (timeSpan.TotalMinutes % 60.0 == 0.0 ? 0 : 1))
        }
      });
    else
      text = Consts.Lookup("VERSUS_00261REMAIN_MAP_MESSAGE_DAY", (IDictionary) new Hashtable()
      {
        {
          (object) "min",
          (object) (timeSpan.TotalSeconds > 0.0 ? (int) (timeSpan.TotalSeconds / 60.0) + (timeSpan.TotalSeconds % 60.0 == 0.0 ? 0 : 1) : 0)
        }
      });
    this.limit_txt.SetTextLocalize(text);
  }
}
