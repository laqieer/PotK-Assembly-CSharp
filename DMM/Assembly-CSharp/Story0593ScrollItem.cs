﻿// Decompiled with JetBrains decompiler
// Type: Story0593ScrollItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Story0593ScrollItem : MonoBehaviour
{
  [SerializeField]
  private UILabel mTitleLabel;
  private Story059ItemData mItem;

  public void Init(Story059ItemData item)
  {
    this.mItem = item;
    this.mTitleLabel.SetTextLocalize(item.title);
    item._myStory0593ScrollItem = this;
  }

  public void onItemClick() => this.mItem.Play();

  public void ShowMainPanel(bool active)
  {
    Singleton<CommonRoot>.GetInstance().isActiveHeader = active;
    Singleton<CommonRoot>.GetInstance().isActiveFooter = active;
    Singleton<CommonRoot>.GetInstance().setDisableFooterColor(!active);
    Singleton<CommonRoot>.GetInstance().getBackgroundComponent<Transform>().gameObject.SetActive(active);
    this.gameObject.GetComponentInParent<Story0593Menu>().activeScrollMainPanel(active);
  }
}
