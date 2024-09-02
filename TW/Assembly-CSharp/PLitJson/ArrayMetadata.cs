// Decompiled with JetBrains decompiler
// Type: PLitJson.ArrayMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;

#nullable disable
namespace PLitJson
{
  internal struct ArrayMetadata
  {
    private Type element_type;
    private bool is_array;
    private bool is_list;

    public Type ElementType
    {
      get => (object) this.element_type == null ? typeof (JsonData) : this.element_type;
      set => this.element_type = value;
    }

    public bool IsArray
    {
      get => this.is_array;
      set => this.is_array = value;
    }

    public bool IsList
    {
      get => this.is_list;
      set => this.is_list = value;
    }
  }
}
