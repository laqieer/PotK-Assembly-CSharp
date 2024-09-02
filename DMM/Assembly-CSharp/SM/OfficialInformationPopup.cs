// Decompiled with JetBrains decompiler
// Type: SM.OfficialInformationPopup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SM
{
  [Serializable]
  public class OfficialInformationPopup : KeyCompare
  {
    public OfficialInfoPopupSchema[] popup_pickups;
    public OfficialInfoUnitPopup[] popup_units;

    public OfficialInformationPopup()
    {
    }

    public OfficialInformationPopup(Dictionary<string, object> json)
    {
      this._hasKey = false;
      List<OfficialInfoPopupSchema> officialInfoPopupSchemaList = new List<OfficialInfoPopupSchema>();
      foreach (object obj in (List<object>) json[nameof (popup_pickups)])
        officialInfoPopupSchemaList.Add(obj == null ? (OfficialInfoPopupSchema) null : new OfficialInfoPopupSchema((Dictionary<string, object>) obj));
      this.popup_pickups = officialInfoPopupSchemaList.ToArray();
      List<OfficialInfoUnitPopup> officialInfoUnitPopupList = new List<OfficialInfoUnitPopup>();
      foreach (object obj in (List<object>) json[nameof (popup_units)])
        officialInfoUnitPopupList.Add(obj == null ? (OfficialInfoUnitPopup) null : new OfficialInfoUnitPopup((Dictionary<string, object>) obj));
      this.popup_units = officialInfoUnitPopupList.ToArray();
    }
  }
}
