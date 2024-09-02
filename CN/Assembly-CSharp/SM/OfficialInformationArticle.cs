// Decompiled with JetBrains decompiler
// Type: SM.OfficialInformationArticle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class OfficialInformationArticle : KeyCompare
  {
    public int category_id;
    public int sub_category_id;
    public DateTime last_updated_at;
    public string title;
    public string title_img_url;
    public int priority;
    public DateTime published_at;
    public string header_img_url;
    public int official_update_type;
    public string badge_display;
    public int id;
    public OfficialInformationArticleBodies[] bodies;

    public OfficialInformationArticle()
    {
    }

    public OfficialInformationArticle(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.category_id = (int) (long) json[nameof (category_id)];
      this.sub_category_id = (int) (long) json[nameof (sub_category_id)];
      this.last_updated_at = DateTime.Parse((string) json[nameof (last_updated_at)]);
      this.title = (string) json[nameof (title)];
      this.title_img_url = (string) json[nameof (title_img_url)];
      this.priority = (int) (long) json[nameof (priority)];
      this.published_at = DateTime.Parse((string) json[nameof (published_at)]);
      this.header_img_url = (string) json[nameof (header_img_url)];
      this.official_update_type = (int) (long) json[nameof (official_update_type)];
      this.badge_display = (string) json[nameof (badge_display)];
      this.id = (int) (long) json[nameof (id)];
      List<OfficialInformationArticleBodies> informationArticleBodiesList = new List<OfficialInformationArticleBodies>();
      foreach (object json1 in (List<object>) json[nameof (bodies)])
        informationArticleBodiesList.Add(json1 != null ? new OfficialInformationArticleBodies((Dictionary<string, object>) json1) : (OfficialInformationArticleBodies) null);
      this.bodies = informationArticleBodiesList.ToArray();
    }
  }
}
