// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InvitationInvitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
