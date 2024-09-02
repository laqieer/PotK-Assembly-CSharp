// Decompiled with JetBrains decompiler
// Type: SM.GachaModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaModule : KeyCompare
  {
    public GachaDescription description;
    public GachaModuleNewentity[] newentity;
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
      this.description = json[nameof (description)] != null ? new GachaDescription((Dictionary<string, object>) json[nameof (description)]) : (GachaDescription) null;
      List<GachaModuleNewentity> gachaModuleNewentityList = new List<GachaModuleNewentity>();
      foreach (object json1 in (List<object>) json[nameof (newentity)])
        gachaModuleNewentityList.Add(json1 != null ? new GachaModuleNewentity((Dictionary<string, object>) json1) : (GachaModuleNewentity) null);
      this.newentity = gachaModuleNewentityList.ToArray();
      List<GachaModuleDecks> gachaModuleDecksList = new List<GachaModuleDecks>();
      foreach (object json2 in (List<object>) json[nameof (decks)])
        gachaModuleDecksList.Add(json2 != null ? new GachaModuleDecks((Dictionary<string, object>) json2) : (GachaModuleDecks) null);
      this.decks = gachaModuleDecksList.ToArray();
      this.number = (int) (long) json[nameof (number)];
      this.stepup = json[nameof (stepup)] != null ? new GachaStepup((Dictionary<string, object>) json[nameof (stepup)]) : (GachaStepup) null;
      this.period = json[nameof (period)] != null ? new GachaPeriod((Dictionary<string, object>) json[nameof (period)]) : (GachaPeriod) null;
      this.front_image_url = json[nameof (front_image_url)] != null ? (string) json[nameof (front_image_url)] : (string) null;
      List<GachaModuleGacha> gachaModuleGachaList = new List<GachaModuleGacha>();
      foreach (object json3 in (List<object>) json[nameof (gacha)])
        gachaModuleGachaList.Add(json3 != null ? new GachaModuleGacha((Dictionary<string, object>) json3) : (GachaModuleGacha) null);
      this.gacha = gachaModuleGachaList.ToArray();
      this.type = (int) (long) json[nameof (type)];
      this.title_banner_url = json[nameof (title_banner_url)] != null ? (string) json[nameof (title_banner_url)] : (string) null;
      this.name = (string) json[nameof (name)];
    }
  }
}
