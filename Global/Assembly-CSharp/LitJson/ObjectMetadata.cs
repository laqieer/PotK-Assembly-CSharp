// Decompiled with JetBrains decompiler
// Type: LitJson.ObjectMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace LitJson
{
  internal struct ObjectMetadata
  {
    private Type element_type;
    private bool is_dictionary;
    private IDictionary<string, PropertyMetadata> properties;

    public Type ElementType
    {
      get => (object) this.element_type == null ? typeof (JsonData) : this.element_type;
      set => this.element_type = value;
    }

    public bool IsDictionary
    {
      get => this.is_dictionary;
      set => this.is_dictionary = value;
    }

    public IDictionary<string, PropertyMetadata> Properties
    {
      get => this.properties;
      set => this.properties = value;
    }
  }
}
