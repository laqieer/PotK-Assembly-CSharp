// Decompiled with JetBrains decompiler
// Type: Quest0022DropMaterialList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Quest0022DropMaterialList : Quest0022MissionDescriptions
{
  public List<UI2DSprite> thum_list_;

  public void Init()
  {
  }

  [DebuggerHidden]
  public IEnumerator Init(int quest_s_id, CommonQuestType quest_type)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Quest0022DropMaterialList.\u003CInit\u003Ec__Iterator20A()
    {
      quest_type = quest_type,
      quest_s_id = quest_s_id,
      \u003C\u0024\u003Equest_type = quest_type,
      \u003C\u0024\u003Equest_s_id = quest_s_id,
      \u003C\u003Ef__this = this
    };
  }

  public void ClearThum()
  {
    this.thum_list_.ForEach((Action<UI2DSprite>) (x => ((Component) x).transform.GetChildren().ForEach<Transform>((Action<Transform>) (y => Object.Destroy((Object) ((Component) y).gameObject)))));
  }

  public GameObject SetThum(int id, GameObject prefab)
  {
    return prefab.Clone(((Component) this.thum_list_[id - 1]).transform);
  }
}
