// Decompiled with JetBrains decompiler
// Type: GuildChatManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using SM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UniLinq;
using UnityEngine;

#nullable disable
public class GuildChatManager : NGMenuBase
{
  private const float messageUpdateInterval = 5f;
  private const float remainedMessageUpdateInterval = 0.5f;
  private const float messageUpdateRetryInterval = 1f;
  private const int maxSavedDataCount = 1000;
  [SerializeField]
  private GameObject Top;
  [SerializeField]
  private GameObject TopFit;
  [SerializeField]
  private GameObject Middle;
  [SerializeField]
  private GameObject ScrollContainer;
  [SerializeField]
  private GameObject MiniLoad;
  [SerializeField]
  private GameObject Bottom;
  [SerializeField]
  private GameObject BottomFit;
  [SerializeField]
  private GameObject ChatSimple;
  [SerializeField]
  private GameObject DropShadowBlack;
  [SerializeField]
  private GameObject newMessageContainer;
  [SerializeField]
  private GameObject maintenanceBlock;
  [SerializeField]
  private TweenAlpha topFitTweenAlpha;
  [SerializeField]
  private TweenAlpha scrollContainerTweenAlpha;
  [SerializeField]
  private TweenAlpha bottomFitTweenAlpha;
  [SerializeField]
  private TweenAlpha chatSimpleTweenAlpha;
  [SerializeField]
  private TweenPosition topFitTweenPosition;
  [SerializeField]
  private TweenPosition bottomFitTweenPosition;
  [SerializeField]
  private TweenPosition chatSimpleTweenPosition;
  [SerializeField]
  private TweenColor dropShadowBlackTweenColor;
  [SerializeField]
  private UIButton[] messageFilterTypeIdleButtons;
  [SerializeField]
  private UIButton[] messageFilterTypeHighlightButtons;
  [SerializeField]
  private UIButton BBSButton;
  [SerializeField]
  private UIButton sendMessageButton;
  [SerializeField]
  private UIInput chatMessageInput;
  [SerializeField]
  private UILabel chatMessageLabel;
  [SerializeField]
  public GuildChatSimpleListController simpleListController;
  [SerializeField]
  public GuildChatDetailedListController detailedListController;
  private Coroutine updateLatestMessageRepeatingCoroutine;
  private Coroutine updateEarliestMessageCoroutine;
  private Coroutine setDisplayingMessageTypeCoroutine;
  private Coroutine updateLatestMessageNowCoroutine;
  private Coroutine refreshMessageIconCoroutine;
  private bool isUpdatingMessage;
  private bool shouldScrollToBottom;
  private GuildChatManager.GuildChatStatus currentGuildChatStatus = GuildChatManager.GuildChatStatus.NotOpened;
  private bool isGuildChatPaused;
  private GuildChatManager.GuildChatMessageFilterType currentDisplayingMessageFilterType;
  private List<GuildChatMessageData> allMessageDataList = new List<GuildChatMessageData>();
  private List<GuildChatMessageData> displayingMessageList = new List<GuildChatMessageData>();
  private List<GuildChatMessageData> receivedDataList = new List<GuildChatMessageData>();
  public bool isFirstTimeOpeningDetailedView = true;
  private string messageBackup;
  public GameObject simpleMessageItemPrefab;
  public GameObject memberLogItemPrefab;
  public GameObject memberChatItemPrefab;
  public GameObject playerChatItemPrefab;
  public GameObject playerLogItemPrefab;
  public GameObject systemLogItemPrefab;
  public GameObject deletedMessageItemPrefab;
  private static Dictionary<int, GuildChatManager.SpriteCache> spriteCache = new Dictionary<int, GuildChatManager.SpriteCache>();

  public GuildChatManager.GuildChatStatus GetCurrentGuildChatStatus()
  {
    return this.currentGuildChatStatus;
  }

  public bool GetGuildChatPaused() => this.isGuildChatPaused;

  private void Awake() => this.sendMessageButton.isEnabled = false;

  private void Start()
  {
  }

  private void Update()
  {
  }

  [DebuggerHidden]
  private IEnumerator InitializeMessageItemPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CInitializeMessageItemPrefabs\u003Ec__IteratorA46()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnChatOpenButtonClicked() => this.OpenDetailedChat();

  public void OpenDetailedChat()
  {
    if (Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>(), (Object) null) && ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>().IsPushAndSet())
      return;
    if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.SimpleView)
    {
      this.LogGuildChatStatusError();
    }
    else
    {
      this.Top.SetActive(true);
      this.Middle.SetActive(true);
      this.DropShadowBlack.SetActive(true);
      this.BottomFit.SetActive(true);
      this.newMessageContainer.SetActive(true);
      this.PlayGuildChatAnimation(GuildChatManager.GuildChatAnimationType.Simple_To_Detailed, new EventDelegate.Callback(this.OnOpenDetailedChatFinishDelegate));
    }
  }

  private void OnOpenDetailedChatFinishDelegate()
  {
    this.ChatSimple.SetActive(false);
    this.currentGuildChatStatus = GuildChatManager.GuildChatStatus.DetailedView;
    Debug.Log((object) "<color=green>Status is set to DetailedView.</color>");
  }

  public void OnCloseButtonClicked() => this.CloseDetailedChat();

  public void CloseDetailedChat()
  {
    if (Object.op_Inequality((Object) Singleton<NGSceneManager>.GetInstance().sceneBase, (Object) null) && Object.op_Inequality((Object) ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>(), (Object) null))
      ((Component) Singleton<NGSceneManager>.GetInstance().sceneBase).GetComponent<NGMenuBase>().IsPush = false;
    if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.DetailedView)
    {
      this.LogGuildChatStatusError();
    }
    else
    {
      this.newMessageContainer.SetActive(false);
      this.ChatSimple.SetActive(true);
      this.PlayGuildChatAnimation(GuildChatManager.GuildChatAnimationType.Detailed_To_Simple, new EventDelegate.Callback(this.OnCloseDetailedChatFinishDelegate));
    }
  }

  private void OnCloseDetailedChatFinishDelegate()
  {
    this.Top.SetActive(false);
    this.Middle.SetActive(false);
    this.DropShadowBlack.SetActive(false);
    this.BottomFit.SetActive(false);
    this.currentGuildChatStatus = GuildChatManager.GuildChatStatus.SimpleView;
    Debug.Log((object) "<color=green>Status is set to SimpleView.</color>");
  }

  public void OnAllButtonClicked()
  {
    if (this.setDisplayingMessageTypeCoroutine != null)
      return;
    this.setDisplayingMessageTypeCoroutine = this.StartCoroutine(this.SetDisplayingMessageType(GuildChatManager.GuildChatMessageFilterType.All));
  }

  public void OnChatOnlyButtonClicked()
  {
    if (this.setDisplayingMessageTypeCoroutine != null)
      return;
    this.setDisplayingMessageTypeCoroutine = this.StartCoroutine(this.SetDisplayingMessageType(GuildChatManager.GuildChatMessageFilterType.ChatOnly));
  }

  public void OnLogOnlyButtonClicked()
  {
    if (this.setDisplayingMessageTypeCoroutine != null)
      return;
    this.setDisplayingMessageTypeCoroutine = this.StartCoroutine(this.SetDisplayingMessageType(GuildChatManager.GuildChatMessageFilterType.LogOnly));
  }

  public void OnPullDownMessageListFromTop()
  {
    this.updateEarliestMessageCoroutine = this.StartCoroutine(this.UpdateEarlierMessage());
  }

  public void OnBBSTabButtonClicked() => this.OpenBBSViewerDialog();

  public void OpenBBSViewerDialog() => this.StartCoroutine(this.OpenBBSViewerDialogCoroutine());

  [DebuggerHidden]
  public IEnumerator OpenBBSViewerDialogCoroutine()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003COpenBBSViewerDialogCoroutine\u003Ec__IteratorA47()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnInputChatMessageChange()
  {
    this.chatMessageLabel.SetTextLocalize(this.chatMessageInput.value);
    this.sendMessageButton.isEnabled = !this.chatMessageInput.value.isEmptyOrWhitespace();
  }

  public void OnSendMessageButtonClicked() => this.StartCoroutine(this.SendMessage());

  [DebuggerHidden]
  private IEnumerator SendMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CSendMessage\u003Ec__IteratorA48()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SendMessageErrorCallback(WebAPI.Response.UserError error)
  {
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (error.Code == "GLD011")
      this.StartCoroutine(this.OpenNGWordDialog());
    else if (error.Code == "GLD015")
    {
      this.StartMaintenanceMode();
    }
    else
    {
      Singleton<PopupManager>.GetInstance().closeAll();
      WebAPI.DefaultUserErrorCallback(error);
      MypageScene.ChangeScene(false);
    }
  }

  [DebuggerHidden]
  private IEnumerator OpenNGWordDialog()
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    GuildChatManager.\u003COpenNGWordDialog\u003Ec__IteratorA49 dialogCIteratorA49 = new GuildChatManager.\u003COpenNGWordDialog\u003Ec__IteratorA49();
    return (IEnumerator) dialogCIteratorA49;
  }

  [DebuggerHidden]
  private IEnumerator UpdateLatestMessageRepeating()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CUpdateLatestMessageRepeating\u003Ec__IteratorA4A()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateLatestMessageNow()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CUpdateLatestMessageNow\u003Ec__IteratorA4B()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateEarlierMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CUpdateEarlierMessage\u003Ec__IteratorA4C()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OpenGuildChat()
  {
    if (!PlayerAffiliation.Current.isGuildMember())
      return;
    if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.NotOpened)
    {
      this.LogGuildChatStatusError();
    }
    else
    {
      this.currentGuildChatStatus = GuildChatManager.GuildChatStatus.SimpleView;
      this.StartCoroutine(this.OpenGuildChatCoroutine());
    }
  }

  [DebuggerHidden]
  private IEnumerator OpenGuildChatCoroutine()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003COpenGuildChatCoroutine\u003Ec__IteratorA4D()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void RecoverFromConnectionError(WebError error)
  {
    if (this.currentGuildChatStatus == GuildChatManager.GuildChatStatus.NotOpened || this.isGuildChatPaused)
      return;
    this.isUpdatingMessage = false;
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (error.Request.Path.Contains("/guildlog/autoupdate"))
    {
      Debug.Log((object) "<color=yellow>Recover autoupdate.</color>");
      if (this.updateLatestMessageRepeatingCoroutine == null)
        return;
      this.StopCoroutine(this.updateLatestMessageRepeatingCoroutine);
      this.updateLatestMessageRepeatingCoroutine = this.StartCoroutine(this.UpdateLatestMessageRepeating());
    }
    else
    {
      if (!error.Request.Path.Contains("/guildlog/write"))
        return;
      Debug.Log((object) "<color=yellow>Recover sending message.</color>");
      if (this.messageBackup == null)
        return;
      this.chatMessageLabel.SetTextLocalize(this.messageBackup);
      this.chatMessageInput.value = this.chatMessageLabel.text;
    }
  }

  public void CloseAllGuildPopupDialogs()
  {
    if (this.currentGuildChatStatus == GuildChatManager.GuildChatStatus.NotOpened || this.isGuildChatPaused)
      return;
    Singleton<PopupManager>.GetInstance().closeAll();
  }

  private void InitializeGuildChatAnimations()
  {
    this.topFitTweenAlpha.tweenFactor = 0.0f;
    this.scrollContainerTweenAlpha.tweenFactor = 0.0f;
    this.bottomFitTweenAlpha.tweenFactor = 0.0f;
    this.topFitTweenPosition.tweenFactor = 0.0f;
    this.bottomFitTweenPosition.tweenFactor = 0.0f;
    this.dropShadowBlackTweenColor.tweenFactor = 0.0f;
  }

  public void CloseGuildChat()
  {
    if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.SimpleView && this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.DetailedView)
    {
      this.LogGuildChatStatusError();
    }
    else
    {
      this.currentGuildChatStatus = GuildChatManager.GuildChatStatus.NotOpened;
      this.isGuildChatPaused = false;
      ((Component) this).gameObject.SetActive(false);
      this.isFirstTimeOpeningDetailedView = true;
      this.StopAllGuildChatCoroutines();
      this.isUpdatingMessage = false;
      this.simpleListController.ResetMessageItemList();
      this.allMessageDataList.Clear();
      this.displayingMessageList.Clear();
      this.receivedDataList.Clear();
    }
  }

  private void StopAllGuildChatCoroutines()
  {
    if (this.updateLatestMessageRepeatingCoroutine != null)
      this.StopCoroutine(this.updateLatestMessageRepeatingCoroutine);
    if (this.updateEarliestMessageCoroutine != null)
      this.StopCoroutine(this.updateEarliestMessageCoroutine);
    if (this.setDisplayingMessageTypeCoroutine != null)
      this.StopCoroutine(this.setDisplayingMessageTypeCoroutine);
    if (this.updateLatestMessageNowCoroutine != null)
      this.StopCoroutine(this.updateLatestMessageNowCoroutine);
    if (this.refreshMessageIconCoroutine != null)
      this.StopCoroutine(this.refreshMessageIconCoroutine);
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
  }

  public void PauseAndHideGuildChat()
  {
    if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.SimpleView && this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.DetailedView)
    {
      this.LogGuildChatStatusError();
    }
    else
    {
      if (this.isGuildChatPaused)
        return;
      this.isGuildChatPaused = true;
      this.StartCoroutine(this.PauseAndHideCoroutine());
    }
  }

  [DebuggerHidden]
  private IEnumerator PauseAndHideCoroutine()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CPauseAndHideCoroutine\u003Ec__IteratorA4E()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void ResumeAndShowGuildChat()
  {
    if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.SimpleView && this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.DetailedView)
    {
      this.LogGuildChatStatusError();
    }
    else
    {
      if (!this.isGuildChatPaused)
        return;
      this.isGuildChatPaused = false;
      ((Component) this).gameObject.SetActive(true);
      this.updateLatestMessageRepeatingCoroutine = this.StartCoroutine(this.UpdateLatestMessageRepeating());
    }
  }

  [DebuggerHidden]
  private IEnumerator SetDisplayingMessageType(
    GuildChatManager.GuildChatMessageFilterType filterType)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CSetDisplayingMessageType\u003Ec__IteratorA4F()
    {
      filterType = filterType,
      \u003C\u0024\u003EfilterType = filterType,
      \u003C\u003Ef__this = this
    };
  }

  private void UpdateDisplayingMessageDataList(
    GuildChatManager.GuildChatMessageFilterType filterType)
  {
    switch (filterType)
    {
      case GuildChatManager.GuildChatMessageFilterType.All:
        this.displayingMessageList = this.allMessageDataList.Select<GuildChatMessageData, GuildChatMessageData>((Func<GuildChatMessageData, GuildChatMessageData>) (data => data)).ToList<GuildChatMessageData>();
        break;
      case GuildChatManager.GuildChatMessageFilterType.ChatOnly:
        this.displayingMessageList = this.allMessageDataList.Where<GuildChatMessageData>((Func<GuildChatMessageData, bool>) (data => data.messageType == GuildChatMessageData.GuildChatMessageType.MemberChat || data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerChat)).ToList<GuildChatMessageData>();
        break;
      case GuildChatManager.GuildChatMessageFilterType.LogOnly:
        this.displayingMessageList = this.allMessageDataList.Where<GuildChatMessageData>((Func<GuildChatMessageData, bool>) (data => data.messageType == GuildChatMessageData.GuildChatMessageType.MemberLog || data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerLog || data.messageType == GuildChatMessageData.GuildChatMessageType.SystemLog)).ToList<GuildChatMessageData>();
        break;
    }
  }

  private int GetMessageDataCount(
    GuildChatManager.GuildChatMessageFilterType filterType,
    List<GuildChatMessageData> dataList)
  {
    int messageDataCount = 0;
    switch (filterType)
    {
      case GuildChatManager.GuildChatMessageFilterType.All:
        messageDataCount = dataList.Count;
        break;
      case GuildChatManager.GuildChatMessageFilterType.ChatOnly:
        for (int index = 0; index < dataList.Count; ++index)
        {
          if (dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.MemberChat || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.PlayerChat)
            ++messageDataCount;
        }
        break;
      case GuildChatManager.GuildChatMessageFilterType.LogOnly:
        for (int index = 0; index < dataList.Count; ++index)
        {
          if (dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.MemberLog || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.PlayerLog || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.SystemLog)
            ++messageDataCount;
        }
        break;
    }
    return messageDataCount;
  }

  private void AdjustDetailedMessageItemListPlaceholder(
    bool shouldReset = false,
    bool shouldScrollToBottom = false,
    int addedNewDataCount = 0,
    int addedOldDataCount = 0,
    int deletedOldDataCount = 0)
  {
    this.detailedListController.SetDisplayingMessageDataList(this.displayingMessageList);
    if (shouldReset)
      this.detailedListController.ResetPlaceholderPosition();
    else
      this.detailedListController.AdjustPlaceholderPosition(addedNewDataCount, addedOldDataCount, deletedOldDataCount, shouldScrollToBottom);
    if (addedNewDataCount <= 0 && addedOldDataCount - deletedOldDataCount <= 0)
      return;
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_2500");
  }

  private void UpdateSimpleMessageItemList()
  {
    this.EndMaintenanceMode();
    List<GuildChatMessageData> dataList = new List<GuildChatMessageData>();
    int index1 = this.receivedDataList.Count - 1;
    for (int index2 = 1; index1 >= 0 && index2 <= 3; ++index2)
    {
      if (!this.receivedDataList[index1].isDeleted)
        dataList.Add(this.receivedDataList[index1]);
      --index1;
    }
    dataList.Reverse();
    this.simpleListController.AddSimpleMessageItems(dataList);
  }

  private void SetTabButtons(
    GuildChatManager.GuildChatMessageFilterType filterType)
  {
    for (int index = 0; index < this.messageFilterTypeIdleButtons.Length; ++index)
    {
      if (filterType == (GuildChatManager.GuildChatMessageFilterType) index)
        ((Component) this.messageFilterTypeIdleButtons[index]).gameObject.SetActive(false);
      else
        ((Component) this.messageFilterTypeIdleButtons[index]).gameObject.SetActive(true);
    }
    for (int index = 0; index < this.messageFilterTypeHighlightButtons.Length; ++index)
    {
      if (filterType == (GuildChatManager.GuildChatMessageFilterType) index)
        ((Component) this.messageFilterTypeHighlightButtons[index]).gameObject.SetActive(true);
      else
        ((Component) this.messageFilterTypeHighlightButtons[index]).gameObject.SetActive(false);
    }
  }

  public void StartMaintenanceMode()
  {
    if (this.currentGuildChatStatus == GuildChatManager.GuildChatStatus.DetailedView)
      this.CloseDetailedChat();
    this.maintenanceBlock.SetActive(true);
    ((Component) this.simpleListController).gameObject.SetActive(false);
  }

  public void EndMaintenanceMode()
  {
    this.maintenanceBlock.SetActive(false);
    ((Component) this.simpleListController).gameObject.SetActive(true);
  }

  public void SetSprite(UI2DSprite sprite, int spriteID)
  {
    if (spriteID != 0)
    {
      GuildChatManager.SpriteCache spriteCache;
      if (GuildChatManager.spriteCache.TryGetValue(spriteID, out spriteCache))
        sprite.sprite2D = spriteCache.unitIconSprite;
      else
        this.StartCoroutine(this.SetSpriteFromResourceSchedule(sprite, spriteID));
    }
    else
      sprite.sprite2D = (Sprite) null;
  }

  [DebuggerHidden]
  private IEnumerator SetSpriteFromResourceSchedule(UI2DSprite sprite, int spriteID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CSetSpriteFromResourceSchedule\u003Ec__IteratorA50()
    {
      spriteID = spriteID,
      sprite = sprite,
      \u003C\u0024\u003EspriteID = spriteID,
      \u003C\u0024\u003Esprite = sprite
    };
  }

  public void RefreshMessageItemIcon()
  {
    if (this.refreshMessageIconCoroutine != null || !PlayerAffiliation.Current.isGuildMember())
      return;
    this.refreshMessageIconCoroutine = this.StartCoroutine(this.RefreshUserIconCoroutine());
  }

  [DebuggerHidden]
  private IEnumerator RefreshUserIconCoroutine()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CRefreshUserIconCoroutine\u003Ec__IteratorA51()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void PlayGuildChatAnimation(
    GuildChatManager.GuildChatAnimationType animationType,
    EventDelegate.Callback finishCallback)
  {
    List<UITweener> uiTweenerList = new List<UITweener>();
    UITweener[] componentsInChildren = ((Component) this).gameObject.GetComponentsInChildren<UITweener>();
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      if ((GuildChatManager.GuildChatAnimationType) componentsInChildren[index].tweenGroup == animationType || componentsInChildren[index].tweenGroup == 21)
        uiTweenerList.Add(componentsInChildren[index]);
    }
    UITweener uiTweener = uiTweenerList[0];
    for (int index = 1; index < uiTweenerList.Count; ++index)
    {
      uiTweenerList[index].onFinished.Clear();
      if ((double) uiTweener.duration + (double) uiTweener.delay < (double) uiTweenerList[index].duration + (double) uiTweenerList[index].delay)
        uiTweener = uiTweenerList[index];
    }
    uiTweener.SetOnFinished(finishCallback);
    switch (animationType)
    {
      case GuildChatManager.GuildChatAnimationType.Simple_To_Detailed:
        using (List<UITweener>.Enumerator enumerator = uiTweenerList.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            UITweener current = enumerator.Current;
            current.tweenFactor = 0.0f;
            current.PlayForward();
          }
          break;
        }
      case GuildChatManager.GuildChatAnimationType.Detailed_To_Simple:
        using (List<UITweener>.Enumerator enumerator = uiTweenerList.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            UITweener current = enumerator.Current;
            if (current.tweenGroup == 21)
            {
              current.tweenFactor = 1f;
              current.PlayReverse();
            }
            else
            {
              current.tweenFactor = 0.0f;
              current.PlayForward();
            }
          }
          break;
        }
    }
  }

  public void OpenMemberLogDialog(string playerID)
  {
    this.StartCoroutine(this.OpenMemberLogCoroutine(playerID));
  }

  [DebuggerHidden]
  private IEnumerator OpenMemberLogCoroutine(string playerID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003COpenMemberLogCoroutine\u003Ec__IteratorA52()
    {
      playerID = playerID,
      \u003C\u0024\u003EplayerID = playerID
    };
  }

  private void LogGuildChatStatusError()
  {
    Debug.Log((object) ("<color=red>Status not right: " + this.currentGuildChatStatus.ToString() + "</color>"));
  }

  public enum GuildChatStatus
  {
    NotOpened = 1,
    SimpleView = 2,
    DetailedView = 3,
  }

  private enum GuildChatMessageFilterType
  {
    All,
    ChatOnly,
    LogOnly,
  }

  public class SpriteCache
  {
    public Sprite unitIconSprite;

    public SpriteCache(Sprite sprite) => this.unitIconSprite = sprite;
  }

  public enum GuildChatAnimationType
  {
    Both = 21, // 0x00000015
    Simple_To_Detailed = 22, // 0x00000016
    Detailed_To_Simple = 23, // 0x00000017
  }
}
