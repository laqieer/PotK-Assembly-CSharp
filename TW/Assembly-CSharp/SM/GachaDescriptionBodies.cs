// Decompiled with JetBrains decompiler
// Type: SM.GachaDescriptionBodies
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class GachaDescriptionBodies : KeyCompare
  {
    public string body;
    public int? kind;
    public int? extra_position;
    public int? extra_id;
    public int? image_width;
    public int? image_height;
    public string image_url;
    public int? extra_type;

    public GachaDescriptionBodies()
    {
    }

    public GachaDescriptionBodies(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.body = json[nameof (body)] != null ? (string) json[nameof (body)] : (string) null;
      int? nullable1;
      if (json[nameof (kind)] == null)
      {
        nullable1 = new int?();
      }
      else
      {
        long? nullable2 = (long?) json[nameof (kind)];
        nullable1 = !nullable2.HasValue ? new int?() : new int?((int) nullable2.Value);
      }
      this.kind = nullable1;
      int? nullable3;
      if (json[nameof (extra_position)] == null)
      {
        nullable3 = new int?();
      }
      else
      {
        long? nullable4 = (long?) json[nameof (extra_position)];
        nullable3 = !nullable4.HasValue ? new int?() : new int?((int) nullable4.Value);
      }
      this.extra_position = nullable3;
      int? nullable5;
      if (json[nameof (extra_id)] == null)
      {
        nullable5 = new int?();
      }
      else
      {
        long? nullable6 = (long?) json[nameof (extra_id)];
        nullable5 = !nullable6.HasValue ? new int?() : new int?((int) nullable6.Value);
      }
      this.extra_id = nullable5;
      int? nullable7;
      if (json[nameof (image_width)] == null)
      {
        nullable7 = new int?();
      }
      else
      {
        long? nullable8 = (long?) json[nameof (image_width)];
        nullable7 = !nullable8.HasValue ? new int?() : new int?((int) nullable8.Value);
      }
      this.image_width = nullable7;
      int? nullable9;
      if (json[nameof (image_height)] == null)
      {
        nullable9 = new int?();
      }
      else
      {
        long? nullable10 = (long?) json[nameof (image_height)];
        nullable9 = !nullable10.HasValue ? new int?() : new int?((int) nullable10.Value);
      }
      this.image_height = nullable9;
      this.image_url = json[nameof (image_url)] != null ? (string) json[nameof (image_url)] : (string) null;
      int? nullable11;
      if (json[nameof (extra_type)] == null)
      {
        nullable11 = new int?();
      }
      else
      {
        long? nullable12 = (long?) json[nameof (extra_type)];
        nullable11 = !nullable12.HasValue ? new int?() : new int?((int) nullable12.Value);
      }
      this.extra_type = nullable11;
    }
  }
}
