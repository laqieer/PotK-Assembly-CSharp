// Decompiled with JetBrains decompiler
// Type: SM.Description
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class Description : KeyCompare
  {
    public DescriptionBodies[] bodies;
    public string title;

    public Description()
    {
    }

    public Description(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<DescriptionBodies> descriptionBodiesList = new List<DescriptionBodies>();
      foreach (object json1 in (List<object>) json[nameof (bodies)])
        descriptionBodiesList.Add(json1 != null ? new DescriptionBodies((Dictionary<string, object>) json1) : (DescriptionBodies) null);
      this.bodies = descriptionBodiesList.ToArray();
      this.title = json[nameof (title)] != null ? (string) json[nameof (title)] : (string) null;
    }
  }
}
