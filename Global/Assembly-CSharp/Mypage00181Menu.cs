// Decompiled with JetBrains decompiler
// Type: Mypage00181Menu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class Mypage00181Menu : BackButtonMenuBase
{
  private const int INDICATOR_WIDTH = 640;
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
  private bool autoScrollFlag;
  [SerializeField]
  private NGWrapScrollParts infoEventScroll;
  [SerializeField]
  private NGxScroll2 InfoScroll;
  [SerializeField]
  private GameObject newsPrefab;
  [SerializeField]
  private GameObject funcPrefab;
  [SerializeField]
  private GameObject eventPrefab;
  [SerializeField]
  private List<Startup000121ScrollParts> partList;
  [SerializeField]
  private string nextSceneName;
  private int count;
  private float delay = 3f;

  public NGWrapScrollParts InfoEventScroll
  {
    get => this.infoEventScroll;
    set => this.infoEventScroll = value;
  }

  public NGxScroll2 infoScroll
  {
    get => this.InfoScroll;
    set => this.InfoScroll = value;
  }

  public GameObject NewsPrefab
  {
    get => this.newsPrefab;
    set => this.newsPrefab = value;
  }

  public GameObject FuncPrefab
  {
    get => this.funcPrefab;
    set => this.funcPrefab = value;
  }

  public GameObject EventPrefab
  {
    get => this.eventPrefab;
    set => this.eventPrefab = value;
  }

  public List<Startup000121ScrollParts> PartList
  {
    get => this.partList;
    set => this.partList = value;
  }

  public string NextSceneName
  {
    get => this.nextSceneName;
    set => this.nextSceneName = value;
  }

  [DebuggerHidden]
  public IEnumerator onInitMenuAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00181Menu.\u003ConInitMenuAsync\u003Ec__Iterator16E()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator onStartMenuAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00181Menu.\u003ConStartMenuAsync\u003Ec__Iterator16F()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Initialize()
  {
    this.infoEventScroll.destroyParts();
    this.infoScroll.GridChildren().ToList<GameObject>().ForEach((Action<GameObject>) (x => Object.Destroy((Object) x)));
    this.InfoScroll.Reset();
  }

  [DebuggerHidden]
  private IEnumerator LoadPrefab()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new Mypage00181Menu.\u003CLoadPrefab\u003Ec__Iterator170()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void CreateInformationList()
  {
    foreach (OfficialInformationArticle article in Singleton<NGGameDataManager>.GetInstance().homeStartUp.articles)
      this.CreateInformation(article);
    bool canDisp = this.infoEventScroll.GetContentChildren().Count<GameObject>() > 1;
    UIScrollView component = this.infoEventScroll.scrollView.GetComponent<UIScrollView>();
    if (Object.op_Inequality((Object) component, (Object) null))
      ((Behaviour) component).enabled = canDisp;
    this.DispArrow(canDisp);
    this.InfoEventScroll.content.SortBasedOnScrollMovement();
    this.InfoEventScroll.content.WrapContent();
    this.InfoEventScroll.ResetPosition();
    this.InfoScroll.ResolvePosition();
  }

  private void CreateInformation(OfficialInformationArticle article)
  {
    GameObject infomationPrefab = this.GetInfomationPrefab(article.category_id);
    GameObject gameObject;
    if (article.category_id == 2)
    {
      gameObject = this.InfoEventScroll.instantiateParts(infomationPrefab, false);
      gameObject.transform.localPosition = new Vector3((float) (640 * this.InfoEventScroll.GetContentChildren().Count<GameObject>()), 0.0f, 0.0f);
    }
    else
    {
      gameObject = Object.Instantiate<GameObject>(infomationPrefab);
      this.InfoScroll.AddColumn1(gameObject, 595, 120);
    }
    Startup000121ScrollParts component = gameObject.GetComponent<Startup000121ScrollParts>();
    component.Set(article, this.NextSceneName);
    component.SetData(article, (NGMenuBase) this);
    this.PartList.Add(component);
  }

  private void DispArrow(bool canDisp)
  {
    this.InfoEventScroll.leftArrow.SetActive(canDisp);
    this.InfoEventScroll.rightArrow.SetActive(canDisp);
    this.InfoEventScroll.ForceArrowDisplay(canDisp);
  }

  private GameObject GetInfomationPrefab(int category_id)
  {
    GameObject infomationPrefab = (GameObject) null;
    switch (category_id)
    {
      case 1:
        infomationPrefab = this.NewsPrefab;
        break;
      case 2:
        infomationPrefab = this.EventPrefab;
        break;
      case 3:
        infomationPrefab = this.FuncPrefab;
        break;
    }
    return infomationPrefab;
  }

  public void CheckNew()
  {
    this.PartList.ForEach((Action<Startup000121ScrollParts>) (x => x.SetNewSprite()));
  }

  protected override void Update()
  {
    base.Update();
    if (!this.autoScrollFlag)
      return;
    this.delay -= Time.deltaTime;
    if ((double) this.delay < 0.0)
    {
      this.count = this.infoEventScroll.selected + 1;
      if (this.count >= this.infoEventScroll.GetContentChildren().Count<GameObject>() || this.count < 0)
        this.count = 0;
      this.infoEventScroll.setItemPosition(this.count);
      this.delay = 5f;
    }
    else
    {
      if (this.count == this.infoEventScroll.selected || this.infoEventScroll.selected <= -1)
        return;
      this.count = this.infoEventScroll.selected < this.infoEventScroll.GetContentChildren().Count<GameObject>() ? this.infoEventScroll.selected : 0;
      this.delay = 3f;
    }
  }

  public virtual void IbtnBack()
  {
    if (this.IsPushAndSet() || Singleton<NGGameDataManager>.GetInstance().InfoOrLoginBonusJump())
      return;
    MypageScene.ChangeScene(false);
  }

  public override void onBackButton() => this.IbtnBack();

  public virtual void IbtnEvent()
  {
  }

  public virtual void IbtnFunctionadd()
  {
  }

  public virtual void IbtnNews()
  {
  }

  public virtual void IbtnNewslist()
  {
  }

  protected virtual void Foreground()
  {
  }

  protected virtual void Foreground2()
  {
  }

  protected virtual void Foreground3()
  {
  }

  protected virtual void IbtnList()
  {
  }

  protected virtual void IbtnNewslist2()
  {
  }

  protected virtual void VScrollBar()
  {
  }

  protected virtual void VScrollBar2()
  {
  }

  protected virtual void VScrollBar3()
  {
  }
}
