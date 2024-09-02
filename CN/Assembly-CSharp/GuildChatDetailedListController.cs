// Decompiled with JetBrains decompiler
// Type: GuildChatDetailedListController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using GameCore;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildChatDetailedListController : MonoBehaviour
{
  private const int bufferedMessageItemCount = 10;
  private const float dragToLoadThreshold = 180f;
  private const int showBottomArrowThreshold = 2;
  [SerializeField]
  private GuildChatManager guildChatManager;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private SpringPanel springPanel;
  [SerializeField]
  private GameObject bottomArrow;
  [SerializeField]
  private UIPanel panel;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private GameObject headPlaceholder;
  [SerializeField]
  private GameObject tailPlaceholder;
  public Future<GameObject> guildChatContextMenuLogPopup01;
  public Future<GameObject> guildChatContextMenuGuildmasterPopup01;
  public Future<GameObject> guildChatContextMenuMemberPopup01;
  public Future<GameObject> bbsViewDialogPrefab;
  public Future<GameObject> bbsEditorDialogPrefab;
  private float itemHeight;
  private float clipSoftnessY;
  private List<GuildChatMessageData> displayingMessageDataList = new List<GuildChatMessageData>();
  private List<GameObject> bufferedMemberLogItems;
  private List<GameObject> bufferedMemberChatItems;
  private List<GameObject> bufferedPlayerLogItems;
  private List<GameObject> bufferedPlayerChatItems;
  private List<GameObject> bufferedSystemLogItems;
  private List<GameObject> bufferedDeletedItems;
  private bool isUpdateLocked = true;
  private bool isScrollViewDraggedDown;

  private void Awake()
  {
    this.InitializeBufferedMessageItems();
    this.StartCoroutine(this.InitializePopupDialogPrefabs());
  }

  private void OnEnable()
  {
    if (!this.guildChatManager.isFirstTimeOpeningDetailedView)
      return;
    this.isUpdateLocked = true;
    this.StartCoroutine(this.ReleaseUpdateLockDelay());
    this.guildChatManager.isFirstTimeOpeningDetailedView = false;
  }

  private void Start()
  {
  }

  [DebuggerHidden]
  private IEnumerator ReleaseUpdateLockDelay()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatDetailedListController.\u003CReleaseUpdateLockDelay\u003Ec__IteratorA44()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void Update()
  {
    if (this.isUpdateLocked)
      return;
    this.UpdateDetailedMessageList();
    this.UpdateBottomArrow();
    if (this.scrollView.isDragging)
    {
      if (this.isScrollViewDraggedDown || (double) this.panel.finalClipRegion.y - (double) this.headPlaceholder.transform.localPosition.y < 180.0)
        return;
      this.isScrollViewDraggedDown = true;
      this.guildChatManager.OnPullDownMessageListFromTop();
    }
    else
      this.isScrollViewDraggedDown = false;
  }

  public void ResetPlaceholderPosition()
  {
    this.CleanAllBufferedMessageItems();
    ((Component) this.grid).transform.localPosition = new Vector3(0.0f, this.panel.finalClipRegion.w / 2f, 0.0f);
    this.headPlaceholder.transform.localPosition = Vector3.zero;
    float num = (float) this.displayingMessageDataList.Count * this.itemHeight;
    if ((double) this.panel.finalClipRegion.w > (double) num)
    {
      this.tailPlaceholder.transform.localPosition = new Vector3(0.0f, -this.panel.finalClipRegion.w, 0.0f);
      ((Component) this.scrollView).transform.localPosition = new Vector3(((Component) this.scrollView).transform.localPosition.x, 0.0f - this.clipSoftnessY, ((Component) this.scrollView).transform.localPosition.z);
      this.panel.clipOffset = new Vector2(-((Component) this.scrollView).transform.localPosition.x, -((Component) this.scrollView).transform.localPosition.y);
    }
    else
    {
      this.tailPlaceholder.transform.localPosition = new Vector3(0.0f, -num, 0.0f);
      ((Component) this.scrollView).transform.localPosition = new Vector3(((Component) this.scrollView).transform.localPosition.x, num - this.panel.finalClipRegion.w + this.clipSoftnessY, ((Component) this.scrollView).transform.localPosition.z);
      this.panel.clipOffset = new Vector2(-((Component) this.scrollView).transform.localPosition.x, -((Component) this.scrollView).transform.localPosition.y);
    }
  }

  public void AdjustPlaceholderPosition(
    int newDataCount,
    int oldDataCount,
    int deletedDataCount,
    bool scrollToBottomNow = false)
  {
    float num = this.panel.finalClipRegion.y - this.panel.finalClipRegion.w - this.tailPlaceholder.transform.localPosition.y;
    Transform transform = this.headPlaceholder.transform;
    transform.localPosition = Vector3.op_Addition(transform.localPosition, new Vector3(0.0f, (float) (oldDataCount - deletedDataCount) * this.itemHeight, 0.0f));
    this.tailPlaceholder.transform.localPosition = Vector3.op_Addition(this.headPlaceholder.transform.localPosition, new Vector3(0.0f, -this.itemHeight * (float) this.displayingMessageDataList.Count, 0.0f));
    if ((double) this.headPlaceholder.transform.localPosition.y - (double) this.tailPlaceholder.transform.localPosition.y < (double) this.panel.finalClipRegion.w)
      this.tailPlaceholder.transform.localPosition = Vector3.op_Subtraction(this.headPlaceholder.transform.localPosition, new Vector3(0.0f, this.panel.finalClipRegion.w, 0.0f));
    if ((double) this.panel.finalClipRegion.y > (double) this.headPlaceholder.transform.localPosition.y && !this.scrollView.isDragging)
    {
      ((Component) this.scrollView).transform.localPosition = new Vector3(((Component) this.scrollView).transform.localPosition.x, -this.headPlaceholder.transform.localPosition.y - this.clipSoftnessY, ((Component) this.scrollView).transform.localPosition.z);
      this.panel.clipOffset = new Vector2(-((Component) this.scrollView).transform.localPosition.x, -((Component) this.scrollView).transform.localPosition.y);
    }
    if (newDataCount <= 0)
      return;
    if (scrollToBottomNow || (double) num < (double) this.itemHeight * 2.0)
    {
      this.springPanel.target = new Vector3(((Component) this.scrollView).transform.localPosition.x, -(this.tailPlaceholder.transform.localPosition.y + this.panel.finalClipRegion.w) + this.clipSoftnessY, ((Component) this.scrollView).transform.localPosition.z);
      ((Behaviour) this.springPanel).enabled = true;
    }
    else
    {
      if (Singleton<CommonRoot>.GetInstance().guildChatManager.GetCurrentGuildChatStatus() != GuildChatManager.GuildChatStatus.DetailedView)
        return;
      this.ShowBottomArrow();
    }
  }

  public void SetDisplayingMessageDataList(List<GuildChatMessageData> messageDataList)
  {
    this.displayingMessageDataList = messageDataList;
  }

  private void UpdateDetailedMessageList()
  {
    if ((double) this.scrollView.panel.finalClipRegion.y - (double) this.scrollView.panel.finalClipRegion.w > (double) this.headPlaceholder.transform.localPosition.y || (double) this.tailPlaceholder.transform.localPosition.y > (double) this.scrollView.panel.finalClipRegion.y)
      return;
    int num1 = 0;
    if ((double) this.headPlaceholder.transform.localPosition.y > (double) this.panel.finalClipRegion.y)
      num1 = Mathf.FloorToInt((this.headPlaceholder.transform.localPosition.y - this.panel.finalClipRegion.y) / this.itemHeight);
    int num2 = this.displayingMessageDataList.Count - 1;
    if ((double) this.panel.finalClipRegion.y - (double) this.panel.finalClipRegion.w > (double) this.tailPlaceholder.transform.localPosition.y)
      num2 = Mathf.FloorToInt((this.headPlaceholder.transform.localPosition.y - (this.panel.finalClipRegion.y - this.panel.finalClipRegion.w)) / this.itemHeight);
    List<long> visibleMessageIDs = new List<long>();
    for (int index = num1; index <= num2; ++index)
    {
      if (index < this.displayingMessageDataList.Count)
        visibleMessageIDs.Add(this.displayingMessageDataList[index].messageID);
    }
    this.PrepareBufferedMessageItems(visibleMessageIDs);
    for (int index = num1; index <= num2 && index < this.displayingMessageDataList.Count; ++index)
    {
      GuildChatMessageData displayingMessageData = this.displayingMessageDataList[index];
      GuildChatMessageItemController messageItemController = this.GetMessageItemController(displayingMessageData);
      if (Object.op_Inequality((Object) messageItemController, (Object) null))
      {
        messageItemController.InitializeDetailedMessageItem(displayingMessageData);
        ((Component) messageItemController).transform.SetParent(((Component) this.grid).transform);
        ((Component) messageItemController).transform.localScale = Vector3.one;
        ((Component) messageItemController).transform.localPosition = new Vector3(0.0f, this.headPlaceholder.transform.localPosition.y - (float) index * this.itemHeight, 0.0f);
        ((Component) messageItemController).gameObject.SetActive(true);
      }
    }
  }

  private void UpdateBottomArrow()
  {
    if ((double) this.tailPlaceholder.transform.localPosition.y < (double) this.scrollView.panel.finalClipRegion.y - (double) this.scrollView.panel.finalClipRegion.w)
      return;
    this.HideBottomArrow();
  }

  private void HideBottomArrow()
  {
    if (!this.bottomArrow.activeSelf)
      return;
    TweenPosition component = this.bottomArrow.GetComponent<TweenPosition>();
    component.SetOnFinished((EventDelegate.Callback) (() => this.bottomArrow.SetActive(false)));
    component.PlayReverse();
    this.bottomArrow.GetComponent<TweenAlpha>().PlayReverse();
  }

  private void ShowBottomArrow()
  {
    if (this.bottomArrow.activeSelf)
      return;
    this.bottomArrow.SetActive(true);
    TweenPosition componentInChildren = this.bottomArrow.GetComponentInChildren<TweenPosition>();
    componentInChildren.onFinished.Clear();
    ((Component) componentInChildren).GetComponent<TweenPosition>().PlayForward();
    this.bottomArrow.GetComponent<TweenAlpha>().PlayForward();
  }

  private GuildChatMessageItemController GetMessageItemController(GuildChatMessageData data)
  {
    GuildChatMessageItemController messageItemController = (GuildChatMessageItemController) null;
    List<GameObject> gameObjectList = (List<GameObject>) null;
    if (data.isDeleted)
      gameObjectList = this.bufferedDeletedItems;
    else if (data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerChat)
      gameObjectList = this.bufferedPlayerChatItems;
    else if (data.messageType == GuildChatMessageData.GuildChatMessageType.PlayerLog)
      gameObjectList = this.bufferedPlayerLogItems;
    else if (data.messageType == GuildChatMessageData.GuildChatMessageType.MemberChat)
      gameObjectList = this.bufferedMemberChatItems;
    else if (data.messageType == GuildChatMessageData.GuildChatMessageType.MemberLog)
      gameObjectList = this.bufferedMemberLogItems;
    else if (data.messageType == GuildChatMessageData.GuildChatMessageType.SystemLog)
      gameObjectList = this.bufferedSystemLogItems;
    bool flag = false;
    for (int index = 0; index < gameObjectList.Count; ++index)
    {
      if (gameObjectList[index].activeSelf)
      {
        GuildChatMessageItemController component = gameObjectList[index].GetComponent<GuildChatMessageItemController>();
        if (component.originalMessageData.messageID == data.messageID)
        {
          messageItemController = component;
          flag = true;
          break;
        }
      }
    }
    if (!flag)
    {
      for (int index = 0; index < gameObjectList.Count; ++index)
      {
        if (!gameObjectList[index].activeSelf)
        {
          messageItemController = gameObjectList[index].GetComponent<GuildChatMessageItemController>();
          break;
        }
      }
    }
    return messageItemController;
  }

  [DebuggerHidden]
  private IEnumerator InitializePopupDialogPrefabs()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildChatDetailedListController.\u003CInitializePopupDialogPrefabs\u003Ec__IteratorA45()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void PrepareBufferedMessageItems(List<long> visibleMessageIDs)
  {
    for (int index = 0; index < 10; ++index)
    {
      GuildChatMessageItemController component1 = this.bufferedDeletedItems[index].GetComponent<GuildChatMessageItemController>();
      if (component1.originalMessageData == null || !visibleMessageIDs.Contains(component1.originalMessageData.messageID))
      {
        component1.originalMessageData = (GuildChatMessageData) null;
        ((Component) component1).gameObject.SetActive(false);
      }
      GuildChatMessageItemController component2 = this.bufferedMemberChatItems[index].GetComponent<GuildChatMessageItemController>();
      if (component2.originalMessageData == null || !visibleMessageIDs.Contains(component2.originalMessageData.messageID))
      {
        component2.originalMessageData = (GuildChatMessageData) null;
        ((Component) component2).gameObject.SetActive(false);
      }
      GuildChatMessageItemController component3 = this.bufferedMemberLogItems[index].GetComponent<GuildChatMessageItemController>();
      if (component3.originalMessageData == null || !visibleMessageIDs.Contains(component3.originalMessageData.messageID))
      {
        component3.originalMessageData = (GuildChatMessageData) null;
        ((Component) component3).gameObject.SetActive(false);
      }
      GuildChatMessageItemController component4 = this.bufferedPlayerChatItems[index].GetComponent<GuildChatMessageItemController>();
      if (component4.originalMessageData == null || !visibleMessageIDs.Contains(component4.originalMessageData.messageID))
      {
        component4.originalMessageData = (GuildChatMessageData) null;
        ((Component) component4).gameObject.SetActive(false);
      }
      GuildChatMessageItemController component5 = this.bufferedPlayerLogItems[index].GetComponent<GuildChatMessageItemController>();
      if (component5.originalMessageData == null || !visibleMessageIDs.Contains(component5.originalMessageData.messageID))
      {
        component5.originalMessageData = (GuildChatMessageData) null;
        ((Component) component5).gameObject.SetActive(false);
      }
      GuildChatMessageItemController component6 = this.bufferedSystemLogItems[index].GetComponent<GuildChatMessageItemController>();
      if (component6.originalMessageData == null || !visibleMessageIDs.Contains(component6.originalMessageData.messageID))
      {
        component6.originalMessageData = (GuildChatMessageData) null;
        ((Component) component6).gameObject.SetActive(false);
      }
    }
  }

  private void CleanAllBufferedMessageItems()
  {
    for (int index = 0; index < 10; ++index)
    {
      this.bufferedDeletedItems[index].GetComponent<GuildChatMessageItemController>().originalMessageData = (GuildChatMessageData) null;
      this.bufferedMemberChatItems[index].GetComponent<GuildChatMessageItemController>().originalMessageData = (GuildChatMessageData) null;
      this.bufferedMemberLogItems[index].GetComponent<GuildChatMessageItemController>().originalMessageData = (GuildChatMessageData) null;
      this.bufferedPlayerChatItems[index].GetComponent<GuildChatMessageItemController>().originalMessageData = (GuildChatMessageData) null;
      this.bufferedPlayerLogItems[index].GetComponent<GuildChatMessageItemController>().originalMessageData = (GuildChatMessageData) null;
      this.bufferedSystemLogItems[index].GetComponent<GuildChatMessageItemController>().originalMessageData = (GuildChatMessageData) null;
    }
  }

  private void InitializeBufferedMessageItems()
  {
    this.itemHeight = (float) this.guildChatManager.playerChatItemPrefab.GetComponent<UIWidget>().height;
    this.clipSoftnessY = this.scrollView.panel.clipSoftness.y;
    this.bufferedPlayerChatItems = new List<GameObject>();
    for (int index = 0; index < 10; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.guildChatManager.playerChatItemPrefab);
      gameObject.SetActive(false);
      this.bufferedPlayerChatItems.Add(gameObject);
    }
    this.bufferedPlayerLogItems = new List<GameObject>();
    for (int index = 0; index < 10; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.guildChatManager.playerLogItemPrefab);
      gameObject.SetActive(false);
      this.bufferedPlayerLogItems.Add(gameObject);
    }
    this.bufferedMemberChatItems = new List<GameObject>();
    for (int index = 0; index < 10; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.guildChatManager.memberChatItemPrefab);
      gameObject.SetActive(false);
      this.bufferedMemberChatItems.Add(gameObject);
    }
    this.bufferedMemberLogItems = new List<GameObject>();
    for (int index = 0; index < 10; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.guildChatManager.memberLogItemPrefab);
      gameObject.SetActive(false);
      this.bufferedMemberLogItems.Add(gameObject);
    }
    this.bufferedSystemLogItems = new List<GameObject>();
    for (int index = 0; index < 10; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.guildChatManager.systemLogItemPrefab);
      gameObject.SetActive(false);
      this.bufferedSystemLogItems.Add(gameObject);
    }
    this.bufferedDeletedItems = new List<GameObject>();
    for (int index = 0; index < 10; ++index)
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.guildChatManager.deletedMessageItemPrefab);
      gameObject.SetActive(false);
      this.bufferedDeletedItems.Add(gameObject);
    }
  }

  public void ScrollToHead()
  {
    ((Component) this.scrollView).transform.localPosition = new Vector3(((Component) this.scrollView).transform.localPosition.x, -this.headPlaceholder.transform.localPosition.y, ((Component) this.scrollView).transform.localPosition.z);
    this.panel.clipOffset = new Vector2(-((Component) this.scrollView).transform.localPosition.x, -((Component) this.scrollView).transform.localPosition.y);
  }

  public void ScrollToTail()
  {
    ((Component) this.scrollView).transform.localPosition = new Vector3(((Component) this.scrollView).transform.localPosition.x, -(this.tailPlaceholder.transform.localPosition.y + this.panel.finalClipRegion.w), ((Component) this.scrollView).transform.localPosition.z);
    this.panel.clipOffset = new Vector2(-((Component) this.scrollView).transform.localPosition.x, -((Component) this.scrollView).transform.localPosition.y);
  }

  public bool IsScrollViewDragging() => this.scrollView.isDragging;

  public void StopScrollViewMovement()
  {
    ((Behaviour) this.springPanel).enabled = false;
    this.scrollView.currentMomentum = Vector3.zero;
  }
}
