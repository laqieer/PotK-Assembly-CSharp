// Decompiled with JetBrains decompiler
// Type: DetailControllerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using SM;

#nullable disable
public class DetailControllerData
{
  public string body;
  public int? image_height;
  public string image_url;
  public int? image_width;

  public DetailControllerData(GachaDescriptionBodies data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
  }

  public DetailControllerData(QuestScoreCampaignDescriptionBlockBodies data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
  }

  public DetailControllerData(DescriptionBodies data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
  }

  public DetailControllerData(GuildBankHowto data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
  }
}
