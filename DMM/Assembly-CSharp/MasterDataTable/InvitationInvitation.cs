﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.InvitationInvitation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class InvitationInvitation
  {
    public int ID;
    public string title;
    public string link;
    public string discription;

    public static InvitationInvitation Parse(MasterDataReader reader) => new InvitationInvitation()
    {
      ID = reader.ReadInt(),
      title = reader.ReadString(true),
      link = reader.ReadString(true),
      discription = reader.ReadString(true)
    };
  }
}
