// Decompiled with JetBrains decompiler
// Type: Startup000121Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class Startup000121Menu : NGMenuBase
{
  [SerializeField]
  protected UILabel TxtDate;
  [SerializeField]
  protected UILabel TxtDate2;
  [SerializeField]
  protected UILabel TxtNewstitle;
  [SerializeField]
  protected UILabel TxtNewstitle2;
  [SerializeField]
  protected UILabel TxtTime;
  [SerializeField]
  protected UILabel TxtTime2;
  [SerializeField]
  protected UILabel TxtTitle;
  private List<Startup000121NewsScrollParts> scrollNewsPartList = new List<Startup000121NewsScrollParts>();
  private List<Startup000121EventsScrollParts> scrollEventPartList = new List<Startup000121EventsScrollParts>();
  private List<Startup000121FunctionsScrollParts> scrollFunctionPartList = new List<Startup000121FunctionsScrollParts>();
  public GameObject[] dirButtons;
  public GameObject[] dirNonActiveButtons;
  public GameObject[] containers;
  public GameObject[] scrollContainers;
  public UIPanel panel;
  public UIWidget widget;
  public NGxScroll[] scrolls;
  private GameObject scroll;
  public bool isNews;
  public bool isEvent;
  public bool isFunction;
  public bool isContinue = true;
  public int selectContainer;
  public string listSceneName = "startup000_12";
  private string[] scrollVoice = new string[3]
  {
    "durin_navi_0029",
    "durin_navi_0070",
    "durin_navi_0069"
  };
  [SerializeField]
  private string nextScenename;

  public List<Startup000121NewsScrollParts> ScrollNewsPartList
  {
    get => this.scrollNewsPartList;
    set => this.scrollNewsPartList = value;
  }

  public List<Startup000121EventsScrollParts> ScrollEventPartList
  {
    get => this.scrollEventPartList;
    set => this.scrollEventPartList = value;
  }

  public List<Startup000121FunctionsScrollParts> ScrollFunctionPartList
  {
    get => this.scrollFunctionPartList;
    set => this.scrollFunctionPartList = value;
  }

  public string NextScenename
  {
    get => this.nextScenename;
    set => this.nextScenename = value;
  }

  public void IbtnClose()
  {
    if (Singleton<NGGameDataManager>.GetInstance().InfoOrLoginBonusJump())
      return;
    MypageScene.ChangeScene(false);
  }

  public void ActivContainers(int num)
  {
    this.selectContainer = num;
    for (int index = 0; index < this.dirButtons.Length; ++index)
    {
      this.dirButtons[index].SetActive(index == num);
      this.dirNonActiveButtons[index].SetActive(index != num);
      this.containers[index].SetActive(index == num);
    }
  }

  public void IbtnNews()
  {
    if (this.isNews)
    {
      Singleton<NGSoundManager>.GetInstance().stopVoice();
      Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_9999", this.scrollVoice[0]);
    }
    this.ActivContainers(0);
    this.panel.SetDirty();
    this.scrolls[0].ResolvePosition();
  }

  public void IbtnEvent()
  {
    if (this.isEvent)
    {
      Singleton<NGSoundManager>.GetInstance().stopVoice();
      Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_9999", this.scrollVoice[1]);
    }
    this.ActivContainers(1);
    this.panel.SetDirty();
    this.scrolls[1].ResolvePosition();
  }

  public void IbtnFunctionadd()
  {
    if (this.isFunction)
    {
      Singleton<NGSoundManager>.GetInstance().stopVoice();
      Singleton<NGSoundManager>.GetInstance().playVoiceByStringID("VO_9999", this.scrollVoice[2]);
    }
    this.ActivContainers(2);
    this.panel.SetDirty();
    this.scrolls[2].ResolvePosition();
  }

  [DebuggerHidden]
  public IEnumerator InitNoticeList(OfficialInformationArticle[] infos, int num)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000121Menu.\u003CInitNoticeList\u003Ec__Iterator1A0()
    {
      num = num,
      infos = infos,
      \u003C\u0024\u003Enum = num,
      \u003C\u0024\u003Einfos = infos,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator CheckNew()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Startup000121Menu.\u003CCheckNew\u003Ec__Iterator1A1()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void SetScrolls()
  {
    for (int index = 0; index < this.scrolls.Length; ++index)
      this.scrolls[index].ResolvePosition();
  }
}
