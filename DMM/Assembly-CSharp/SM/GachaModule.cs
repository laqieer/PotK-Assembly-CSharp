// Decompiled with JetBrains decompiler
// Type: SM.GachaModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class GachaModule : KeyCompare
  {
    public GachaDescription description;
    public GachaModuleNewentity[] newentity;
    public bool is_review_popup;
    public GachaModuleDecks[] decks;
    public int number;
    public GachaStepup stepup;
    public GachaPeriod period;
    public string front_image_url;
    public GachaModuleGacha[] gacha;
    public int type;
    public string title_banner_url;
    public string name;

    public GachaModule()
    {
    }

    public GachaModule(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.description = json[nameof (description)] == null ? (GachaDescription) null : new GachaDescription((Dictionary<string, object>) json[nameof (description)]);
      List<GachaModuleNewentity> gachaModuleNewentityList = new List<GachaModuleNewentity>();
      foreach (object obj in (List<object>) json[nameof (newentity)])
        gachaModuleNewentityList.Add(obj == null ? (GachaModuleNewentity) null : new GachaModuleNewentity((Dictionary<string, object>) obj));
      this.newentity = gachaModuleNewentityList.ToArray();
      this.is_review_popup = (bool) json[nameof (is_review_popup)];
      List<GachaModuleDecks> gachaModuleDecksList = new List<GachaModuleDecks>();
      foreach (object obj in (List<object>) json[nameof (decks)])
        gachaModuleDecksList.Add(obj == null ? (GachaModuleDecks) null : new GachaModuleDecks((Dictionary<string, object>) obj));
      this.decks = gachaModuleDecksList.ToArray();
      this.number = (int) (long) json[nameof (number)];
      this.stepup = json[nameof (stepup)] == null ? (GachaStepup) null : new GachaStepup((Dictionary<string, object>) json[nameof (stepup)]);
      this.period = json[nameof (period)] == null ? (GachaPeriod) null : new GachaPeriod((Dictionary<string, object>) json[nameof (period)]);
      this.front_image_url = json[nameof (front_image_url)] == null ? (string) null : (string) json[nameof (front_image_url)];
      List<GachaModuleGacha> gachaModuleGachaList = new List<GachaModuleGacha>();
      foreach (object obj in (List<object>) json[nameof (gacha)])
        gachaModuleGachaList.Add(obj == null ? (GachaModuleGacha) null : new GachaModuleGacha((Dictionary<string, object>) obj));
      this.gacha = gachaModuleGachaList.ToArray();
      this.type = (int) (long) json[nameof (type)];
      this.title_banner_url = json[nameof (title_banner_url)] == null ? (string) null : (string) json[nameof (title_banner_url)];
      this.name = (string) json[nameof (name)];
    }
  }
}
