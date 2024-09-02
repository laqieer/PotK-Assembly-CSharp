// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InvitationInvitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class InvitationInvitation
  {
    public int ID;
    public string title;
    public string link;
    public string discription;

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
