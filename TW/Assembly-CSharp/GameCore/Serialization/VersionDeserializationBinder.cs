// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.VersionDeserializationBinder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
