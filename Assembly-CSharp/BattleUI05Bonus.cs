// Decompiled with JetBrains decompiler
// Type: BattleUI05Bonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;
using UnityEngine;

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

  private void Awake() => this.Ids = new List<int[]>()
  {
    this.IdsExpUnit,
    this.IdsExpPlayer,
    this.IdsMoney,
    this.IdsItem
  };

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
      Debug.Log((object) "＋＋＋＋＋＋＋　ボーナスなし　＋＋＋＋＋＋＋");
      target.gameObject.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__quest_bonus_sozai__quest_bonus_sozai_prefab", (object) bonusCategory);
      Debug.Log((object) string.Format("＋＋＋＋＋＋＋　spriteName : {0}  ＋＋＋＋＋＋＋", (object) name));
      UISpriteData sprite = target.atlas.GetSprite(name);
      if (sprite != null)
      {
        target.gameObject.SetActive(true);
        target.spriteName = name;
        UIWidget component = target.GetComponent<UIWidget>();
        Vector3 localPosition = component.transform.localPosition;
        component.SetRect(0.0f, 0.0f, (float) sprite.width, (float) sprite.height);
        component.transform.localPosition = localPosition;
      }
      else
      {
        Debug.LogWarning((object) string.Format("＋＋＋＋＋＋＋　{0}がありません　＋＋＋＋＋＋＋", (object) name));
        target.gameObject.SetActive(false);
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
