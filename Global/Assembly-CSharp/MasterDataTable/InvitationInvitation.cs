// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InvitationInvitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class InvitationInvitation
  {
    public int ID;
    private string _title;
    public string link;
    private string _discription;

    public string title
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._title;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("invitation_InvitationInvitation_title_" + (object) this.ID, out Translation) ? Translation : this._title;
      }
      set => this._title = value;
    }

    public string discription
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._discription;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("invitation_InvitationInvitation_discription_" + (object) this.ID, out Translation) ? Translation : this._discription;
      }
      set => this._discription = value;
    }

    public static InvitationInvitation Parse(MasterDataReader reader)
    {
      return new InvitationInvitation()
      {
        ID = reader.ReadInt(),
        title = reader.ReadString(true),
        link = reader.ReadString(true),
        discription = reader.ReadString(true)
      };
    }
  }
}
