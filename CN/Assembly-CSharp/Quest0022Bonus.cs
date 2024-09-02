// Decompiled with JetBrains decompiler
// Type: Quest0022Bonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  private UISprite limitNumberLeft;
  [SerializeField]
  private UISprite limitNumberCenter;
  [SerializeField]
  private UISprite limitNumberRight;
  [SerializeField]
  private List<GameObject> timeUnit;

  public void SetBonusCategory(int bonusCategory)
  {
    if (bonusCategory == 0)
    {
      Debug.Log((object) "＋＋＋＋＋＋＋　无奖励　＋＋＋＋＋＋＋");
      this.container.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__002-2_sozai__002-2_sozai_prefab", (object) bonusCategory);
      Debug.Log((object) string.Format("＋＋＋＋＋＋＋　spriteName : {0}  ＋＋＋＋＋＋＋", (object) name));
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
        Debug.LogWarning((object) string.Format("＋＋＋＋＋＋＋　没有{0}　＋＋＋＋＋＋＋", (object) name));
        this.container.SetActive(false);
      }
    }
  }

  public void SetLimitTimeNumber(DateTime targetDateTime, DateTime now)
  {
    double limit1 = Math.Floor((targetDateTime - now).TotalMinutes);
    if (limit1 > 0.0)
    {
      if (limit1 > 1440.0)
      {
        double limit2 = Math.Floor(limit1 / 1440.0);
        if (limit2 > 99.0)
        {
          this.container.SetActive(false);
        }
        else
        {
          this.SetSpriteLimitTime((int) limit2);
          this.timeUnit[0].SetActive(true);
          this.timeUnit[1].SetActive(false);
          this.timeUnit[2].SetActive(false);
        }
      }
      else if (limit1 > 60.0)
      {
        this.SetSpriteLimitTime((int) Math.Floor(limit1 / 60.0));
        this.timeUnit[0].SetActive(false);
        this.timeUnit[1].SetActive(true);
        this.timeUnit[2].SetActive(false);
      }
      else
      {
        this.SetSpriteLimitTime((int) limit1);
        this.timeUnit[0].SetActive(false);
        this.timeUnit[1].SetActive(false);
        this.timeUnit[2].SetActive(true);
      }
    }
    else
      this.container.SetActive(false);
  }

  private void SetSpriteLimitTime(int limit)
  {
    if (limit >= 10)
    {
      this.SetSpriteNum((int) Math.Floor((Decimal) limit / 10M), this.limitNumberLeft);
      this.SetSpriteNum((int) Math.Floor((Decimal) limit % 10M), this.limitNumberRight);
      ((Component) this.limitNumberLeft).gameObject.SetActive(true);
      ((Component) this.limitNumberRight).gameObject.SetActive(true);
      ((Component) this.limitNumberCenter).gameObject.SetActive(false);
    }
    else
    {
      this.SetSpriteNum(limit, this.limitNumberCenter);
      ((Component) this.limitNumberLeft).gameObject.SetActive(false);
      ((Component) this.limitNumberRight).gameObject.SetActive(false);
      ((Component) this.limitNumberCenter).gameObject.SetActive(true);
    }
  }

  private void SetSpriteNum(int num, UISprite sprite)
  {
    string name = string.Format("slc_number_{0}.png__GUI__002-2_sozai__002-2_sozai_prefab", (object) num);
    UISpriteData sprite1 = sprite.atlas.GetSprite(name);
    ((Component) sprite).gameObject.SetActive(true);
    sprite.spriteName = name;
    UIWidget component = ((Component) sprite).GetComponent<UIWidget>();
    Vector3 localPosition = ((Component) component).transform.localPosition;
    component.SetRect(0.0f, 0.0f, (float) sprite1.width, (float) sprite1.height);
    ((Component) component).transform.localPosition = localPosition;
    Debug.Log((object) string.Format("数字『{0}』のサイズ：横 {1}px、纵 {2}px", (object) num, (object) sprite1.width, (object) sprite1.height));
  }
}
