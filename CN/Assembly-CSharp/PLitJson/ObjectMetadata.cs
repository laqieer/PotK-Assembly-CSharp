// Decompiled with JetBrains decompiler
// Type: PLitJson.ObjectMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace PLitJson
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
