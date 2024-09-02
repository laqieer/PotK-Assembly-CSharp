// Decompiled with JetBrains decompiler
// Type: PLitJson.ObjectMetadata
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
