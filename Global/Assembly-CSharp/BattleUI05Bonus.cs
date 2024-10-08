﻿// Decompiled with JetBrains decompiler
// Type: BattleUI05Bonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

#nullable disable
public class BattleUI05Bonus : MonoBehaviour
{
  [SerializeField]
  private List<UISprite> titleIcons;
  [SerializeField]
  private int[] IdsExpUnit;
  [SerializeField]
  private int[] IdsExpPlayer;
  [SerializeField]
  private int[] IdsMoney;
  [SerializeField]
  private int[] IdsItem;
  public List<int[]> Ids;

  private void Awake()
  {
    this.Ids = new List<int[]>()
    {
      this.IdsExpUnit,
      this.IdsExpPlayer,
      this.IdsMoney,
      this.IdsItem
    };
  }

  public void SetBonusTitle(int category, bool initialize = false)
  {
    if (initialize)
    {
      foreach (Component titleIcon in this.titleIcons)
        titleIcon.gameObject.SetActive(false);
    }
    if (category == 0)
      return;
    bool[] array = this.Ids.Select<int[], bool>((Func<int[], bool>) (x => ((IEnumerable<int>) x).Any<int>((Func<int, bool>) (y => y == category)))).ToArray<bool>();
    if (array[0])
      this.SetBonus(category, this.titleIcons[0]);
    else if (array[1])
      this.SetBonus(category, this.titleIcons[1]);
    else if (array[2])
    {
      this.SetBonus(category, this.titleIcons[2]);
    }
    else
    {
      if (!array[3])
        return;
      this.SetBonus(category, this.titleIcons[3]);
    }
  }

  private void SetBonus(int bonusCategory, UISprite target)
  {
    if (bonusCategory == 0)
    {
      ((Component) target).gameObject.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__quest_bonus_sozai__quest_bonus_sozai_prefab", (object) bonusCategory);
      UISpriteData sprite = target.atlas.GetSprite(name);
      if (sprite != null)
      {
        ((Component) target).gameObject.SetActive(true);
        target.spriteName = name;
        UIWidget component = ((Component) target).GetComponent<UIWidget>();
        Vector3 localPosition = ((Component) component).transform.localPosition;
        component.SetRect(0.0f, 0.0f, (float) sprite.width, (float) sprite.height);
        ((Component) component).transform.localPosition = localPosition;
      }
      else
      {
        Debug.LogWarning((object) string.Format("＋＋＋＋＋＋＋　{0}がありません　＋＋＋＋＋＋＋", (object) name));
        ((Component) target).gameObject.SetActive(false);
      }
    }
  }

  public enum BonusType
  {
    ExpUnit,
    ExpPlayer,
    Money,
    Item,
  }
}
