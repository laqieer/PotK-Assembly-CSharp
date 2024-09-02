// Decompiled with JetBrains decompiler
// Type: GuildChatManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using GameCore;
using MasterDataTable;
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
  private const string GUILD_CHAT_STAMP_ATLAS_PATH = "GUI/chat_stamp_group{0}/chat_stamp_group{1}_prefab";
  private const string GUILD_CHAT_STAMP_SPRITE_NAME = "slc_stamp_id_{0}.png__GUI__chat_stamp_group{1}__chat_stamp_group{2}_prefab";
  private const string GUILD_CHAT_STAMP_DEFAULT_WHITE_SPRITE_NAME = "slc_white.png__GUI__common__common_prefab";
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
  private TweenPosition topFitTweenPosition;
  [SerializeField]
  private TweenPosition bottomFitTweenPosition;
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
  private UIButton stampOpenButton;
  [SerializeField]
  private UIInput chatMessageInput;
  [SerializeField]
  private UILabel chatMessageLabel;
  [SerializeField]
  public GuildChatSimpleListController simpleListController;
  [SerializeField]
  public GuildChatDetailedListController detailedListController;
  [SerializeField]
  public GuildChatStampSelectViewController stampSelectViewController;
  private readonly float[] messageUpdateIntervals = new float[2]
  {
    15f,
    30f
  };
  private GuildChatManager.IntervalStateMode IntervalState;
  private Coroutine updateLatestMessageRepeatingCoroutine;
  private Coroutine updateEarliestMessageCoroutine;
  private Coroutine setDisplayingMessageTypeCoroutine;
  private Coroutine updateLatestMessageNowCoroutine;
  private Coroutine refreshMessageIconCoroutine;
  private bool isUpdatingMessage;
  private bool isReceivedMessage;
  private bool shouldScrollToBottom;
  private GuildChatManager.GuildChatStatus currentGuildChatStatus = GuildChatManager.GuildChatStatus.NotOpened;
  private bool isGuildChatPaused;
  private GuildChatManager.GuildChatMessageFilterType currentDisplayingMessageFilterType;
  private List<GuildChatMessageData> allMessageDataList = new List<GuildChatMessageData>();
  private List<GuildChatMessageData> displayingMessageList = new List<GuildChatMessageData>();
  public bool isFirstTimeOpeningDetailedView = true;
  private string messageBackup;
  [HideInInspector]
  public GameObject simpleMessageItemPrefab;
  [HideInInspector]
  public GameObject memberLogItemPrefab;
  [HideInInspector]
  public GameObject memberChatItemPrefab;
  [HideInInspector]
  public GameObject playerChatItemPrefab;
  [HideInInspector]
  public GameObject playerLogItemPrefab;
  [HideInInspector]
  public GameObject systemLogItemPrefab;
  [HideInInspector]
  public GameObject deletedMessageItemPrefab;
  [HideInInspector]
  public GameObject memberStampItemPrefab;
  [HideInInspector]
  public GameObject playerStampItemPrefab;
  [HideInInspector]
  public GameObject stampSelectItemPrefab;
  [HideInInspector]
  public GameObject stampGroupSelectItemPrefab;
  [SerializeField]
  private UIAtlas commonAtlas;
  private static Dictionary<int, GuildChatManager.SpriteCache> spriteCache = new Dictionary<int, GuildChatManager.SpriteCache>();
  private static Dictionary<int, UIAtlas> stampAtlasCache = new Dictionary<int, UIAtlas>();

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
    return (IEnumerator) new GuildChatManager.\u003CInitializeMessageItemPrefabs\u003Ec__IteratorB21()
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
      this.stampSelectViewController.CloseStampSelectView();
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
    return (IEnumerator) new GuildChatManager.\u003COpenBBSViewerDialogCoroutine\u003Ec__IteratorB22()
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

  public void OnStampSelectButtonClicked() => this.stampSelectViewController.OpenStampSelectView();

  public void OnBackButtonClicked()
  {
    if (this.stampSelectViewController.isStampSelectViewOpened)
    {
      this.stampSelectViewController.CloseStampSelectView();
    }
    else
    {
      if (this.currentGuildChatStatus != GuildChatManager.GuildChatStatus.DetailedView)
        return;
      this.CloseDetailedChat();
    }
  }

  [DebuggerHidden]
  private IEnumerator SendMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CSendMessage\u003Ec__IteratorB23()
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
    GuildChatManager.\u003COpenNGWordDialog\u003Ec__IteratorB24 dialogCIteratorB24 = new GuildChatManager.\u003COpenNGWordDialog\u003Ec__IteratorB24();
    return (IEnumerator) dialogCIteratorB24;
  }

  public void SendStamp(int stampID) => this.StartCoroutine(this.SendStampCoroutine(stampID));

  [DebuggerHidden]
  private IEnumerator SendStampCoroutine(int stampID)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CSendStampCoroutine\u003Ec__IteratorB25()
    {
      stampID = stampID,
      \u003C\u0024\u003EstampID = stampID,
      \u003C\u003Ef__this = this
    };
  }

  private void SendStampErrorCallback(WebAPI.Response.UserError error)
  {
    Singleton<CommonRoot>.GetInstance().loadingMode = 0;
    if (error.Code == "GLD015")
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
  private IEnumerator UpdateLatestMessageRepeating()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CUpdateLatestMessageRepeating\u003Ec__IteratorB26()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator WaitForUpdateInterval(GuildChatManager.IntervalStateMode state)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CWaitForUpdateInterval\u003Ec__IteratorB27()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void SetIntervalState(bool isUpdate)
  {
    if (isUpdate)
      this.IntervalState = GuildChatManager.IntervalStateMode.IntervalFirst;
    else
      this.IntervalState = GuildChatManager.IntervalStateMode.IntervalSecond;
  }

  [DebuggerHidden]
  private IEnumerator UpdateLatestMessageNow()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CUpdateLatestMessageNow\u003Ec__IteratorB28()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateEarlierMessage()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CUpdateEarlierMessage\u003Ec__IteratorB29()
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
    return (IEnumerator) new GuildChatManager.\u003COpenGuildChatCoroutine\u003Ec__IteratorB2A()
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
      this.stampSelectViewController.isFirstTimeOpeningStampSelectView = true;
      this.StopAllGuildChatCoroutines();
      this.isUpdatingMessage = false;
      if (Object.op_Inequality((Object) this.simpleListController, (Object) null))
        this.simpleListController.ClearMessageItemList();
      this.allMessageDataList.Clear();
      this.displayingMessageList.Clear();
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
    return (IEnumerator) new GuildChatManager.\u003CPauseAndHideCoroutine\u003Ec__IteratorB2B()
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
    return (IEnumerator) new GuildChatManager.\u003CSetDisplayingMessageType\u003Ec__IteratorB2C()
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
        this.displayingMessageList = this.allMessageDataList.Where<GuildChatMessageData>((Func<GuildChatMessageData, bool>) (data => data.messageType == GuildChatMessageData.GuildChatMessageType.MemberChat || data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerChat || data.messageType == GuildChatMessageData.GuildChatMessageType.MemberStamp || data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerStamp)).ToList<GuildChatMessageData>();
        break;
      case GuildChatManager.GuildChatMessageFilterType.LogOnly:
        this.displayingMessageList = this.allMessageDataList.Where<GuildChatMessageData>((Func<GuildChatMessageData, bool>) (data => data.messageType == GuildChatMessageData.GuildChatMessageType.MemberLog || data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerLog || data.messageType == GuildChatMessageData.GuildChatMessageType.SystemLog)).ToList<GuildChatMessageData>();
        break;
    }
  }

  private List<GuildChatMessageData> GetFilteredDataList(
    GuildChatManager.GuildChatMessageFilterType filterType,
    List<GuildChatMessageData> dataList)
  {
    List<GuildChatMessageData> filteredDataList = new List<GuildChatMessageData>();
    if (dataList != null)
    {
      switch (filterType)
      {
        case GuildChatManager.GuildChatMessageFilterType.All:
          filteredDataList = dataList;
          break;
        case GuildChatManager.GuildChatMessageFilterType.ChatOnly:
          for (int index = 0; index < dataList.Count; ++index)
          {
            if (dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.MemberChat || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.PlayerChat || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.MemberStamp || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.PlayerStamp)
              filteredDataList.Add(dataList[index]);
          }
          break;
        case GuildChatManager.GuildChatMessageFilterType.LogOnly:
          for (int index = 0; index < dataList.Count; ++index)
          {
            if (dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.MemberLog || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.PlayerLog || dataList[index].messageType == GuildChatMessageData.GuildChatMessageType.SystemLog)
              filteredDataList.Add(dataList[index]);
          }
          break;
      }
    }
    return filteredDataList;
  }

  private void AdjustDetailedMessageItemListPlaceholder(
    bool shouldScrollToBottom = false,
    List<GuildChatMessageData> addedNewDataList = null,
    List<GuildChatMessageData> addedOldDataList = null,
    List<GuildChatMessageData> deletedOldDataList = null)
  {
    this.detailedListController.SetDisplayingMessageDataList(this.displayingMessageList);
    this.detailedListController.AdjustPlaceholderPosition(this.GetFilteredDataList(this.currentDisplayingMessageFilterType, addedNewDataList), this.GetFilteredDataList(this.currentDisplayingMessageFilterType, addedOldDataList), this.GetFilteredDataList(this.currentDisplayingMessageFilterType, deletedOldDataList), shouldScrollToBottom);
    int count1 = addedNewDataList != null ? addedNewDataList.Count : 0;
    int count2 = addedOldDataList != null ? addedOldDataList.Count : 0;
    int count3 = deletedOldDataList != null ? deletedOldDataList.Count : 0;
    if (count1 <= 0 && count2 - count3 <= 0)
      return;
    this.isReceivedMessage = true;
    Singleton<NGSoundManager>.GetInstance().PlaySe("SE_2500");
  }

  private void ResetDetailedMessageItemListPlaceholder()
  {
    this.detailedListController.SetDisplayingMessageDataList(this.displayingMessageList);
    this.detailedListController.ResetPlaceholderPosition();
  }

  private void UpdateSimpleMessageItemList(List<GuildChatMessageData> receivedDataList)
  {
    this.EndMaintenanceMode();
    List<GuildChatMessageData> dataList = new List<GuildChatMessageData>();
    int index1 = receivedDataList.Count - 1;
    for (int index2 = 1; index1 >= 0 && index2 <= 3; ++index2)
    {
      if (!receivedDataList[index1].isDeleted)
        dataList.Add(receivedDataList[index1]);
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
    return (IEnumerator) new GuildChatManager.\u003CSetSpriteFromResourceSchedule\u003Ec__IteratorB2D()
    {
      spriteID = spriteID,
      sprite = sprite,
      \u003C\u0024\u003EspriteID = spriteID,
      \u003C\u0024\u003Esprite = sprite
    };
  }

  public void SetStampSprite(UISprite targetSprite, int stampID)
  {
    Debug.Log((object) ("<color=yellow>SetStampSprite is invoked. StampID: </color>" + (object) stampID));
    GuildStamp guildStamp = ((IEnumerable<GuildStamp>) MasterData.GuildStampList).FirstOrDefault<GuildStamp>((Func<GuildStamp, bool>) (x => x.ID == stampID));
    if (guildStamp != null)
    {
      Debug.Log((object) ("<color=green>Stamp exists! StampID: </color>" + (object) stampID));
      UIAtlas uiAtlas = (UIAtlas) null;
      if (GuildChatManager.stampAtlasCache.TryGetValue(guildStamp.groupID.ID, out uiAtlas))
      {
        targetSprite.atlas = uiAtlas;
        string str1 = guildStamp.groupID.ID.ToString("000");
        string str2 = string.Format("slc_stamp_id_{0}.png__GUI__chat_stamp_group{1}__chat_stamp_group{2}_prefab", (object) stampID.ToString("00"), (object) str1, (object) str1);
        targetSprite.spriteName = str2;
        UIButton component = ((Component) targetSprite).GetComponent<UIButton>();
        if (Object.op_Inequality((Object) component, (Object) null))
          component.normalSprite = str2;
        Debug.Log((object) ("<color=green>Set stamp with cache! StampID: </color>" + (object) stampID));
      }
      else
        this.StartCoroutine(this.SetStampSpriteFromResourceCoroutine(guildStamp.groupID.ID, stampID, targetSprite));
    }
    else
    {
      Debug.Log((object) ("<color=red>Stamp does not exist!</color> StampID: " + (object) stampID));
      targetSprite.atlas = this.commonAtlas;
      string str = "slc_white.png__GUI__common__common_prefab";
      targetSprite.spriteName = str;
      UIButton component = ((Component) targetSprite).GetComponent<UIButton>();
      if (!Object.op_Inequality((Object) component, (Object) null))
        return;
      component.normalSprite = str;
    }
  }

  [DebuggerHidden]
  private IEnumerator SetStampSpriteFromResourceCoroutine(
    int stampGroupID,
    int stampID,
    UISprite targetSprite)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatManager.\u003CSetStampSpriteFromResourceCoroutine\u003Ec__IteratorB2E()
    {
      stampID = stampID,
      stampGroupID = stampGroupID,
      targetSprite = targetSprite,
      \u003C\u0024\u003EstampID = stampID,
      \u003C\u0024\u003EstampGroupID = stampGroupID,
      \u003C\u0024\u003EtargetSprite = targetSprite
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
    return (IEnumerator) new GuildChatManager.\u003CRefreshUserIconCoroutine\u003Ec__IteratorB2F()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void PlayGuildChatAnimation(
    GuildChatManager.GuildChatAnimationType animationType,
    EventDelegate.Callback finishCallback)
  {
    List<UITweener> uiTweenerList = new List<UITweener>();
    UITweener[] componentsInChildren = ((Component) this).gameObject.GetComponentsInChildren<UITweener>();
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      switch (animationType)
      {
        case GuildChatManager.GuildChatAnimationType.Simple_To_Detailed:
        case GuildChatManager.GuildChatAnimationType.Detailed_To_Simple:
          if ((GuildChatManager.GuildChatAnimationType) componentsInChildren[index].tweenGroup == animationType || componentsInChildren[index].tweenGroup == 21)
          {
            uiTweenerList.Add(componentsInChildren[index]);
            break;
          }
          break;
        case GuildChatManager.GuildChatAnimationType.Open_Stamp_Panel:
        case GuildChatManager.GuildChatAnimationType.Close_Stamp_Panel:
          if ((GuildChatManager.GuildChatAnimationType) componentsInChildren[index].tweenGroup == animationType || componentsInChildren[index].tweenGroup == 31)
          {
            uiTweenerList.Add(componentsInChildren[index]);
            break;
          }
          break;
      }
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
      case GuildChatManager.GuildChatAnimationType.Open_Stamp_Panel:
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
      case GuildChatManager.GuildChatAnimationType.Close_Stamp_Panel:
        using (List<UITweener>.Enumerator enumerator = uiTweenerList.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            UITweener current = enumerator.Current;
            if (current.tweenGroup == 31)
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
    return (IEnumerator) new GuildChatManager.\u003COpenMemberLogCoroutine\u003Ec__IteratorB30()
    {
      playerID = playerID,
      \u003C\u0024\u003EplayerID = playerID
    };
  }

  private void LogGuildChatStatusError()
  {
    Debug.Log((object) ("<color=red>Status not right: " + this.currentGuildChatStatus.ToString() + "</color>"));
  }

  private enum IntervalStateMode
  {
    IntervalFirst,
    IntervalSecond,
    MAX,
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
    Both_From_Simple_And_Detailed = 21, // 0x00000015
    Simple_To_Detailed = 22, // 0x00000016
    Detailed_To_Simple = 23, // 0x00000017
    Both_To_Open_And_Close_Stamp_Panel = 31, // 0x0000001F
    Open_Stamp_Panel = 32, // 0x00000020
    Close_Stamp_Panel = 33, // 0x00000021
  }
}
