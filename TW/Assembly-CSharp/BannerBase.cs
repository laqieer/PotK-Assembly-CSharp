﻿// Decompiled with JetBrains decompiler
// Type: BannerBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class BannerBase : MonoBehaviour
{
  [SerializeField]
  public FloatButton BtnFormation;
  [SerializeField]
  public UI2DSprite IdleSprite;
  [SerializeField]
  private GameObject slcTimeBase;
  [SerializeField]
  private GameObject slcTimeNormal;
  [SerializeField]
  private GameObject slcTimereceivableBase;
  [SerializeField]
  private GameObject slcRankingEventBlackBase;
  [SerializeField]
  private GameObject slcTimeNotice;
  [SerializeField]
  private GameObject slcTimeNoticeSoon;
  [SerializeField]
  public GameObject[] Limit;
  [SerializeField]
  public GameObject[] Left;
  [SerializeField]
  public GameObject[] Center;
  [SerializeField]
  public GameObject[] Right;
  [SerializeField]
  public GameObject[] TimereceivableLimit;
  [SerializeField]
  public GameObject[] TimereceivableLeft;
  [SerializeField]
  public GameObject[] TimereceivableCenter;
  [SerializeField]
  public GameObject[] TimereceivableRight;
  [SerializeField]
  private GameObject[] TimenoticeLimit;
  [SerializeField]
  private GameObject[] TimenoticeLeft;
  [SerializeField]
  private GameObject[] TimenoticeCenter;
  [SerializeField]
  private GameObject[] TimenoticeRight;
  private bool EndTimeAsStart;
  [HideInInspector]
  public DateTime EndTime;
  private GameObject[] currentCenter;
  private GameObject[] currentLeft;
  private GameObject[] currentRight;
  private GameObject[] currentLimit;
  private int lastFigure10 = -1;
  private int lastFigure1 = -1;
  private int lastLimit = -1;
  private List<TweenAlpha> animations_;

  private List<TweenAlpha> animations
  {
    get
    {
      if (this.animations_ == null)
        this.animations_ = new List<TweenAlpha>();
      return this.animations_;
    }
  }

  public static bool PathExist(int id, BannerBase.Type type, int tmp = 0, bool canplay = true)
  {
    return Singleton<ResourceManager>.GetInstance().Contains(BannerBase.GetSpriteIdlePath(id, type, tmp, canplay));
  }

  public static string GetSpriteIdlePath(
    int id,
    BannerBase.Type type,
    int tmp = 0,
    bool canplay = true,
    bool isEarth = false)
  {
    string spriteIdlePath = string.Empty;
    switch (type)
    {
      case BannerBase.Type.mypage:
        spriteIdlePath = string.Format("Prefabs/Banners/MypageBanner/{0}/MypageBanner_idle", (object) id);
        break;
      case BannerBase.Type.quest:
        spriteIdlePath = tmp != 0 ? string.Format("Prefabs/Banners/ExtraQuest/M/{0}/Specialquest_idle", (object) id) : string.Format("Prefabs/Banners/ExtraQuest/L/{0}/Specialquest_idle", (object) id);
        break;
      case BannerBase.Type.quest_lock:
        spriteIdlePath = !canplay ? (!isEarth ? string.Format("Prefabs/Banners/KeyQuest/{0}/Specialquest_idle_lock", (object) id) : string.Format("Prefabs/Banners/EarthKeyQuest/{0}/Specialquest_idle_lock", (object) id)) : (!isEarth ? string.Format("Prefabs/Banners/KeyQuest/{0}/Specialquest_idle", (object) id) : string.Format("Prefabs/Banners/EarthKeyQuest/{0}/Specialquest_idle", (object) id));
        break;
    }
    return spriteIdlePath;
  }

  [DebuggerHidden]
  public IEnumerator LoadAndSetImage(string url)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerBase.\u003CLoadAndSetImage\u003Ec__Iterator216()
    {
      url = url,
      \u003C\u0024\u003Eurl = url,
      \u003C\u003Ef__this = this
    };
  }

  public bool SetEndTimeAsStart(DateTime startdate)
  {
    if (Object.op_Equality((Object) this.slcTimeNotice, (Object) null) || this.TimenoticeLimit == null || this.TimenoticeLimit.Length == 0 || this.TimenoticeLeft == null || this.TimenoticeLeft.Length == 0 || this.TimenoticeCenter == null || this.TimenoticeCenter.Length == 0 || this.TimenoticeRight == null || this.TimenoticeRight.Length == 0)
      return false;
    this.EndTimeAsStart = true;
    this.EndTime = startdate;
    return true;
  }

  public void SetEndTime(DateTime endtime)
  {
    this.EndTimeAsStart = false;
    this.EndTime = endtime;
  }

  public void SetTime(DateTime serverTime, CampaignQuest.RankingEventTerm rankingEventTerm)
  {
    this.slcTimeBase.SetActive(false);
    this.slcTimeNormal.SetActive(false);
    this.slcTimereceivableBase.SetActive(false);
    if (Object.op_Inequality((Object) this.slcRankingEventBlackBase, (Object) null))
      this.slcRankingEventBlackBase.SetActive(false);
    if (Object.op_Inequality((Object) this.slcTimeNotice, (Object) null))
      this.slcTimeNotice.SetActive(false);
    if (Object.op_Inequality((Object) this.slcTimeNoticeSoon, (Object) null))
      this.slcTimeNoticeSoon.SetActive(false);
    GameObject[] leftObjs;
    GameObject[] rightObjs;
    GameObject[] centerObjs;
    GameObject[] limitObjs;
    if (this.EndTimeAsStart)
    {
      leftObjs = this.TimenoticeLeft;
      rightObjs = this.TimenoticeRight;
      centerObjs = this.TimenoticeCenter;
      limitObjs = this.TimenoticeLimit;
      this.slcTimeNotice.SetActive(true);
    }
    else
    {
      switch (rankingEventTerm)
      {
        case CampaignQuest.RankingEventTerm.receive:
          leftObjs = this.TimereceivableLeft;
          rightObjs = this.TimereceivableRight;
          centerObjs = this.TimereceivableCenter;
          limitObjs = this.TimereceivableLimit;
          this.slcTimereceivableBase.SetActive(true);
          break;
        case CampaignQuest.RankingEventTerm.aggregate:
          leftObjs = this.Left;
          rightObjs = this.Right;
          centerObjs = this.Center;
          limitObjs = this.Limit;
          this.slcTimeBase.SetActive(true);
          this.slcTimeNormal.SetActive(true);
          if (Object.op_Inequality((Object) this.slcRankingEventBlackBase, (Object) null))
          {
            this.slcRankingEventBlackBase.SetActive(true);
            break;
          }
          break;
        default:
          leftObjs = this.Left;
          rightObjs = this.Right;
          centerObjs = this.Center;
          limitObjs = this.Limit;
          this.slcTimeBase.SetActive(true);
          this.slcTimeNormal.SetActive(true);
          break;
      }
    }
    this.setTime(leftObjs, rightObjs, centerObjs, limitObjs, this.EndTime - serverTime);
    if (this.EndTimeAsStart)
      this.BtnFormation.isEnabled = false;
    else
      this.BtnFormation.isEnabled = true;
  }

  private void setTime(
    GameObject[] leftObjs,
    GameObject[] rightObjs,
    GameObject[] centerObjs,
    GameObject[] limitObjs,
    TimeSpan countdown)
  {
    this.currentLeft = leftObjs;
    this.currentRight = rightObjs;
    this.currentCenter = centerObjs;
    this.currentLimit = limitObjs;
    this.updateTime(countdown);
  }

  protected void updateTime(TimeSpan tspan, float duration = 0.0f)
  {
    int num1;
    int num2;
    int num3;
    if (tspan.TotalDays >= 99.0)
    {
      num1 = 9;
      num2 = 9;
      num3 = 0;
    }
    else if (tspan.TotalDays >= 1.0)
    {
      num1 = (int) (tspan.TotalDays / 10.0);
      num2 = (int) (tspan.TotalDays % 10.0);
      num3 = 0;
    }
    else if (tspan.TotalHours >= 1.0)
    {
      int num4 = (int) (tspan.TotalMinutes / 60.0) + (tspan.TotalMinutes % 60.0 == 0.0 ? 0 : 1);
      num1 = num4 / 10;
      num2 = num4 % 10;
      num3 = 1;
    }
    else
    {
      if (tspan.TotalSeconds <= 0.0)
      {
        num1 = 0;
        num2 = 0;
      }
      else
      {
        int num5 = (int) (tspan.TotalSeconds / 60.0) + (tspan.TotalSeconds % 60.0 == 0.0 ? 0 : 1);
        num1 = num5 / 10;
        num2 = num5 % 10;
      }
      num3 = 2;
    }
    if (num3 == 2 && num1 == 0 && num2 == 1 && this.EndTimeAsStart && Object.op_Inequality((Object) this.slcTimeNoticeSoon, (Object) null))
    {
      num3 = -1;
      num2 = -1;
    }
    if ((double) duration > 0.0)
    {
      if (num1 == 0)
      {
        if (this.lastFigure10 <= 0)
        {
          this.switchObject(this.currentCenter, this.lastFigure1, num2, duration);
        }
        else
        {
          this.switchObject(this.currentLeft, this.lastFigure10, -1, duration);
          this.switchObject(this.currentRight, this.lastFigure1, -1, duration);
          this.switchObject(this.currentCenter, -1, num2, duration);
        }
      }
      else if (this.lastFigure10 <= 0)
      {
        this.switchObject(this.currentCenter, this.lastFigure1, -1, duration);
        this.switchObject(this.currentLeft, -1, num1, duration);
        this.switchObject(this.currentRight, -1, num2, duration);
      }
      else
      {
        this.switchObject(this.currentLeft, this.lastFigure10, num1, duration);
        this.switchObject(this.currentRight, this.lastFigure1, num2, duration);
      }
      this.switchObject(this.currentLimit, this.lastLimit, num3, duration);
      if (num3 < 0 && this.lastLimit != num3)
        this.fadeIn(this.slcTimeNoticeSoon, duration);
    }
    else
    {
      ((IEnumerable<GameObject>) this.currentLeft).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
      ((IEnumerable<GameObject>) this.currentRight).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
      ((IEnumerable<GameObject>) this.currentCenter).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
      ((IEnumerable<GameObject>) this.currentLimit).ForEach<GameObject>((Action<GameObject>) (x => x.SetActive(false)));
      if (num1 == 0)
      {
        ((IEnumerable<GameObject>) this.currentCenter).ToggleOnce(num2);
      }
      else
      {
        ((IEnumerable<GameObject>) this.currentLeft).ToggleOnce(num1);
        ((IEnumerable<GameObject>) this.currentRight).ToggleOnce(num2);
      }
      if (num3 < 0)
        this.slcTimeNoticeSoon.SetActive(true);
      else
        ((IEnumerable<GameObject>) this.currentLimit).ToggleOnce(num3);
    }
    this.lastFigure10 = num1;
    this.lastFigure1 = num2;
    this.lastLimit = num3;
  }

  private void switchObject(GameObject[] objs, int indexOff, int indexOn, float duration)
  {
    if (indexOff == indexOn)
      return;
    if (indexOff >= 0 && indexOff < objs.Length)
      this.fadeOut(objs[indexOff], duration);
    if (indexOn < 0 || indexOn >= objs.Length)
      return;
    this.fadeIn(objs[indexOn], duration);
  }

  public void fadeOut(float duration)
  {
    if (this.lastFigure10 <= 0)
    {
      this.fadeOut(this.currentCenter[this.lastFigure1], duration);
    }
    else
    {
      this.fadeOut(this.currentLeft[this.lastFigure10], duration);
      this.fadeOut(this.currentRight[this.lastFigure1], duration);
    }
    this.fadeOut(this.currentLimit[this.lastLimit], duration);
    this.fadeOut(((Component) this.IdleSprite).gameObject, duration);
  }

  private void fadeIn(GameObject go, float duration)
  {
    go.SetActive(true);
    go.GetComponent<UIRect>().alpha = 0.0f;
    TweenAlpha ta = TweenAlpha.Begin(go, duration, 1f);
    this.animations.Add(ta);
    ta.SetOnFinished((EventDelegate.Callback) (() =>
    {
      this.animations.Remove(ta);
      Object.Destroy((Object) ta);
    }));
  }

  private void fadeOut(GameObject go, float duration)
  {
    TweenAlpha ta = TweenAlpha.Begin(go, duration, 0.0f);
    this.animations.Add(ta);
    ta.SetOnFinished((EventDelegate.Callback) (() =>
    {
      go.SetActive(false);
      ta.value = 1f;
      this.animations.Remove(ta);
      Object.Destroy((Object) ta);
    }));
  }

  protected void terminateAnimation()
  {
    if (this.animations_ == null || this.animations_.Count == 0)
      return;
    foreach (TweenAlpha tweenAlpha in this.animations_.ToArray())
    {
      tweenAlpha.value = 1f;
      if ((double) tweenAlpha.to <= 0.0)
        ((Component) tweenAlpha).gameObject.SetActive(false);
      Object.Destroy((Object) tweenAlpha);
    }
    this.animations_.Clear();
  }

  public enum Type
  {
    mypage = 1,
    quest = 2,
    quest_lock = 3,
  }
}
