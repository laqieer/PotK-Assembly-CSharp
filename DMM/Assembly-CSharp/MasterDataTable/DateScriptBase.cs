﻿// Decompiled with JetBrains decompiler
// Type: MasterDataTable.DateScriptBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;

namespace MasterDataTable
{
  [Serializable]
  public class DateScriptBase
  {
    public int ID;
    public string script;

    public static DateScriptBase Parse(MasterDataReader reader) => new DateScriptBase()
    {
      ID = reader.ReadInt(),
      script = reader.ReadString(true)
    };
  }
}
