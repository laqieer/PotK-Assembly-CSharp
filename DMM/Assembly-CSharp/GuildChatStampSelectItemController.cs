// Decompiled with JetBrains decompiler
// Type: GuildChatStampSelectItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GuildChatStampSelectItemController : MonoBehaviour
{
  public int stampID;
  [SerializeField]
  private UISprite stampImage;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void InitializeGuildChatStampItem(int stampID)
  {
    this.stampID = stampID;
    Singleton<CommonRoot>.GetInstance().guildChatManager.SetStampSprite(this.stampImage, this.stampID);
  }

  public void Clear()
  {
    this.stampID = 0;
    this.gameObject.SetActive(false);
  }

  public void OnStampItemClicked() => Singleton<CommonRoot>.GetInstance().guildChatManager.stampSelectViewController.SelectStamp(this.stampID);
}
