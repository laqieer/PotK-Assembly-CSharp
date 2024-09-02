// Decompiled with JetBrains decompiler
// Type: SM.GachaModuleDecks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
      foreach (object obj in (List<object>) json[nameof (probabilities)])
        decksProbabilitiesList.Add(obj == null ? (GachaModuleDecksProbabilities) null : new GachaModuleDecksProbabilities((Dictionary<string, object>) obj));
      this.probabilities = decksProbabilitiesList.ToArray();
      List<GachaModuleDecksEntities> moduleDecksEntitiesList = new List<GachaModuleDecksEntities>();
      foreach (object obj in (List<object>) json[nameof (entities)])
        moduleDecksEntitiesList.Add(obj == null ? (GachaModuleDecksEntities) null : new GachaModuleDecksEntities((Dictionary<string, object>) obj));
      this.entities = moduleDecksEntitiesList.ToArray();
      this.id = (int) (long) json[nameof (id)];
    }
  }
}
