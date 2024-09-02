// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityTypeTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace MasterDataTable
{
  [Serializable]
  public class ActivityTypeTable
  {
    public int ID;
    public string activity_name;
    public int ui_type;
    public int type_parameters;
    public int data;

    public static ActivityTypeTable Parse(MasterDataReader reader)
    {
      return new ActivityTypeTable()
      {
        ID = reader.ReadInt(),
        activity_name = reader.ReadString(true),
        ui_type = reader.ReadInt(),
        type_parameters = reader.ReadInt(),
        data = reader.ReadInt()
      };
    }
  }
}
