// Decompiled with JetBrains decompiler
// Type: PLitJson.IJsonWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Specialized;

#nullable disable
namespace PLitJson
{
  public interface IJsonWrapper : IList, ICollection, IDictionary, IEnumerable, IOrderedDictionary
  {
    bool IsArray { get; }

    bool IsBoolean { get; }

    bool IsDouble { get; }

    bool IsInt { get; }

    bool IsLong { get; }

    bool IsObject { get; }

    bool IsString { get; }

    bool GetBoolean();

    double GetDouble();

    int GetInt();

    JsonType GetJsonType();

    long GetLong();

    string GetString();

    void SetBoolean(bool val);

    void SetDouble(double val);

    void SetInt(int val);

    void SetJsonType(JsonType type);

    void SetLong(long val);

    void SetString(string val);

    string ToJson();

    void ToJson(JsonWriter writer);
  }
}
