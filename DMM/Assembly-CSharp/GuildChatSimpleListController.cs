﻿// Decompiled with JetBrains decompiler
// Type: GuildChatSimpleListController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class GuildChatSimpleListController : MonoBehaviour
{
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
  public const int maxDisplayingItemCount = 3;

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
    float num1 = this.grid.transform.childCount <= 0 ? 0.0f : this.grid.transform.GetChild(this.grid.transform.childCount - 1).localPosition.y - this.simpleViewItemHeight;
    for (int index = 0; index < dataList.Count; ++index)
    {
      GameObject self = Object.Instantiate<GameObject>(this.guildChatManager.simpleMessageItemPrefab);
      self.GetComponent<GuildChatMessageItemController>().InitializeSimpleMessageItem(dataList[index]);
      self.SetParent(this.grid.gameObject);
      self.transform.localScale = Vector3.one;
      self.transform.localPosition = new Vector3(0.0f, num1 - (float) index * this.simpleViewItemHeight, 0.0f);
    }
    if (this.grid.transform.childCount <= 0)
      return;
    this.sp.enabled = false;
    this.scrollView.currentMomentum = Vector3.zero;
    int num2 = this.grid.transform.childCount < 3 ? 3 - this.grid.transform.childCount : 0;
    this.sp.target = new Vector3(0.0f, -(this.grid.transform.GetChild(this.grid.transform.childCount - 1).transform.localPosition.y - (float) num2 * this.simpleViewItemHeight) + this.simpleViewItemHeight, 0.0f);
    this.sp.onFinished = new SpringPanel.OnFinished(this.OnScrollFinished);
    this.sp.enabled = true;
  }

  private void OnScrollFinished()
  {
    int num = this.grid.transform.childCount - 3;
    if (num <= 0)
      return;
    for (int index = 0; index < num; ++index)
    {
      Transform child = this.grid.transform.GetChild(num - 1 - index);
      child.SetParent((Transform) null);
      Object.Destroy((Object) child.gameObject);
    }
  }

  public void ClearMessageItemList()
  {
    if ((Object) this.grid == (Object) null)
      Debug.Log((object) "grid = null");
    foreach (Transform transform in this.grid.transform)
    {
      if ((Object) transform == (Object) null)
        Debug.Log((object) "t = null");
      if ((Object) transform.gameObject == (Object) null)
        Debug.Log((object) "(t.gameObject = null");
      Object.Destroy((Object) transform.gameObject);
    }
    if ((Object) this.sp == (Object) null)
      Debug.Log((object) "(sp = null");
    if ((Object) this.scrollView == (Object) null)
      Debug.Log((object) "(scrollView = null");
    Vector3 currentMomentum = this.scrollView.currentMomentum;
    this.sp.enabled = false;
    this.scrollView.currentMomentum = Vector3.zero;
    if ((Object) this.scrollView.panel == (Object) null)
      Debug.Log((object) "(scrollView.panel = null");
    this.scrollView.transform.localPosition = Vector3.zero;
    if ((Object) this.scrollView.panel == (Object) null)
      this.scrollView.GetComponent<UIPanel>().clipOffset = Vector2.zero;
    else
      this.scrollView.panel.clipOffset = Vector2.zero;
  }
}
