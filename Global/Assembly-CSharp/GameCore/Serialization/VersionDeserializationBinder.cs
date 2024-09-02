// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.VersionDeserializationBinder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System;
using System.Reflection;
using System.Runtime.Serialization;

#nullable disable
namespace GameCore.Serialization
{
  public sealed class VersionDeserializationBinder : SerializationBinder
  {
    public override Type BindToType(string assemblyName, string typeName)
    {
      if (string.IsNullOrEmpty(assemblyName) || string.IsNullOrEmpty(typeName))
        return (Type) null;
      assemblyName = Assembly.GetExecutingAssembly().FullName;
      return Type.GetType(string.Format("{0}, {1}", (object) typeName, (object) assemblyName));
    }
  }
}
