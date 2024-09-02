// Decompiled with JetBrains decompiler
// Type: DetailControllerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using MasterDataTable;
using SM;

#nullable disable
public class DetailControllerData
{
  public string body;
  public int? image_height;
  public string image_url;
  public int? image_width;
  public int? extra_type;
  public int? extra_id;
  public int? extra_position;
  public string scene_name;
  public string param_name;

  public DetailControllerData(OfficialInformationArticleBodies data)
  {
    this.body = data.body;
    this.image_height = new int?(data.img_height);
    this.image_url = data.body_img_url;
    this.image_width = new int?(data.img_width);
    this.extra_type = new int?(data.extra_type);
    this.extra_id = new int?(data.extra_id);
    this.extra_position = new int?(data.extra_position);
    this.scene_name = data.scene_name;
    this.param_name = data.param_name;
  }

  public DetailControllerData(GachaDescriptionBodies data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
    this.extra_type = data.extra_type;
    this.extra_id = data.extra_id;
    this.extra_position = data.extra_position;
  }

  public DetailControllerData(QuestScoreCampaignDescriptionBlockBodies data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
    this.extra_type = data.extra_type;
    this.extra_id = data.extra_id;
    this.extra_position = data.extra_position;
  }

  public DetailControllerData(DescriptionBodies data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
    this.extra_type = data.extra_type;
    this.extra_id = data.extra_id;
    this.extra_position = data.extra_position;
  }

  public DetailControllerData(GuildBankHowto data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
    this.extra_type = data.extra_type;
    this.extra_id = data.extra_id;
    this.extra_position = data.extra_position;
  }

  public DetailControllerData(QuestExtraDescription data)
  {
    this.body = data.body;
    this.image_height = data.image_height;
    this.image_url = data.image_url;
    this.image_width = data.image_width;
    this.extra_type = data.extra_type;
    this.extra_id = data.extra_id;
    this.extra_position = data.extra_position;
  }
}
