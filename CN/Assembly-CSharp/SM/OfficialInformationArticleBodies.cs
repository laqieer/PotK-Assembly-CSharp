// Decompiled with JetBrains decompiler
// Type: SM.OfficialInformationArticleBodies
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SM
{
  [Serializable]
  public class OfficialInformationArticleBodies : KeyCompare
  {
    public string body;
    public string param_name;
    public int img_width;
    public string body_img_url;
    public int img_height;
    public string scene_name;

    public OfficialInformationArticleBodies()
    {
    }

    public OfficialInformationArticleBodies(Dictionary<string, object> json)
    {
      this._hasKey = false;
      this.body = (string) json[nameof (body)];
      this.param_name = (string) json[nameof (param_name)];
      this.img_width = (int) (long) json[nameof (img_width)];
      this.body_img_url = (string) json[nameof (body_img_url)];
      this.img_height = (int) (long) json[nameof (img_height)];
      this.scene_name = (string) json[nameof (scene_name)];
    }
  }
}
