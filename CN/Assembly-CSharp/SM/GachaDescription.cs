// Decompiled with JetBrains decompiler
// Type: SM.GachaDescription
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaDescription : KeyCompare
  {
    public GachaDescriptionBodies[] bodies;
    public string title;

    public GachaDescription()
    {
    }

    public GachaDescription(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<GachaDescriptionBodies> descriptionBodiesList = new List<GachaDescriptionBodies>();
      foreach (object json1 in (List<object>) json[nameof (bodies)])
        descriptionBodiesList.Add(json1 != null ? new GachaDescriptionBodies((Dictionary<string, object>) json1) : (GachaDescriptionBodies) null);
      this.bodies = descriptionBodiesList.ToArray();
      this.title = json[nameof (title)] != null ? (string) json[nameof (title)] : (string) null;
    }
  }
}
