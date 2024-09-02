// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.VersionDeserializationBinder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
