// Decompiled with JetBrains decompiler
// Type: MasterDataTable.LoginbonusLoginbonus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using I2.Loc;
using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class LoginbonusLoginbonus
  {
    public int ID;
    private string _name;
    public bool is_loop;
    public int draw_type_LoginbonusDrawType;
    public bool require_continue_login;
    public DateTime? start_at;
    public DateTime? end_at;
    public int draw_reward_num;

    public string name
    {
      get
      {
        if (!LocalizationPreset.Instance.EnableLocalization)
          return this._name;
        string Translation = string.Empty;
        return LocalizationManager.TryGetTermTranslation("loginbonus_LoginbonusLoginbonus_name_" + (object) this.ID, out Translation) ? Translation : this._name;
      }
      set => this._name = value;
    }

    public static LoginbonusLoginbonus Parse(MasterDataReader reader)
    {
      return new LoginbonusLoginbonus()
      {
        ID = reader.ReadInt(),
        name = reader.ReadString(true),
        is_loop = reader.ReadBool(),
        draw_type_LoginbonusDrawType = reader.ReadInt(),
        require_continue_login = reader.ReadBool(),
        start_at = reader.ReadDateTimeOrNull(),
        end_at = reader.ReadDateTimeOrNull(),
        draw_reward_num = reader.ReadInt()
      };
    }

    public LoginbonusDrawType draw_type => (LoginbonusDrawType) this.draw_type_LoginbonusDrawType;
  }
}
