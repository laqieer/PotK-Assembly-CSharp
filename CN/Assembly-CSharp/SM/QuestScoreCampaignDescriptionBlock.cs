// Decompiled with JetBrains decompiler
// Type: SM.QuestScoreCampaignDescriptionBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class QuestScoreCampaignDescriptionBlock : KeyCompare
  {
    public QuestScoreCampaignDescriptionBlockBodies[] bodies;
    public string title;

    public QuestScoreCampaignDescriptionBlock()
    {
    }

    public QuestScoreCampaignDescriptionBlock(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<QuestScoreCampaignDescriptionBlockBodies> descriptionBlockBodiesList = new List<QuestScoreCampaignDescriptionBlockBodies>();
      foreach (object json1 in (List<object>) json[nameof (bodies)])
        descriptionBlockBodiesList.Add(json1 != null ? new QuestScoreCampaignDescriptionBlockBodies((Dictionary<string, object>) json1) : (QuestScoreCampaignDescriptionBlockBodies) null);
      this.bodies = descriptionBlockBodiesList.ToArray();
      this.title = json[nameof (title)] != null ? (string) json[nameof (title)] : (string) null;
    }
  }
}
