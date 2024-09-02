// Decompiled with JetBrains decompiler
// Type: GuildChatStampGroupSelectItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GuildChatStampGroupSelectItemController : MonoBehaviour
{
  public int iconStampID;
  public int stampGroupID;
  public bool isSelected;
  [SerializeField]
  private UISprite stampImage;
  [SerializeField]
  private UISprite backgroundImage;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void InitializeGuildChatStampGroupItem(int stampGroupID, int iconStampID)
  {
    this.stampGroupID = stampGroupID;
    this.iconStampID = iconStampID;
    Singleton<CommonRoot>.GetInstance().guildChatManager.SetStampSprite(this.stampImage, this.iconStampID);
  }

  public void SetSelected(bool isSelected)
  {
    this.isSelected = isSelected;
    if (isSelected)
    {
      this.stampImage.color = Color.white;
      ((Component) this.backgroundImage).gameObject.SetActive(true);
    }
    else
    {
      this.stampImage.color = new Color(0.5f, 0.5f, 0.5f);
      ((Component) this.backgroundImage).gameObject.SetActive(false);
    }
  }

  public void OnStampGroupItemClicked()
  {
    Debug.Log((object) "<color=yellow>Stamp group item is clicked.</color>");
    Singleton<CommonRoot>.GetInstance().guildChatManager.stampSelectViewController.SelectStampGroup(this.stampGroupID);
  }
}
