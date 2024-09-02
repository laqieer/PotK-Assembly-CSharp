// Decompiled with JetBrains decompiler
// Type: FullScreenWrapContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Custum/UI/FullScreenWrapContent")]
public class FullScreenWrapContent : UIWrapContent
{
  [SerializeField]
  [Tooltip("Start()コールタイミングをコントロールしたい時にON")]
  private bool isDeactivateOnAwake_ = true;

  public FullScreenWrapContent.callbackUpdateItem onUpdateItem { get; set; }

  private void Awake()
  {
    if (!this.isDeactivateOnAwake_)
      return;
    this.gameObject.SetActive(false);
  }

  protected override void Start()
  {
    this.resetItemSize();
    base.Start();
  }

  public void resetItemSize()
  {
    if (!this.CacheScrollView())
      return;
    UIPanel inParents = NGUITools.FindInParents<UIPanel>(this.gameObject);
    UIScrollView component = inParents.GetComponent<UIScrollView>();
    inParents.UpdateAnchors();
    switch (component.movement)
    {
      case UIScrollView.Movement.Horizontal:
        this.itemSize = (int) inParents.width;
        break;
      case UIScrollView.Movement.Vertical:
        this.itemSize = (int) inParents.height;
        break;
    }
  }

  protected override void UpdateItem(Transform item, int index)
  {
    FullScreenWrapContent.callbackUpdateItem onUpdateItem = this.onUpdateItem;
    if (onUpdateItem == null)
      return;
    onUpdateItem(item, index);
  }

  public delegate void callbackUpdateItem(Transform item, int index);
}
