// Decompiled with JetBrains decompiler
// Type: Quest0022Bonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Quest0022Bonus : MonoBehaviour
{
  [SerializeField]
  private GameObject container;
  [SerializeField]
  private UISprite category;
  [SerializeField]
  private UILabel limitNumberLabel;
  [SerializeField]
  private List<GameObject> timeUnit;

  public void SetBonusCategory(int bonusCategory)
  {
    if (bonusCategory == 0)
    {
      this.container.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__002-2_sozai__002-2_sozai_prefab", (object) bonusCategory);
      UISpriteData sprite = this.category.atlas.GetSprite(name);
      if (sprite != null)
      {
        this.container.SetActive(true);
        this.category.spriteName = name;
        UIWidget component = ((Component) this.category).GetComponent<UIWidget>();
        Vector3 localPosition = ((Component) component).transform.localPosition;
        component.SetRect(0.0f, 0.0f, (float) sprite.width, (float) sprite.height);
        ((Component) component).transform.localPosition = localPosition;
      }
      else
      {
        Debug.LogWarning((object) ("Bonus category texture does not exist at " + name));
        this.container.SetActive(false);
      }
    }
  }

  public void SetLimitTimeNumber(DateTime targetDateTime, DateTime now)
  {
    double limit = Math.Floor((targetDateTime - now).TotalMinutes);
    if (limit > 0.0)
    {
      if (limit > 1440.0)
      {
        this.SetSpriteLimitTime((int) Math.Floor(limit / 1440.0));
        this.timeUnit[0].SetActive(true);
        this.timeUnit[1].SetActive(false);
        this.timeUnit[2].SetActive(false);
      }
      else if (limit > 60.0)
      {
        this.SetSpriteLimitTime((int) Math.Floor(limit / 60.0));
        this.timeUnit[0].SetActive(false);
        this.timeUnit[1].SetActive(true);
        this.timeUnit[2].SetActive(false);
      }
      else
      {
        this.SetSpriteLimitTime((int) limit);
        this.timeUnit[0].SetActive(false);
        this.timeUnit[1].SetActive(false);
        this.timeUnit[2].SetActive(true);
      }
    }
    else
      this.container.SetActive(false);
  }

  private void SetSpriteLimitTime(int limit) => this.limitNumberLabel.SetText(limit.ToString());
}
