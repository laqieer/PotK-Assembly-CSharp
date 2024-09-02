// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.EasySerializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.IO;
using System.Runtime.Serialization;

#nullable disable
namespace GameCore.Serialization
{
  public class EasySerializer
  {
    public static byte[] SerializeObjectToMemory(object serializableObject)
    {
      EasySerializer.SetEnvironmentVariables();
      System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      binaryFormatter.Binder = (SerializationBinder) new VersionDeserializationBinder();
      using (MemoryStream serializationStream = new MemoryStream())
      {
        binaryFormatter.Serialize((Stream) serializationStream, serializableObject);
        return serializationStream.GetBuffer();
      }
    }

    public static object DeserializeObjectFromMemory(byte[] buf)
    {
      EasySerializer.SetEnvironmentVariables();
      System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      binaryFormatter.Binder = (SerializationBinder) new VersionDeserializationBinder();
      using (Stream serializationStream = (Stream) new MemoryStream(buf))
        return binaryFormatter.Deserialize(serializationStream);
    }

    public static void SerializeObjectToFile(object serializableObject, string filePath)
    {
      EasySerializer.SetEnvironmentVariables();
      System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      binaryFormatter.Binder = (SerializationBinder) new VersionDeserializationBinder();
      using (Stream serializationStream = (Stream) File.Open(filePath, FileMode.Create))
        binaryFormatter.Serialize(serializationStream, serializableObject);
    }

    public static object DeserializeObjectFromFile(string filePath)
    {
      if (!File.Exists(filePath))
        return (object) null;
      EasySerializer.SetEnvironmentVariables();
      System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
      binaryFormatter.Binder = (SerializationBinder) new VersionDeserializationBinder();
      try
      {
        using (Stream serializationStream = (Stream) File.Open(filePath, FileMode.Open))
          return binaryFormatter.Deserialize(serializationStream);
      }
      catch (FileNotFoundException ex)
      {
        return (object) null;
      }
    }

    private static void SetEnvironmentVariables()
    {
      Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
    }
  }
}
