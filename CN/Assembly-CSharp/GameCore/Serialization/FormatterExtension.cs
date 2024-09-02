// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.FormatterExtension
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System.IO;

#nullable disable
namespace GameCore.Serialization
{
  public static class FormatterExtension
  {
    public static byte[] SerializeToMemory(
      this CrossSerializer serializer,
      object obj,
      SerializeContext context = null)
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        serializer.Serialize(obj, (Stream) memoryStream, context);
        return memoryStream.ToArray();
      }
    }

    public static object DeserializeFromMemory(
      this CrossSerializer serializer,
      byte[] buf,
      DeserializeContext context = null)
    {
      using (MemoryStream memoryStream = new MemoryStream(buf))
        return serializer.Deserialize((Stream) memoryStream, context);
    }
  }
}
