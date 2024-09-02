// Decompiled with JetBrains decompiler
// Type: Shop00720RewardPatternData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Shop00720RewardPatternData
{
  private bool isEnabled;
  private List<Sprite> reelPattern = new List<Sprite>();
  private List<Shop00720RewardData> rewardList = new List<Shop00720RewardData>();
  private string description;

  public Shop00720RewardPatternData(int[] reelIds)
  {
    this.isEnabled = ((IEnumerable<int>) reelIds).All<int>((Func<int, bool>) (a => a != 0));
  }

  public bool IsEnabled
  {
    get => this.isEnabled;
    set => this.isEnabled = value;
  }

  public List<Sprite> ReelPattern
  {
    get => this.reelPattern;
    set => this.reelPattern = value;
  }

  public List<Shop00720RewardData> RewardList
  {
    get => this.rewardList;
    set => this.rewardList = value;
  }

  public string Description
  {
    get => this.description;
    set => this.description = value;
  }

  [DebuggerHidden]
  public IEnumerator SetSprite(int[] ids)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Shop00720RewardPatternData.\u003CSetSprite\u003Ec__Iterator45A()
    {
      ids = ids,
      \u003C\u0024\u003Eids = ids,
      \u003C\u003Ef__this = this
    };
  }

  private Future<Sprite> LoadSpriteThumbnail(int id)
  {
    return Singleton<ResourceManager>.GetInstance().Load<Sprite>(string.Format("AssetBundle/Resources/Animations/slot/Texture/lilleImages/slot_icon_{0:D2}f", (object) id));
  }
}
