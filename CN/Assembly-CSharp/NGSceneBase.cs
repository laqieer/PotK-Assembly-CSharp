// Decompiled with JetBrains decompiler
// Type: NGSceneBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
  public NGSceneBase.GuildChatDisplayingStatus currentSceneGuildChatDisplayingStatus = NGSceneBase.GuildChatDisplayingStatus.Closed;
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
    NGSceneBase.\u003CStart\u003Ec__Iterator165 startCIterator165 = new NGSceneBase.\u003CStart\u003Ec__Iterator165();
    return (IEnumerator) startCIterator165;
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
    DenaLib.Singleton<GameLogic>.Instance.GetWindowStackManager().Show("UI/GamePage", this.sceneName, 0, true, (object[]) null);
  }

  public void TestCsharp2Lua()
  {
    if (this.sceneName == "story001_9_1")
    {
      GameObject gameObject1 = GameObject.Find("ScrollGrid");
      if (Object.op_Implicit((Object) gameObject1))
      {
        GameObject gameObject2 = ((Component) gameObject1.transform.Find("SerialCode")).gameObject;
        if (Object.op_Implicit((Object) gameObject2))
          gameObject2.SetActive(true);
      }
      GameObject gameObject3 = GameObject.Find("ScrollContainer");
      if (!Object.op_Implicit((Object) gameObject3))
        return;
      gameObject3.GetComponent<NGxScroll>().ResolvePosition();
    }
    else if (this.sceneName == "friend008_1")
    {
      GameObject gameObject = GameObject.Find("Friend0081Friend0081Scene UI Root/MainPanel/Top");
      if (!Object.op_Implicit((Object) gameObject))
        return;
      Transform child = gameObject.transform.FindChild("ibtn_InviteFriend__anim_fade01");
      if (!Object.op_Implicit((Object) child) || !Object.op_Implicit((Object) ((Component) child).gameObject))
        return;
      ((Component) child).gameObject.SetActive(true);
    }
    else if (this.sceneName == "friend008_10")
    {
      GameObject gameObject = GameObject.Find("GO_FbInvite");
      if (!Object.op_Implicit((Object) gameObject))
        return;
      Transform child = gameObject.transform.FindChild("slc_Box/txt_Info");
      if (!Object.op_Implicit((Object) child))
        return;
      ((Component) child).gameObject.GetComponent<UILabel>().text = "xxxxsbsb.";
    }
    else
    {
      if (!(this.sceneName == "mypage001_8_1"))
        return;
      GameObject gameObject4 = GameObject.Find("HorizontalLeftArrow");
      if (Object.op_Implicit((Object) gameObject4))
        gameObject4.SetActive(false);
      GameObject gameObject5 = GameObject.Find("IndicatorContainer");
      if (Object.op_Implicit((Object) gameObject5))
      {
        Vector3 vector3;
        // ISSUE: explicit constructor call
        ((Vector3) ref vector3).\u002Ector(gameObject5.transform.localPosition.x, 70f, gameObject5.transform.localPosition.z);
        gameObject5.transform.localPosition = vector3;
      }
      if (!Object.op_Implicit((Object) GameObject.Find("ScrollContainer")))
        ;
      foreach (GameObject gameObject6 in GameObject.FindGameObjectsWithTag("vscroll_732_2"))
      {
        Transform child = gameObject6.transform.FindChild("slc_New");
        if (Object.op_Implicit((Object) child))
        {
          Vector3 vector3;
          // ISSUE: explicit constructor call
          ((Vector3) ref vector3).\u002Ector(60f, child.localPosition.y, child.localPosition.z);
          child.localPosition = vector3;
        }
        Startup000121NewsScrollParts component = gameObject6.GetComponent<Startup000121NewsScrollParts>();
        if (Object.op_Implicit((Object) component))
          component.title.SetText("test zz hot lua!");
      }
    }
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
    NGSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator166 asyncCIterator166 = new NGSceneBase.\u003ConInitSceneAsync\u003Ec__Iterator166();
    return (IEnumerator) asyncCIterator166;
  }

  [DebuggerHidden]
  public virtual IEnumerator onEndSceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator167 asyncCIterator167 = new NGSceneBase.\u003ConEndSceneAsync\u003Ec__Iterator167();
    return (IEnumerator) asyncCIterator167;
  }

  [DebuggerHidden]
  public virtual IEnumerator onDestroySceneAsync()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    NGSceneBase.\u003ConDestroySceneAsync\u003Ec__Iterator168 asyncCIterator168 = new NGSceneBase.\u003ConDestroySceneAsync\u003Ec__Iterator168();
    return (IEnumerator) asyncCIterator168;
  }

  public Coroutine StartCoroutine(IEnumerator e)
  {
    return Singleton<NGSceneManager>.GetInstance().StartCoroutine(e);
  }

  public void SetupGuildChatForNextScene()
  {
    GuildChatManager guildChatManager = Singleton<CommonRoot>.GetInstance().guildChatManager;
    switch (this.currentSceneGuildChatDisplayingStatus)
    {
      case NGSceneBase.GuildChatDisplayingStatus.Opened:
        if (guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.NotOpened)
          guildChatManager.OpenGuildChat();
        else if (guildChatManager.GetGuildChatPaused())
          guildChatManager.ResumeAndShowGuildChat();
        guildChatManager.RefreshMessageItemIcon();
        break;
      case NGSceneBase.GuildChatDisplayingStatus.Paused:
        if (guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.NotOpened)
          break;
        guildChatManager.PauseAndHideGuildChat();
        break;
      case NGSceneBase.GuildChatDisplayingStatus.Closed:
        if (guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.NotOpened)
          break;
        guildChatManager.CloseGuildChat();
        break;
      case NGSceneBase.GuildChatDisplayingStatus.Customized:
        Debug.LogError((object) "The status of guild chat is not initialized!!!");
        break;
    }
  }

  public void SetupGuildChatAfterEndScene()
  {
    GuildChatManager guildChatManager = Singleton<CommonRoot>.GetInstance().guildChatManager;
    if (guildChatManager.GetCurrentGuildChatStatus() == GuildChatManager.GuildChatStatus.DetailedView)
      guildChatManager.CloseDetailedChat();
    Debug.Log((object) "<color=yellow>SetupGuildChatAfterEndScene is invoked!</color>");
  }

  public enum GuildChatDisplayingStatus
  {
    Opened,
    Paused,
    Closed,
    NotChanged,
    Customized,
  }
}
