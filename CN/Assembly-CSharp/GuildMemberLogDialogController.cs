// Decompiled with JetBrains decompiler
// Type: GuildMemberLogDialogController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class GuildMemberLogDialogController : MonoBehaviour
{
  private const int maxBufferedMemberLogItemCount = 10;
  private const int maxSavedMemberLogCount = 1000;
  private const float dragToLoadThreshold = 180f;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UIGrid grid;
  [SerializeField]
  private GameObject headPlaceholder;
  [SerializeField]
  private GameObject tailPlaceholder;
  [SerializeField]
  private GameObject memberLogItemPrefab;
  public string playerID;
  private List<GameObject> bufferedMemberLogItems = new List<GameObject>();
  private List<GuildChatMessageData> receivedMessageDataList = new List<GuildChatMessageData>();
  private List<GuildChatMessageData> displayingMemberLogDataList = new List<GuildChatMessageData>();
  private int memberLogItemHeight;
  private bool isUpdatingMemberLogData;
  private Coroutine updateMemberLogDataCoroutine;

  private void Awake()
  {
  }

  private void Start() => this.StartCoroutine(this.Initialize());

  private void Update()
  {
    this.UpdateMemberLogItemList();
    if (!this.scrollView.isDragging || this.isUpdatingMemberLogData || (double) this.scrollView.panel.finalClipRegion.y - (double) this.headPlaceholder.transform.localPosition.y < 180.0)
      return;
    this.OnPullDownMemberLogListFromTop();
  }

  [DebuggerHidden]
  public IEnumerator Initialize()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberLogDialogController.\u003CInitialize\u003Ec__IteratorA55()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateLatestMemberLogData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberLogDialogController.\u003CUpdateLatestMemberLogData\u003Ec__IteratorA56()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator UpdateEarlierMemberLogData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new GuildMemberLogDialogController.\u003CUpdateEarlierMemberLogData\u003Ec__IteratorA57()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void AdjustPlaceholderAndScrollView(
    int addedNewItemCount,
    int addedOldItemCount,
    int deletedOldItemCount)
  {
    Transform transform = this.headPlaceholder.transform;
    transform.localPosition = Vector3.op_Addition(transform.localPosition, new Vector3(0.0f, (float) (this.memberLogItemHeight * (addedOldItemCount - deletedOldItemCount)), 0.0f));
    this.tailPlaceholder.transform.localPosition = new Vector3(0.0f, this.headPlaceholder.transform.localPosition.y - (float) (this.memberLogItemHeight * this.displayingMemberLogDataList.Count), 0.0f);
    if ((double) this.headPlaceholder.transform.localPosition.y - (double) this.tailPlaceholder.transform.localPosition.y < (double) this.scrollView.panel.finalClipRegion.w)
      this.tailPlaceholder.transform.localPosition = new Vector3(0.0f, this.headPlaceholder.transform.localPosition.y - this.scrollView.panel.finalClipRegion.w, 0.0f);
    if (addedNewItemCount <= 0)
      return;
    ((Component) this.scrollView).transform.localPosition = new Vector3(0.0f, -(this.tailPlaceholder.transform.localPosition.y + this.scrollView.panel.finalClipRegion.w), 0.0f);
    this.scrollView.panel.clipOffset = new Vector2(0.0f, -((Component) this.scrollView).transform.localPosition.y);
  }

  private void UpdateMemberLogItemList()
  {
    foreach (GameObject bufferedMemberLogItem in this.bufferedMemberLogItems)
      bufferedMemberLogItem.SetActive(false);
    if ((double) this.scrollView.panel.finalClipRegion.y - (double) this.scrollView.panel.finalClipRegion.w > (double) this.headPlaceholder.transform.localPosition.y || (double) this.tailPlaceholder.transform.localPosition.y > (double) this.scrollView.panel.finalClipRegion.y)
      return;
    int num1 = 0;
    if ((double) this.headPlaceholder.transform.localPosition.y > (double) this.scrollView.panel.finalClipRegion.y)
      num1 = Mathf.FloorToInt((this.headPlaceholder.transform.localPosition.y - this.scrollView.panel.finalClipRegion.y) / (float) this.memberLogItemHeight);
    int num2 = this.displayingMemberLogDataList.Count - 1;
    if ((double) this.scrollView.panel.finalClipRegion.y - (double) this.scrollView.panel.finalClipRegion.w > (double) this.tailPlaceholder.transform.localPosition.y)
      num2 = Mathf.FloorToInt((this.headPlaceholder.transform.localPosition.y - (this.scrollView.panel.finalClipRegion.y - this.scrollView.panel.finalClipRegion.w)) / (float) this.memberLogItemHeight);
    for (int index = num1; index <= num2 && index <= this.displayingMemberLogDataList.Count - 1; ++index)
    {
      GameObject bufferedMemberLogItem = this.bufferedMemberLogItems[index - num1];
      bufferedMemberLogItem.transform.SetParent(((Component) this.grid).transform);
      bufferedMemberLogItem.transform.localScale = Vector3.one;
      bufferedMemberLogItem.transform.localPosition = new Vector3(0.0f, this.headPlaceholder.transform.localPosition.y - (float) (this.memberLogItemHeight * index), 0.0f);
      bufferedMemberLogItem.GetComponent<GuildChatMessageItemController>().InitializeMemberLogItem(this.displayingMemberLogDataList[index]);
      bufferedMemberLogItem.SetActive(true);
    }
  }

  public void OnCloseButtonClicked()
  {
    if (this.updateMemberLogDataCoroutine != null)
      this.StopCoroutine(this.updateMemberLogDataCoroutine);
    this.displayingMemberLogDataList.Clear();
    Singleton<PopupManager>.GetInstance().dismiss();
  }

  public void OnPullDownMemberLogListFromTop()
  {
    this.updateMemberLogDataCoroutine = this.StartCoroutine(this.UpdateEarlierMemberLogData());
  }
}
