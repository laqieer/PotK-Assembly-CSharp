// Decompiled with JetBrains decompiler
// Type: BannersProc
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
public class BannersProc : MonoBehaviour
{
  [SerializeField]
  private NGWrapScrollParts Scroll;
  [SerializeField]
  private TweenAlpha StartAlpha;
  [SerializeField]
  private int margin;
  private List<BannerSetting> BannerButtons;
  private int index;
  private int loadIndex;
  private DateTime serverTime;
  private List<SM.Banner> banners;
  private GameObject prefab;
  private bool autoScrollFlag;
  private int indexCount;
  private int count;
  private float delay = 3f;
  private bool isArrowBtn = true;
  private bool isLoadStarted;

  public void IbtnLeftArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    this.count = this.Scroll.selected - 1;
    if (this.count < 0)
      this.count = this.Scroll.GetContentChildren().Count<GameObject>() - 1;
    this.Scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() => this.isArrowBtn = true);
    this.Scroll.centerOnChild.CenterOn(this.Scroll.GetContentChild(this.count).transform);
    this.delay = (float) this.banners[this.count].duration_seconds;
  }

  public void IbtnRightArrow()
  {
    if (!this.isArrowBtn)
      return;
    this.isArrowBtn = false;
    this.count = this.Scroll.selected + 1;
    if (this.count >= this.Scroll.GetContentChildren().Count<GameObject>())
      this.count = 0;
    this.Scroll.centerOnChild.onFinished = (SpringPanel.OnFinished) (() => this.isArrowBtn = true);
    this.Scroll.centerOnChild.CenterOn(this.Scroll.GetContentChild(this.count).transform);
    this.delay = (float) this.banners[this.count].duration_seconds;
  }

  private void Awake() => this.Scroll.content.itemSize += this.margin;

  private void Update()
  {
    if (!this.autoScrollFlag)
      return;
    this.delay -= Time.deltaTime;
    if ((double) this.delay < 0.0)
    {
      this.count = this.Scroll.selected + 1;
      if (this.count >= this.Scroll.GetContentChildren().Count<GameObject>() || this.count < 0)
        this.count = 0;
      this.Scroll.setItemPosition(this.count);
      this.delay = (float) this.banners[this.count].duration_seconds;
    }
    else
    {
      if (this.count == this.Scroll.selected || this.Scroll.selected <= -1)
        return;
      this.count = this.Scroll.selected < this.banners.Count<SM.Banner>() ? this.Scroll.selected : 0;
      this.delay = (float) this.banners[this.count].duration_seconds;
    }
  }

  private void CreateBannerList()
  {
    this.indexCount = 0;
    this.autoScrollFlag = false;
    this.banners = new List<SM.Banner>();
    List<SM.Banner> list1 = ((IEnumerable<SM.Banner>) SMManager.Get<SM.Banner[]>()).ToList<SM.Banner>();
    List<SM.Banner> list2 = list1.Where<SM.Banner>((Func<SM.Banner, bool>) (x => x.priority != 0)).OrderBy<SM.Banner, int>((Func<SM.Banner, int>) (y => y.priority)).ToList<SM.Banner>();
    List<SM.Banner> list3 = list1.Where<SM.Banner>((Func<SM.Banner, bool>) (x => x.priority == 0)).ToList<SM.Banner>();
    List<SM.Banner> source1 = list2;
    source1.AddRange((IEnumerable<SM.Banner>) list3);
    List<SM.Banner> list4 = source1.Where<SM.Banner>((Func<SM.Banner, bool>) (x => BannerSetting.judgeTime(x, this.serverTime) && BannerSetting.IsExistSpritePath(x))).ToList<SM.Banner>();
    PlayerExtraQuestS[] source2 = SMManager.Get<PlayerExtraQuestS[]>();
    foreach (SM.Banner banner in list4)
    {
      if (banner.transition.arg4 == 1)
      {
        bool flag = false;
        try
        {
          flag = ((IEnumerable<PlayerExtraQuestS>) source2).Select<PlayerExtraQuestS, int>((Func<PlayerExtraQuestS, int>) (x => x.quest_extra_s.ID)).Contains<int>(banner.transition.arg1);
        }
        catch
        {
          Debug.LogError((object) string.Format("SM.PlayerQuestExtra is not set"));
        }
        if (banner.transition.arg1 != 0 && !flag)
          continue;
      }
      this.banners.Add(banner);
    }
    UIScrollView component = this.Scroll.scrollView.GetComponent<UIScrollView>();
    if (Object.op_Inequality((Object) component, (Object) null))
      ((Behaviour) component).enabled = false;
    list4.Clear();
    list1.Clear();
    list2.Clear();
    list3.Clear();
  }

  [DebuggerHidden]
  private IEnumerator LoadBanner(int index)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannersProc.\u003CLoadBanner\u003Ec__Iterator7A0()
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
    return (IEnumerator) new BannersProc.\u003CLoadBannerAll\u003Ec__Iterator7A1()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  public IEnumerator BannerCreate(bool isCloudAnim)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new BannersProc.\u003CBannerCreate\u003Ec__Iterator7A2()
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
}
