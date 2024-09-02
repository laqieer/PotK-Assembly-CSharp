// Decompiled with JetBrains decompiler
// Type: LitJson.IJsonWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Specialized;

#nullable disable
namespace LitJson
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
