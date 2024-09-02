// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.CrossSerializer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace GameCore.Serialization
{
  public class CrossSerializer
  {
    private Dictionary<GameCore.TypeInfo, System.Type> typeBindCache = new Dictionary<GameCore.TypeInfo, System.Type>();
    public Func<GameCore.TypeInfo, System.Type> TypeBinder;
    public ICrossFormatter Formatter;

    public CrossSerializer()
    {
    }

    public CrossSerializer(ICrossFormatter formatter) => this.Formatter = formatter;

    static CrossSerializer()
    {
      CrossSerializer.Specialized.Register(typeof (bool), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((bool) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetBool()));
      CrossSerializer.Specialized.Register(typeof (sbyte), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((sbyte) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetSByte()));
      CrossSerializer.Specialized.Register(typeof (short), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((short) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetShort()));
      CrossSerializer.Specialized.Register(typeof (int), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((int) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetInt()));
      CrossSerializer.Specialized.Register(typeof (long), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((long) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetLong()));
      CrossSerializer.Specialized.Register(typeof (byte), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((byte) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetByte()));
      CrossSerializer.Specialized.Register(typeof (ushort), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((ushort) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetUShort()));
      CrossSerializer.Specialized.Register(typeof (uint), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((uint) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetUInt()));
      CrossSerializer.Specialized.Register(typeof (ulong), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((ulong) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetULong()));
      CrossSerializer.Specialized.Register(typeof (char), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((char) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetChar()));
      CrossSerializer.Specialized.Register(typeof (float), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((float) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetFloat()));
      CrossSerializer.Specialized.Register(typeof (double), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((double) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetDouble()));
      CrossSerializer.Specialized.Register(typeof (string), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set((string) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetString()));
      CrossSerializer.Specialized.Register(typeof (bool[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((bool[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetBoolArray()));
      CrossSerializer.Specialized.Register(typeof (sbyte[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((sbyte[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetSByteArray()));
      CrossSerializer.Specialized.Register(typeof (short[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((short[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetShortArray()));
      CrossSerializer.Specialized.Register(typeof (int[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((int[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetIntArray()));
      CrossSerializer.Specialized.Register(typeof (long[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((long[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetLongArray()));
      CrossSerializer.Specialized.Register(typeof (byte[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((byte[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetByteArray()));
      CrossSerializer.Specialized.Register(typeof (ushort[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((ushort[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetUShortArray()));
      CrossSerializer.Specialized.Register(typeof (uint[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((uint[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetUIntArray()));
      CrossSerializer.Specialized.Register(typeof (ulong[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((ulong[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetULongArray()));
      CrossSerializer.Specialized.Register(typeof (char[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((char[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetCharArray()));
      CrossSerializer.Specialized.Register(typeof (float[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((float[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetFloatArray()));
      CrossSerializer.Specialized.Register(typeof (double[]), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray((double[]) obj)), (Func<SerializeInfo, object>) (info => (object) info.TypeObject.GetDoubleArray()));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<bool>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<bool>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<bool>)
          }).Invoke(obj, (object[]) new bool[1][]
          {
            info.TypeObject.GetBoolArray()
          });
        }
        else
        {
          ((List<bool>) obj).Clear();
          ((List<bool>) obj).AddRange((IEnumerable<bool>) info.TypeObject.GetBoolArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<sbyte>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<sbyte>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<sbyte>)
          }).Invoke(obj, (object[]) new sbyte[1][]
          {
            info.TypeObject.GetSByteArray()
          });
        }
        else
        {
          ((List<sbyte>) obj).Clear();
          ((List<sbyte>) obj).AddRange((IEnumerable<sbyte>) info.TypeObject.GetSByteArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<short>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<short>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<short>)
          }).Invoke(obj, (object[]) new short[1][]
          {
            info.TypeObject.GetShortArray()
          });
        }
        else
        {
          ((List<short>) obj).Clear();
          ((List<short>) obj).AddRange((IEnumerable<short>) info.TypeObject.GetShortArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<int>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<int>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<int>)
          }).Invoke(obj, (object[]) new int[1][]
          {
            info.TypeObject.GetIntArray()
          });
        }
        else
        {
          ((List<int>) obj).Clear();
          ((List<int>) obj).AddRange((IEnumerable<int>) info.TypeObject.GetIntArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<long>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<long>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<long>)
          }).Invoke(obj, (object[]) new long[1][]
          {
            info.TypeObject.GetLongArray()
          });
        }
        else
        {
          ((List<long>) obj).Clear();
          ((List<long>) obj).AddRange((IEnumerable<long>) info.TypeObject.GetLongArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<byte>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<byte>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<byte>)
          }).Invoke(obj, (object[]) new byte[1][]
          {
            info.TypeObject.GetByteArray()
          });
        }
        else
        {
          ((List<byte>) obj).Clear();
          ((List<byte>) obj).AddRange((IEnumerable<byte>) info.TypeObject.GetByteArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<ushort>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<ushort>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<ushort>)
          }).Invoke(obj, (object[]) new ushort[1][]
          {
            info.TypeObject.GetUShortArray()
          });
        }
        else
        {
          ((List<ushort>) obj).Clear();
          ((List<ushort>) obj).AddRange((IEnumerable<ushort>) info.TypeObject.GetUShortArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<uint>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<uint>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<uint>)
          }).Invoke(obj, (object[]) new uint[1][]
          {
            info.TypeObject.GetUIntArray()
          });
        }
        else
        {
          ((List<uint>) obj).Clear();
          ((List<uint>) obj).AddRange((IEnumerable<uint>) info.TypeObject.GetUIntArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<ulong>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<ulong>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<ulong>)
          }).Invoke(obj, (object[]) new ulong[1][]
          {
            info.TypeObject.GetULongArray()
          });
        }
        else
        {
          ((List<ulong>) obj).Clear();
          ((List<ulong>) obj).AddRange((IEnumerable<ulong>) info.TypeObject.GetULongArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<char>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<char>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<char>)
          }).Invoke(obj, (object[]) new char[1][]
          {
            info.TypeObject.GetCharArray()
          });
        }
        else
        {
          ((List<char>) obj).Clear();
          ((List<char>) obj).AddRange((IEnumerable<char>) info.TypeObject.GetCharArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<float>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<float>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<float>)
          }).Invoke(obj, (object[]) new float[1][]
          {
            info.TypeObject.GetFloatArray()
          });
        }
        else
        {
          ((List<float>) obj).Clear();
          ((List<float>) obj).AddRange((IEnumerable<float>) info.TypeObject.GetFloatArray());
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<double>), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.SetArray(((List<double>) obj).ToArray())), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<double>)
          }).Invoke(obj, (object[]) new double[1][]
          {
            info.TypeObject.GetDoubleArray()
          });
        }
        else
        {
          ((List<double>) obj).Clear();
          ((List<double>) obj).AddRange((IEnumerable<double>) info.TypeObject.GetDoubleArray());
        }
      }));
      CrossSerializer.Specialized.Register(typeof (DateTime), (System.Action<SerializeInfo, object>) ((info, obj) => info.TypeObject.Set(((DateTime) obj).ToBinary())), (Func<SerializeInfo, object>) (info => (object) DateTime.FromBinary(info.TypeObject.GetLong())));
      CrossSerializer.Specialized.RegisterMutable(typeof (List<>), (System.Action<SerializeInfo, object>) ((info, obj) =>
      {
        object obj1 = info.Type.GetMethod("ToArray").Invoke(obj, (object[]) null);
        info.AddProperty("elems", info.Serialize(obj1));
      }), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        object obj1 = info.Deserialize(info.GetProperty("elems"));
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<>).MakeGenericType(info.GenericArguments[0])
          }).Invoke(obj, new object[1]{ obj1 });
        }
        else
        {
          info.Type.GetMethod("Clear").Invoke(obj, (object[]) null);
          info.Type.GetMethod("AddRange").Invoke(obj, new object[1]
          {
            obj1
          });
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (Dictionary<,>), (System.Action<SerializeInfo, object>) ((info, obj) =>
      {
        System.Type type1 = info.Type;
        System.Type[] genericArguments = info.GenericArguments;
        int length = (int) type1.GetProperty("Count").GetGetMethod().Invoke(obj, (object[]) null);
        Array instance1 = Array.CreateInstance(genericArguments[0], length);
        Array instance2 = Array.CreateInstance(genericArguments[1], length);
        int index = 0;
        System.Type type2 = typeof (KeyValuePair<,>).MakeGenericType(genericArguments);
        PropertyInfo property1 = type2.GetProperty("Key");
        PropertyInfo property2 = type2.GetProperty("Value");
        foreach (object obj1 in (IEnumerable) obj)
        {
          instance1.SetValue(property1.GetGetMethod().Invoke(obj1, (object[]) null), index);
          instance2.SetValue(property2.GetGetMethod().Invoke(obj1, (object[]) null), index);
          ++index;
        }
        info.AddProperty("keys", info.Serialize((object) instance1));
        info.AddProperty("values", info.Serialize((object) instance2));
      }), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        Array array1 = (Array) info.Deserialize(info.GetProperty("keys"));
        Array array2 = (Array) info.Deserialize(info.GetProperty("values"));
        System.Type type = info.Type;
        if (isNew)
          type.GetConstructor(System.Type.EmptyTypes).Invoke(obj, (object[]) null);
        else
          type.GetMethod("Clear").Invoke(obj, (object[]) null);
        MethodInfo method = type.GetMethod("Add");
        object[] parameters = new object[2];
        for (int index = 0; index < array1.Length; ++index)
        {
          parameters[0] = array1.GetValue(index);
          parameters[1] = array2.GetValue(index);
          method.Invoke(obj, parameters);
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (Queue<>), (System.Action<SerializeInfo, object>) ((info, obj) =>
      {
        object obj1 = info.Type.GetMethod("ToArray").Invoke(obj, (object[]) null);
        info.AddProperty("elems", info.Serialize(obj1));
      }), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        Array array = (Array) info.Deserialize(info.GetProperty("elems"));
        if (isNew)
        {
          info.Type.GetConstructor(new System.Type[1]
          {
            typeof (IEnumerable<>).MakeGenericType(info.GenericArguments[0])
          }).Invoke(obj, (object[]) new Array[1]{ array });
        }
        else
        {
          info.Type.GetMethod("Clear").Invoke(obj, (object[]) null);
          MethodInfo method = info.Type.GetMethod("Enqueue");
          foreach (object obj1 in array)
            method.Invoke(obj, new object[1]{ obj1 });
        }
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (Tuple<>), (System.Action<SerializeInfo, object>) ((info, obj) => info.AddProperty("Item1", info.Serialize(info.Type.GetProperty("Item1").GetGetMethod().Invoke(obj, (object[]) null)))), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (!isNew)
          return;
        object obj1 = info.Deserialize(info.GetProperty("Item1"));
        info.Type.GetConstructor(info.GenericArguments).Invoke(obj, new object[1]
        {
          obj1
        });
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (Tuple<,>), (System.Action<SerializeInfo, object>) ((info, obj) =>
      {
        info.AddProperty("Item1", info.Serialize(info.Type.GetProperty("Item1").GetGetMethod().Invoke(obj, (object[]) null)));
        info.AddProperty("Item2", info.Serialize(info.Type.GetProperty("Item2").GetGetMethod().Invoke(obj, (object[]) null)));
      }), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (!isNew)
          return;
        object obj1 = info.Deserialize(info.GetProperty("Item1"));
        object obj2 = info.Deserialize(info.GetProperty("Item2"));
        info.Type.GetConstructor(info.GenericArguments).Invoke(obj, new object[2]
        {
          obj1,
          obj2
        });
      }));
      CrossSerializer.Specialized.RegisterMutable(typeof (Tuple<,,>), (System.Action<SerializeInfo, object>) ((info, obj) =>
      {
        info.AddProperty("Item1", info.Serialize(info.Type.GetProperty("Item1").GetGetMethod().Invoke(obj, (object[]) null)));
        info.AddProperty("Item2", info.Serialize(info.Type.GetProperty("Item2").GetGetMethod().Invoke(obj, (object[]) null)));
        info.AddProperty("Item3", info.Serialize(info.Type.GetProperty("Item3").GetGetMethod().Invoke(obj, (object[]) null)));
      }), (System.Action<SerializeInfo, object, bool>) ((info, obj, isNew) =>
      {
        if (!isNew)
          return;
        object obj1 = info.Deserialize(info.GetProperty("Item1"));
        object obj2 = info.Deserialize(info.GetProperty("Item2"));
        object obj3 = info.Deserialize(info.GetProperty("Item3"));
        info.Type.GetConstructor(info.GenericArguments).Invoke(obj, new object[3]
        {
          obj1,
          obj2,
          obj3
        });
      }));
    }

    internal static void RemoveAssemblyDetails(GameCore.TypeInfo typeInfo)
    {
      if (typeInfo.assembly != null)
      {
        typeInfo.assembly.culture = (string) null;
        typeInfo.assembly.version = (string) null;
        typeInfo.assembly.public_key_token = (string) null;
      }
      foreach (GameCore.TypeInfo typeArgument in typeInfo.type_arguments)
        CrossSerializer.RemoveAssemblyDetails(typeArgument);
    }

    internal System.Type BindToType(GameCore.TypeInfo typeInfo)
    {
      System.Type type1;
      if (this.typeBindCache.TryGetValue(typeInfo, out type1))
        return type1;
      System.Type type2 = this.TypeBinder != null ? this.TypeBinder(typeInfo) : typeInfo.Type;
      Debug.Log((object) "TypeInfo: {0}, result: {1}".F((object) typeInfo, (object) type2));
      this.typeBindCache.Add(typeInfo, type2);
      return type2;
    }

    public void Serialize(object obj, Stream stream, SerializeContext context = null)
    {
      if (context == null)
        context = new SerializeContext();
      Serializer serializer = new Serializer(this, context);
      int rootId = serializer.Serialize(obj);
      Tuple<TypeObject[], TreeObject[]> result = serializer.GetResult();
      this.Formatter.Save(rootId, result.Item1, result.Item2, stream);
    }

    public object Deserialize(Stream stream, DeserializeContext context = null)
    {
      if (context == null)
        context = new DeserializeContext();
      int rootId;
      TypeObject[] objects;
      TreeObject[] trees;
      this.Formatter.Load(stream, out rootId, out objects, out trees);
      return new Deserializer(this, context, objects, trees).Deserialize(rootId);
    }

    internal static class Specialized
    {
      private static Dictionary<System.Type, CrossSerializer.Specialized.Value> info = new Dictionary<System.Type, CrossSerializer.Specialized.Value>();
      private static Dictionary<System.Type, CrossSerializer.Specialized.ValueM> infoM = new Dictionary<System.Type, CrossSerializer.Specialized.ValueM>();

      public static void Register(
        System.Type type,
        System.Action<SerializeInfo, object> serialize,
        Func<SerializeInfo, object> deserialize)
      {
        CrossSerializer.Specialized.info.Add(type, new CrossSerializer.Specialized.Value()
        {
          Serialize = serialize,
          Deserialize = deserialize
        });
      }

      public static bool TryGetValue(System.Type type, out CrossSerializer.Specialized.Value value) => CrossSerializer.Specialized.info.TryGetValue(type, out value);

      public static void RegisterMutable(
        System.Type type,
        System.Action<SerializeInfo, object> serialize,
        System.Action<SerializeInfo, object, bool> deserialize)
      {
        CrossSerializer.Specialized.infoM.Add(type, new CrossSerializer.Specialized.ValueM()
        {
          Serialize = serialize,
          DeserializeM = deserialize
        });
      }

      public static bool TryGetValueMutable(System.Type type, out CrossSerializer.Specialized.ValueM value) => CrossSerializer.Specialized.infoM.TryGetValue(type, out value);

      public class Value
      {
        public System.Action<SerializeInfo, object> Serialize;
        public Func<SerializeInfo, object> Deserialize;
      }

      public class ValueM
      {
        public System.Action<SerializeInfo, object> Serialize;
        public System.Action<SerializeInfo, object, bool> DeserializeM;
      }
    }
  }
}
