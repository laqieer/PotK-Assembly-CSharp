// Decompiled with JetBrains decompiler
// Type: StoneHolder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[Serializable]
public class StoneHolder
{
  [SerializeField]
  private GameObject change_light;
  [SerializeField]
  private StoneHolder.STONE_ID now_stone_id;
  [SerializeField]
  private List<GameObject> stone_list;

  public void StoneChange(StoneHolder.STONE_ID change_stone_id)
  {
    this.NowStoneID = change_stone_id;
    this.StoneList.ToggleOnce((int) this.NowStoneID);
  }

  public void RankUp()
  {
    StoneHolder.STONE_ID change_stone_id = this.NowStoneID + 1;
    if (change_stone_id == StoneHolder.STONE_ID.MAX)
      return;
    this.StoneChange(change_stone_id);
  }

  public void SetChangeLight(bool flag) => this.ChangeLight.SetActive(flag);

  public GameObject ChangeLight
  {
    get => this.change_light;
    set => this.change_light = value;
  }

  public StoneHolder.STONE_ID NowStoneID
  {
    get => this.now_stone_id;
    set => this.now_stone_id = value;
  }

  public List<GameObject> StoneList
  {
    get => this.stone_list;
    set => this.stone_list = value;
  }

  public enum STONE_ID
  {
    BLUE,
    YELLOW,
    RED,
    MAX,
  }
}
