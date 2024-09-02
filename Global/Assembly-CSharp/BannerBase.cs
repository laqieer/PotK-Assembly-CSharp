// Decompiled with JetBrains decompiler
// Type: BannerBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
  public UI2DSprite PressSprite;
  [SerializeField]
  private GameObject slcTimeBase;
  [SerializeField]
  private GameObject slcTimeNormal;
  [SerializeField]
  private GameObject slcTimereceivableBase;
  [SerializeField]
  private GameObject slcRankingEventBlackBase;
  [SerializeField]
  public GameObject[] Limit;
  [SerializeField]
  public UILabel RemainingTimeLabel;
  [SerializeField]
  public GameObject[] TimereceivableLimit;
  [SerializeField]
  public UILabel TimeReceivableRemainingTimeLabel;
  [HideInInspector]
  public DateTime EndTime;

  public static bool PathExist(int id, BannerBase.Type type, int tmp = 0, bool canplay = true)
  {
    return Singleton<ResourceManager>.GetInstance().Contains(BannerBase.GetSpriteIdlePath(id, type, tmp, canplay)) && Singleton<ResourceManager>.GetInstance().Contains(BannerBase.GetSpritePressedPath(id, type, tmp, canplay));
  }

  public static string GetSpriteIdlePath(int id, BannerBase.Type type, int tmp = 0, bool canplay = true)
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
        spriteIdlePath = !canplay ? string.Format("Prefabs/Banners/KeyQuest/{0}/Specialquest_idle_lock", (object) id) : string.Format("Prefabs/Banners/KeyQuest/{0}/Specialquest_idle", (object) id);
        break;
    }
    return spriteIdlePath;
  }

  public static string GetSpritePressedPath(int id, BannerBase.Type type, int tmp = 0, bool canplay = true)
  {
    string spritePressedPath = string.Empty;
    switch (type)
    {
      case BannerBase.Type.mypage:
        spritePressedPath = string.Format("Prefabs/Banners/MypageBanner/{0}/MypageBanner_pressed", (object) id);
        break;
      case BannerBase.Type.quest:
        spritePressedPath = tmp != 0 ? string.Format("Prefabs/Banners/ExtraQuest/M/{0}/Specialquest_pressed", (object) id) : string.Format("Prefabs/Banners/ExtraQuest/L/{0}/Specialquest_pressed", (object) id);
        break;
      case BannerBase.Type.quest_lock:
        spritePressedPath = !canplay ? string.Format("Prefabs/Banners/KeyQuest/{0}/Specialquest_pressed_lock", (object) id) : string.Format("Prefabs/Banners/KeyQuest/{0}/Specialquest_pressed", (object) id);
        break;
    }
    return spritePressedPath;
  }

  [DebuggerHidden]
  public IEnumerator LoadAndSetImage(string url)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannerBase.\u003CLoadAndSetImage\u003Ec__Iterator1AA()
    {
      url = url,
      \u003C\u0024\u003Eurl = url,
      \u003C\u003Ef__this = this
    };
  }

  public void SetTime(DateTime serverTime, CampaignQuest.RankingEventTerm rankingEventTerm)
  {
    UILabel remainingTimeLabel = this.RemainingTimeLabel;
    this.slcTimeBase.SetActive(false);
    this.slcTimeNormal.SetActive(false);
    this.slcTimereceivableBase.SetActive(false);
    this.slcRankingEventBlackBase.SetActive(false);
    GameObject[] self;
    switch (rankingEventTerm)
    {
      case CampaignQuest.RankingEventTerm.receive:
        self = this.TimereceivableLimit;
        remainingTimeLabel = this.TimeReceivableRemainingTimeLabel;
        this.slcTimereceivableBase.SetActive(true);
        break;
      case CampaignQuest.RankingEventTerm.aggregate:
        self = this.Limit;
        this.slcTimeBase.SetActive(true);
        this.slcTimeNormal.SetActive(true);
        this.slcRankingEventBlackBase.SetActive(true);
        break;
      default:
        self = this.Limit;
        this.slcTimeBase.SetActive(true);
        this.slcTimeNormal.SetActive(true);
        break;
    }
    TimeSpan timeSpan = this.EndTime - serverTime;
    int num1;
    int index;
    if (timeSpan.TotalDays >= 99.0)
    {
      num1 = 99;
      index = 0;
    }
    else if (timeSpan.TotalDays >= 1.0)
    {
      num1 = (int) timeSpan.TotalDays;
      index = 0;
    }
    else if (timeSpan.TotalHours >= 1.0)
    {
      int num2 = (int) (timeSpan.TotalMinutes / 60.0) + (timeSpan.TotalMinutes % 60.0 == 0.0 ? 0 : 1);
      index = 1;
      num1 = num2;
    }
    else
    {
      num1 = timeSpan.TotalSeconds > 0.0 ? (int) (timeSpan.TotalSeconds / 60.0) + (timeSpan.TotalSeconds % 60.0 == 0.0 ? 0 : 1) : 0;
      index = 2;
    }
    if (Object.op_Inequality((Object) remainingTimeLabel, (Object) null))
    {
      ((Component) remainingTimeLabel).gameObject.SetActive(true);
      remainingTimeLabel.SetText(num1.ToString());
    }
    ((IEnumerable<GameObject>) self).ToggleOnce(index);
    ((Component) this.IdleSprite).gameObject.SetActive(true);
    ((Component) this.PressSprite).gameObject.SetActive(false);
  }

  public enum Type
  {
    mypage = 1,
    quest = 2,
    quest_lock = 3,
  }
}
