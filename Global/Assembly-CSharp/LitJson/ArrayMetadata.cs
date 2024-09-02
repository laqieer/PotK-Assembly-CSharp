// Decompiled with JetBrains decompiler
// Type: LitJson.ArrayMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;

#nullable disable
namespace LitJson
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
