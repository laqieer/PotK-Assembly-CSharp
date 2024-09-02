// Decompiled with JetBrains decompiler
// Type: UnitFamilyOrNull
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MasterDataTable;
using System;

#nullable disable
[Serializable]
public class UnitFamilyOrNull
{
  public bool hasFamily;
  public UnitFamily unitFamily;

  public int GetFamily() => !this.hasFamily ? 999 : (int) this.unitFamily;
}
