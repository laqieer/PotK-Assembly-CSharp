// Decompiled with JetBrains decompiler
// Type: SM.GachaModuleDecks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaModuleDecks : KeyCompare
  {
    public GachaModuleDecksProbabilities[] probabilities;
    public GachaModuleDecksEntities[] entities;
    public int id;

    public GachaModuleDecks()
    {
    }

    public GachaModuleDecks(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<GachaModuleDecksProbabilities> decksProbabilitiesList = new List<GachaModuleDecksProbabilities>();
      foreach (object json1 in (List<object>) json[nameof (probabilities)])
        decksProbabilitiesList.Add(json1 != null ? new GachaModuleDecksProbabilities((Dictionary<string, object>) json1) : (GachaModuleDecksProbabilities) null);
      this.probabilities = decksProbabilitiesList.ToArray();
      List<GachaModuleDecksEntities> moduleDecksEntitiesList = new List<GachaModuleDecksEntities>();
      foreach (object json2 in (List<object>) json[nameof (entities)])
        moduleDecksEntitiesList.Add(json2 != null ? new GachaModuleDecksEntities((Dictionary<string, object>) json2) : (GachaModuleDecksEntities) null);
      this.entities = moduleDecksEntitiesList.ToArray();
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
