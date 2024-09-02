// Decompiled with JetBrains decompiler
// Type: GuildChatSimpleListController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class GuildChatSimpleListController : MonoBehaviour
{
  public const int maxDisplayingItemCount = 3;
  [SerializeField]
  private GuildChatManager guildChatManager;
  [SerializeField]
  private UIScrollView scrollView;
  [SerializeField]
  private UIPanel panel;
  [SerializeField]
  private SpringPanel sp;
  [SerializeField]
  private UIGrid grid;
  private float normalizedCurrentScrollPositionY;
  private float simpleViewItemHeight = 30f;

  private void Awake()
  {
  }

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void AddSimpleMessageItems(List<GuildChatMessageData> dataList)
  {
    float num1 = ((Component) this.grid).transform.childCount <= 0 ? 0.0f : ((Component) this.grid).transform.GetChild(((Component) this.grid).transform.childCount - 1).localPosition.y - this.simpleViewItemHeight;
    for (int index = 0; index < dataList.Count; ++index)
    {
      GameObject self = Object.Instantiate<GameObject>(this.guildChatManager.simpleMessageItemPrefab);
      self.GetComponent<GuildChatMessageItemController>().InitializeSimpleMessageItem(dataList[index]);
      self.SetParent(((Component) this.grid).gameObject);
      self.transform.localScale = Vector3.one;
      self.transform.localPosition = new Vector3(0.0f, num1 - (float) index * this.simpleViewItemHeight, 0.0f);
    }
    if (((Component) this.grid).transform.childCount <= 0)
      return;
    ((Behaviour) this.sp).enabled = false;
    this.scrollView.currentMomentum = Vector3.zero;
    int num2 = ((Component) this.grid).transform.childCount >= 3 ? 0 : 3 - ((Component) this.grid).transform.childCount;
    this.sp.target = new Vector3(0.0f, -(((Component) ((Component) this.grid).transform.GetChild(((Component) this.grid).transform.childCount - 1)).transform.localPosition.y - (float) num2 * this.simpleViewItemHeight) + this.simpleViewItemHeight, 0.0f);
    this.sp.onFinished = new SpringPanel.OnFinished(this.OnScrollFinished);
    ((Behaviour) this.sp).enabled = true;
  }

  private void OnScrollFinished()
  {
    int num = ((Component) this.grid).transform.childCount - 3;
    if (num <= 0)
      return;
    for (int index = 0; index < num; ++index)
    {
      Transform child = ((Component) this.grid).transform.GetChild(num - 1 - index);
      child.SetParent((Transform) null);
      Object.Destroy((Object) ((Component) child).gameObject);
    }
  }

  public void ClearMessageItemList()
  {
    foreach (Component component in ((Component) this.grid).transform)
      Object.Destroy((Object) component.gameObject);
    ((Behaviour) this.sp).enabled = false;
    this.scrollView.currentMomentum = Vector3.zero;
    ((Component) this.scrollView).transform.localPosition = Vector3.zero;
    this.scrollView.panel.clipOffset = Vector2.zero;
  }
}
