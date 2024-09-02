// Decompiled with JetBrains decompiler
// Type: SM.DescriptionBodies
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class DescriptionBodies : KeyCompare
  {
    public string body;
    public int? image_height;
    public string image_url;
    public int? image_width;

    public DescriptionBodies()
    {
    }

    public DescriptionBodies(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.body = json[nameof (body)] != null ? (string) json[nameof (body)] : (string) null;
      int? nullable1;
      if (json[nameof (image_height)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (image_height)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.image_height = nullable1;
      this.image_url = json[nameof (image_url)] != null ? (string) json[nameof (image_url)] : (string) null;
      int? nullable3;
      if (json[nameof (image_width)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (image_width)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.image_width = nullable3;
    }
  }
}
