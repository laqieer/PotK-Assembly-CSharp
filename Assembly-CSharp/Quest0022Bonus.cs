// Decompiled with JetBrains decompiler
// Type: Quest0022Bonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

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
      Debug.Log((object) "＋＋＋＋＋＋＋　ボーナスなし　＋＋＋＋＋＋＋");
      this.container.SetActive(false);
    }
    else
    {
      string name = string.Format("slc_Bonus_{0}.png__GUI__002-2_sozai__002-2_sozai_prefab", (object) bonusCategory);
      if (Singleton<NGGameDataManager>.GetInstance().IsSea)
        name = name.Replace("002-2_sozai_sea", "002-2_sozai_sea");
      Debug.Log((object) string.Format("＋＋＋＋＋＋＋　spriteName : {0}  ＋＋＋＋＋＋＋", (object) name));
      UISpriteData sprite = this.category.atlas.GetSprite(name);
      if (sprite != null)
      {
        this.container.SetActive(true);
        this.category.spriteName = name;
        UIWidget component = this.category.GetComponent<UIWidget>();
        Vector3 localPosition = component.transform.localPosition;
        component.SetRect(0.0f, 0.0f, (float) sprite.width, (float) sprite.height);
        component.transform.localPosition = localPosition;
      }
      else
      {
        Debug.LogWarning((object) string.Format("＋＋＋＋＋＋＋　{0}がありません　＋＋＋＋＋＋＋", (object) name));
        this.container.SetActive(false);
      }
    }
  }

  public void SetLimitTimeNumber(DateTime targetDateTime, DateTime now)
  {
    double num1 = Math.Floor((targetDateTime - now).TotalMinutes);
    if (num1 > 0.0)
    {
      if (num1 > 1440.0)
      {
        double num2 = Math.Floor(num1 / 1440.0);
        if (num2 > 99.0)
        {
          this.container.SetActive(false);
        }
        else
        {
          this.SetSpriteLimitTime((int) num2);
          this.timeUnit[0].SetActive(true);
          this.timeUnit[1].SetActive(false);
          this.timeUnit[2].SetActive(false);
        }
      }
      else if (num1 > 60.0)
      {
        this.SetSpriteLimitTime((int) Math.Floor(num1 / 60.0));
        this.timeUnit[0].SetActive(false);
        this.timeUnit[1].SetActive(true);
        this.timeUnit[2].SetActive(false);
      }
      else
      {
        this.SetSpriteLimitTime((int) num1);
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
      this.limitNumberLeft.gameObject.SetActive(true);
      this.limitNumberRight.gameObject.SetActive(true);
      this.limitNumberCenter.gameObject.SetActive(false);
    }
    else
    {
      this.SetSpriteNum(limit, this.limitNumberCenter);
      this.limitNumberLeft.gameObject.SetActive(false);
      this.limitNumberRight.gameObject.SetActive(false);
      this.limitNumberCenter.gameObject.SetActive(true);
    }
  }

  private void SetSpriteNum(int num, UISprite sprite)
  {
    string name = string.Format("slc_number_{0}.png__GUI__002-2_sozai__002-2_sozai_prefab", (object) num);
    if (Singleton<NGGameDataManager>.GetInstance().IsSea)
      name = name.Replace("002-2_sozai_sea", "002-2_sozai_sea");
    UISpriteData sprite1 = sprite.atlas.GetSprite(name);
    sprite.gameObject.SetActive(true);
    sprite.spriteName = name;
    UIWidget component = sprite.GetComponent<UIWidget>();
    Vector3 localPosition = component.transform.localPosition;
    component.SetRect(0.0f, 0.0f, (float) sprite1.width, (float) sprite1.height);
    component.transform.localPosition = localPosition;
  }
}
