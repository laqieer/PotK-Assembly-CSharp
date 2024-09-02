// Decompiled with JetBrains decompiler
// Type: MasterDataTable.ActivityTypeTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
