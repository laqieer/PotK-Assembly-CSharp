// Decompiled with JetBrains decompiler
// Type: GameCore.MicroJSON
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using MiniJSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace GameCore
{
  public class MicroJSON
  {
    private static object ParseMiniJSONValue(object obj, bool toIntern)
    {
      if (obj == null)
        return (object) null;
      if (obj is Dictionary<string, object> dictionary1)
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        foreach (KeyValuePair<string, object> keyValuePair in dictionary1)
        {
          string key = !toIntern ? keyValuePair.Key : string.Intern(keyValuePair.Key);
          dictionary.Add(key, MicroJSON.ParseMiniJSONValue(keyValuePair.Value, toIntern));
        }
        return (object) new AssocList<string, object>((IDictionary<string, object>) dictionary);
      }
      if (obj is List<object> objectList)
      {
        object[] array = objectList.ToArray();
        for (int index = 0; index < array.Length; ++index)
          array[index] = MicroJSON.ParseMiniJSONValue(array[index], toIntern);
        return (object) array;
      }
      if ((object) obj.GetType() == (object) typeof (long))
        return (object) (int) (long) obj;
      if ((object) obj.GetType() == (object) typeof (double))
        return (object) (float) (double) obj;
      return obj is string str ? (!toIntern ? (object) str : (object) string.Intern(str)) : obj;
    }

    public static MicroJSON.IValue FromMiniJSON(object obj, bool toIntern = false)
    {
      return (MicroJSON.IValue) new MicroJSON.Value(MicroJSON.ParseMiniJSONValue(obj, toIntern));
    }

    public interface IValue
    {
      bool IsBoolean { get; }

      bool AsBoolean { get; }

      bool IsInteger { get; }

      int AsInteger { get; }

      bool IsFloat { get; }

      float AsFloat { get; }

      bool IsString { get; }

      string AsString { get; }

      int Length { get; }

      bool IsObject { get; }

      bool ContainsKey(string key);

      MicroJSON.IValue this[string key] { get; }

      IEnumerable<KeyValuePair<string, MicroJSON.IValue>> EnumObject();

      bool IsArray { get; }

      MicroJSON.IValue this[int index] { get; }

      IEnumerable<MicroJSON.IValue> EnumArray();

      string Serialize();
    }

    public class Value : MicroJSON.IValue
    {
      private object value;

      public Value(object value) => this.value = value;

      public bool IsBoolean
      {
        get => this.value != null && (object) this.value.GetType() == (object) typeof (bool);
      }

      public bool AsBoolean => (bool) this.value;

      public bool IsInteger
      {
        get => this.value != null && (object) this.value.GetType() == (object) typeof (int);
      }

      public int AsInteger => (int) this.value;

      public bool IsFloat
      {
        get => this.value != null && (object) this.value.GetType() == (object) typeof (float);
      }

      public float AsFloat => (float) this.value;

      public bool IsString => this.value is string;

      public string AsString => (string) this.value;

      public int Length
      {
        get
        {
          if (this.value is Array array)
            return array.Length;
          return this.value is IDictionary<string, object> dictionary ? dictionary.Count : throw new Exception("value must be object or array");
        }
      }

      public bool IsObject => this.value is IDictionary<string, object>;

      public bool ContainsKey(string key)
      {
        return this.value is IDictionary<string, object> dictionary ? dictionary.ContainsKey(key) : throw new Exception("value must be object");
      }

      public MicroJSON.IValue this[string key]
      {
        get
        {
          return this.value is IDictionary<string, object> dictionary ? (MicroJSON.IValue) new MicroJSON.Value(dictionary[key]) : throw new Exception("value must be object");
        }
      }

      [DebuggerHidden]
      public IEnumerable<KeyValuePair<string, MicroJSON.IValue>> EnumObject()
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MicroJSON.Value.\u003CEnumObject\u003Ec__Iterator34 objectCIterator34 = new MicroJSON.Value.\u003CEnumObject\u003Ec__Iterator34()
        {
          \u003C\u003Ef__this = this
        };
        // ISSUE: reference to a compiler-generated field
        objectCIterator34.\u0024PC = -2;
        return (IEnumerable<KeyValuePair<string, MicroJSON.IValue>>) objectCIterator34;
      }

      public bool IsArray => this.value is Array;

      public MicroJSON.IValue this[int index]
      {
        get
        {
          return this.value is Array array ? (MicroJSON.IValue) new MicroJSON.Value(array.GetValue(index)) : throw new Exception("value must be array");
        }
      }

      [DebuggerHidden]
      public IEnumerable<MicroJSON.IValue> EnumArray()
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        MicroJSON.Value.\u003CEnumArray\u003Ec__Iterator35 arrayCIterator35 = new MicroJSON.Value.\u003CEnumArray\u003Ec__Iterator35()
        {
          \u003C\u003Ef__this = this
        };
        // ISSUE: reference to a compiler-generated field
        arrayCIterator35.\u0024PC = -2;
        return (IEnumerable<MicroJSON.IValue>) arrayCIterator35;
      }

      public string Serialize() => Json.Serialize(this.value);
    }
  }
}
