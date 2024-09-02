// Decompiled with JetBrains decompiler
// Type: NGSceneBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class NGSceneBase : MonoBehaviour
{
  public string sceneName;
  public bool isTweenFinished;
  [SerializeField]
  protected NGMenuBase menuBase;
  protected NGMenuBase[] menuBases;
  public bool isActiveHeader = true;
  public CommonRoot.HeaderType headerType = CommonRoot.HeaderType.Keep;
  public bool isActiveFooter = true;
  public CommonRoot.FooterType footerType = CommonRoot.FooterType.Keep;
  public bool isActiveBackground = true;
  public bool continueBackground;
  public GameObject backgroundPrefab;
  public float tweenTimeoutTime;
  [SerializeField]
  private bool isUseDLC = true;
  [SerializeField]
  private bool isBackScene = true;
  [SerializeField]
  protected string bgmName = "bgm001";
  [SerializeField]
  protected string bgmFile;
  public float bgmFadeDuration = 3f;
  public bool isDontAutoDestroy;
  protected UITweener[] tweens;
  public bool isAlphaActive;

  public bool IsPush
  {
    set
    {
      if (Object.op_Inequality((Object) this.menuBase, (Object) null))
        this.menuBase.IsPush = value;
      if (this.menuBases == null)
        return;
      for (int index = 0; index < this.menuBases.Length; ++index)
        this.menuBases[index].IsPush = value;
    }
  }

  public bool checkIsUseDLC() => this.isUseDLC;

  public bool IsBackScene => this.isBackScene;

  private void Awake() => Singleton<NGSceneManager>.GetInstance().onChangeSceneAwake(this);

  [DebuggerHidden]
  public virtual IEnumerator Start()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneBase.\u003CStart\u003Ec__Iterator123 startCIterator123 = new NGSceneBase.\u003CStart\u003Ec__Iterator123();
    return (IEnumerator) startCIterator123;
  }

  public void onTweenFinished() => this.isTweenFinished = true;

  public void startTweens()
  {
    if (this.tweens == null)
      this.tweens = NGTween.findTweeners(((Component) this).gameObject, true);
    bool flag1 = NGTween.playTweens(this.tweens, NGTween.Kind.START_END);
    bool isTweensError = NGTween.isTweensError;
    bool flag2 = NGTween.playTweens(this.tweens, NGTween.Kind.START) || flag1;
    if (NGTween.isTweensError || isTweensError)
      this.tweens = (UITweener[]) null;
    this.isTweenFinished = !flag2;
    this.tweenTimeoutTime = 0.3f;
    if (!this.isTweenFinished && this.tweens != null)
    {
      foreach (UITweener tween in this.tweens)
      {
        int num1 = Mathf.Abs(tween.tweenGroup);
        if (tween.style == UITweener.Style.Once && ((Component) tween).gameObject.activeInHierarchy && (num1 == 11 || num1 == 12))
        {
          float num2 = tween.duration + tween.delay;
          if ((double) this.tweenTimeoutTime < (double) num2)
            this.tweenTimeoutTime = num2;
        }
      }
    }
    CommonRoot instance = Singleton<CommonRoot>.GetInstance();
    if (this.isActiveBackground && !this.continueBackground)
      instance.setBackground(this.backgroundPrefab);
    if (this.headerType != CommonRoot.HeaderType.Keep)
      instance.headerType = this.headerType;
    if (this.footerType != CommonRoot.FooterType.Keep)
      instance.footerType = this.footerType;
    instance.isActiveHeader = this.isActiveHeader;
    instance.isActiveFooter = this.isActiveFooter;
    instance.isActiveBackground = this.isActiveBackground;
    this.PlayBGM();
  }

  public void PlayBGM()
  {
    if (this.bgmName == null || !(this.bgmName != string.Empty))
      return;
    NGSoundManager instance = Singleton<NGSoundManager>.GetInstance();
    if (string.IsNullOrEmpty(this.bgmFile))
      instance.playBGMWithCrossFade(this.bgmName, this.bgmFadeDuration);
    else
      instance.PlayBgmFile(this.bgmFile, this.bgmName, fadeInTime: this.bgmFadeDuration, fadeOutTime: this.bgmFadeDuration);
  }

  public void endTweens()
  {
    if (this.tweens == null)
      this.tweens = NGTween.findTweeners(((Component) this).gameObject, true);
    bool flag1 = NGTween.playTweens(this.tweens, NGTween.Kind.START_END, true);
    bool isTweensError = NGTween.isTweensError;
    bool flag2 = NGTween.playTweens(this.tweens, NGTween.Kind.END) || flag1;
    if (NGTween.isTweensError || isTweensError)
      this.tweens = (UITweener[]) null;
    this.isTweenFinished = !flag2;
    this.tweenTimeoutTime = 0.3f;
    if (this.isTweenFinished || this.tweens == null)
      return;
    foreach (UITweener tween in this.tweens)
    {
      int num1 = Mathf.Abs(tween.tweenGroup);
      if (tween.style == UITweener.Style.Once && ((Component) tween).gameObject.activeInHierarchy && (num1 == 11 || num1 == 13))
      {
        float num2 = tween.duration + tween.delay;
        if ((double) this.tweenTimeoutTime < (double) num2)
          this.tweenTimeoutTime = num2;
      }
    }
  }

  public virtual void onSceneInitialized()
  {
  }

  public virtual void onEndScene()
  {
  }

  public virtual List<string> createResourceLoadList() => (List<string>) null;

  [DebuggerHidden]
  public virtual IEnumerator onInitSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator124 asyncCIterator124 = new NGSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator124();
    return (IEnumerator) asyncCIterator124;
  }

  [DebuggerHidden]
  public virtual IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator125 asyncCIterator125 = new NGSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator125();
    return (IEnumerator) asyncCIterator125;
  }

  [DebuggerHidden]
  public virtual IEnumerator onDestroySceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneBase.\u003ConDestroySceneAsync\u003Ec__Iterator126 asyncCIterator126 = new NGSceneBase.\u003ConDestroySceneAsync\u003Ec__Iterator126();
    return (IEnumerator) asyncCIterator126;
  }

  public Coroutine StartCoroutine(IEnumerator e)
  {
    return Singleton<NGSceneManager>.GetInstance().StartCoroutine(e);
  }
}
