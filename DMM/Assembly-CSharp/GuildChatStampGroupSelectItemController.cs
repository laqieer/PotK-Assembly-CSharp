// Decompiled with JetBrains decompiler
// Type: GuildChatStampGroupSelectItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

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
      this.backgroundImage.gameObject.SetActive(true);
    }
    else
    {
      this.stampImage.color = new Color(0.5f, 0.5f, 0.5f);
      this.backgroundImage.gameObject.SetActive(false);
    }
  }

  public void OnStampGroupItemClicked() => Singleton<CommonRoot>.GetInstance().guildChatManager.stampSelectViewController.SelectStampGroup(this.stampGroupID);
}
