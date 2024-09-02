// Decompiled with JetBrains decompiler
// Type: BannersProc
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class BannersProc : MonoBehaviour
{
  [SerializeField]
  private NGWrapScrollParts Scroll;
  [SerializeField]
  private TweenAlpha StartAlpha;
  [SerializeField]
  private int margin;
  private List<BannerSetting> BannerButtons = new List<BannerSetting>();
  private int index;
  private int loadIndex;
  private DateTime serverTime;
  private List<Banner> banners;
  private GameObject prefab;
  private bool autoScrollFlag;
  private UIScrollView ScrollView;
  private int indexCount;
  private int count;
  private float delay = 3f;
  private bool isArrowBtn = true;
  private bool prevDragging;
  private bool isScrolling;
  private bool isLoadStarted;

  private void StopEffectAnimeAll()
  {
    foreach (GameObject contentChild in this.Scroll.GetContentChildren())
    {
      if (contentChild.activeInHierarchy)
        contentChild.SendMessage("StopAnime");
    }
  }

  public void IbtnLeftArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    this.isScrolling = true;
    this.StopEffectAnimeAll();
    this.count = this.Scroll.selected - 1;
    if (this.count < 0)
      this.count = this.Scroll.GetContentChildren().Count<GameObject>() - 1;
    this.Scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() =>
    {
      this.isArrowBtn = true;
      this.isScrolling = false;
      this.Scroll.GetContentChild(this.count).SendMessage("StartAnime");
    });
    this.Scroll.setItemPosition(this.count);
    this.delay = (float) this.banners[this.count].duration_seconds;
  }

  public void IbtnRightArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    this.isScrolling = true;
    this.StopEffectAnimeAll();
    this.count = this.Scroll.selected + 1;
    if (this.count >= this.Scroll.GetContentChildren().Count<GameObject>())
      this.count = 0;
    this.Scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() =>
    {
      this.isArrowBtn = true;
      this.isScrolling = false;
      this.Scroll.GetContentChild(this.count).SendMessage("StartAnime");
    });
    this.Scroll.setItemPosition(this.count);
    this.delay = (float) this.banners[this.count].duration_seconds;
  }

  private void Awake()
  {
    this.Scroll.content.itemSize += this.margin;
    this.ScrollView = this.Scroll.scrollView.GetComponent<UIScrollView>();
  }

  private void Update()
  {
    if (!this.autoScrollFlag && !this.isScrolling)
      return;
    this.delay -= Time.deltaTime;
    if (this.prevDragging != this.ScrollView.isDragging)
    {
      if (this.ScrollView.isDragging)
      {
        this.StopEffectAnimeAll();
      }
      else
      {
        this.isArrowBtn = false;
        this.isScrolling = true;
        this.Scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() =>
        {
          this.isArrowBtn = true;
          this.isScrolling = false;
          this.Scroll.GetContentChild(this.Scroll.selected < this.banners.Count<Banner>() ? this.Scroll.selected : 0).SendMessage("StartAnime");
        });
      }
      this.prevDragging = this.ScrollView.isDragging;
    }
    if (this.count != this.Scroll.selected && this.Scroll.selected > -1)
    {
      this.count = this.Scroll.selected < this.banners.Count<Banner>() ? this.Scroll.selected : 0;
      this.delay = (float) this.banners[this.count].duration_seconds;
    }
    else
    {
      if ((double) this.delay >= 0.0)
        return;
      this.count = this.Scroll.selected + 1;
      if (this.count >= this.Scroll.GetContentChildren().Count<GameObject>() || this.count < 0)
        this.count = 0;
      this.isArrowBtn = false;
      this.isScrolling = true;
      this.StopEffectAnimeAll();
      this.Scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() =>
      {
        this.isArrowBtn = true;
        this.isScrolling = false;
        this.Scroll.GetContentChild(this.count).SendMessage("StartAnime");
      });
      this.Scroll.setItemPosition(this.count);
      this.delay = (float) this.banners[this.count].duration_seconds;
    }
  }

  private void CreateBannerList()
  {
    this.indexCount = 0;
    this.autoScrollFlag = false;
    this.banners = new List<Banner>();
    List<Banner> list1 = ((IEnumerable<Banner>) SMManager.Get<Banner[]>()).ToList<Banner>();
    List<Banner> list2 = list1.Where<Banner>((Func<Banner, bool>) (x => x.priority != 0)).OrderBy<Banner, int>((Func<Banner, int>) (y => y.priority)).ToList<Banner>();
    List<Banner> list3 = list1.Where<Banner>((Func<Banner, bool>) (x => x.priority == 0)).ToList<Banner>();
    List<Banner> source = list2;
    source.AddRange((IEnumerable<Banner>) list3);
    try
    {
      this.banners = source.Where<Banner>((Func<Banner, bool>) (x => BannerSetting.judgeTime(x, this.serverTime) && BannerSetting.IsExistSpritePath(x))).ToList<Banner>();
    }
    catch (Exception ex)
    {
      this.banners.Clear();
    }
    UIScrollView component = this.Scroll.scrollView.GetComponent<UIScrollView>();
    if (Object.op_Inequality((Object) component, (Object) null))
      ((Behaviour) component).enabled = false;
    source.Clear();
    list1.Clear();
    list2.Clear();
    list3.Clear();
  }

  [DebuggerHidden]
  private IEnumerator LoadBanner(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannersProc.\u003CLoadBanner\u003Ec__Iterator9D8()
    {
      index = index,
      \u003C\u0024\u003Eindex = index,
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator LoadBannerAll()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannersProc.\u003CLoadBannerAll\u003Ec__Iterator9D9()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator BannerCreate(bool isCloudAnim)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannersProc.\u003CBannerCreate\u003Ec__Iterator9DA()
    {
      isCloudAnim = isCloudAnim,
      \u003C\u0024\u003EisCloudAnim = isCloudAnim,
      \u003C\u003Ef__this = this
    };
  }

  public void StartLoadBannerAll()
  {
    if (this.isLoadStarted)
      return;
    this.isLoadStarted = true;
    this.StartCoroutine(this.LoadBannerAll());
  }

  public void LoopBannerNext()
  {
    this.BannerButtons[this.index].StartTween();
    this.index = this.BannerButtons.Count - 1 > this.index ? this.index + 1 : 0;
  }

  public void StopScroll() => this.autoScrollFlag = false;

  public void StopEffect()
  {
    if (this.BannerButtons == null || this.BannerButtons.Count <= this.count || Object.op_Equality((Object) this.BannerButtons[this.count], (Object) null))
      return;
    this.BannerButtons[this.count].setEmphasisEffectVisibility(false);
  }
}
