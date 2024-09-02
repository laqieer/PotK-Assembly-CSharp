// Decompiled with JetBrains decompiler
// Type: Story0593ScrollItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class Story0593ScrollItem : MonoBehaviour
{
  [SerializeField]
  private UILabel mTitleLabel;
  private Story059ItemData mItem;

  public void Init(Story059ItemData item)
  {
    this.mItem = item;
    this.mTitleLabel.SetTextLocalize(item.title);
  }

  public void onItemClick() => this.mItem.Play();
}
