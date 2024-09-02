// Decompiled with JetBrains decompiler
// Type: PLitJson.JsonMapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;

#nullable disable
namespace PLitJson
{
  public class JsonMapper
  {
    private static int max_nesting_depth;
    private static IFormatProvider datetime_format;
    private static IDictionary<Type, ExporterFunc> base_exporters_table;
    private static IDictionary<Type, ExporterFunc> custom_exporters_table;
    private static IDictionary<Type, IDictionary<Type, ImporterFunc>> base_importers_table;
    private static IDictionary<Type, IDictionary<Type, ImporterFunc>> custom_importers_table;
    private static IDictionary<Type, ArrayMetadata> array_metadata;
    private static readonly object array_metadata_lock = new object();
    private static IDictionary<Type, IDictionary<Type, MethodInfo>> conv_ops;
    private static readonly object conv_ops_lock = new object();
    private static IDictionary<Type, ObjectMetadata> object_metadata;
    private static readonly object object_metadata_lock = new object();
    private static IDictionary<Type, IList<PropertyMetadata>> type_properties;
    private static readonly object type_properties_lock = new object();
    private static JsonWriter static_writer;
    private static readonly object static_writer_lock = new object();

    static JsonMapper()
    {
      JsonMapper.max_nesting_depth = 100;
      JsonMapper.array_metadata = (IDictionary<Type, ArrayMetadata>) new Dictionary<Type, ArrayMetadata>();
      JsonMapper.conv_ops = (IDictionary<Type, IDictionary<Type, MethodInfo>>) new Dictionary<Type, IDictionary<Type, MethodInfo>>();
      JsonMapper.object_metadata = (IDictionary<Type, ObjectMetadata>) new Dictionary<Type, ObjectMetadata>();
      JsonMapper.type_properties = (IDictionary<Type, IList<PropertyMetadata>>) new Dictionary<Type, IList<PropertyMetadata>>();
      JsonMapper.static_writer = new JsonWriter();
      JsonMapper.datetime_format = (IFormatProvider) DateTimeFormatInfo.InvariantInfo;
      JsonMapper.base_exporters_table = (IDictionary<Type, ExporterFunc>) new Dictionary<Type, ExporterFunc>();
      JsonMapper.custom_exporters_table = (IDictionary<Type, ExporterFunc>) new Dictionary<Type, ExporterFunc>();
      JsonMapper.base_importers_table = (IDictionary<Type, IDictionary<Type, ImporterFunc>>) new Dictionary<Type, IDictionary<Type, ImporterFunc>>();
      JsonMapper.custom_importers_table = (IDictionary<Type, IDictionary<Type, ImporterFunc>>) new Dictionary<Type, IDictionary<Type, ImporterFunc>>();
      JsonMapper.RegisterBaseExporters();
      JsonMapper.RegisterBaseImporters();
    }

    private static void AddArrayMetadata(Type type)
    {
      if (JsonMapper.array_metadata.ContainsKey(type))
        return;
      ArrayMetadata arrayMetadata = new ArrayMetadata();
      arrayMetadata.IsArray = type.IsArray;
      if ((object) type.GetInterface("System.Collections.IList") != null)
        arrayMetadata.IsList = true;
      foreach (PropertyInfo property in type.GetProperties())
      {
        if (!(property.Name != "Item"))
        {
          ParameterInfo[] indexParameters = property.GetIndexParameters();
          if (indexParameters.Length == 1 && (object) indexParameters[0].ParameterType == (object) typeof (int))
            arrayMetadata.ElementType = property.PropertyType;
        }
      }
      lock (JsonMapper.array_metadata_lock)
      {
        try
        {
          JsonMapper.array_metadata.Add(type, arrayMetadata);
        }
        catch (ArgumentException ex)
        {
        }
      }
    }

    private static void AddObjectMetadata(Type type)
    {
      if (JsonMapper.object_metadata.ContainsKey(type))
        return;
      ObjectMetadata objectMetadata = new ObjectMetadata();
      if ((object) type.GetInterface("System.Collections.IDictionary") != null)
        objectMetadata.IsDictionary = true;
      objectMetadata.Properties = (IDictionary<string, PropertyMetadata>) new Dictionary<string, PropertyMetadata>();
      foreach (PropertyInfo property in type.GetProperties())
      {
        if (property.Name == "Item")
        {
          ParameterInfo[] indexParameters = property.GetIndexParameters();
          if (indexParameters.Length == 1 && (object) indexParameters[0].ParameterType == (object) typeof (string))
            objectMetadata.ElementType = property.PropertyType;
        }
        else
          objectMetadata.Properties.Add(property.Name, new PropertyMetadata()
          {
            Info = (MemberInfo) property,
            Type = property.PropertyType
          });
      }
      foreach (FieldInfo field in type.GetFields())
        objectMetadata.Properties.Add(field.Name, new PropertyMetadata()
        {
          Info = (MemberInfo) field,
          IsField = true,
          Type = field.FieldType
        });
      lock (JsonMapper.object_metadata_lock)
      {
        try
        {
          JsonMapper.object_metadata.Add(type, objectMetadata);
        }
        catch (ArgumentException ex)
        {
        }
      }
    }

    private static void AddTypeProperties(Type type)
    {
      if (JsonMapper.type_properties.ContainsKey(type))
        return;
      IList<PropertyMetadata> propertyMetadataList = (IList<PropertyMetadata>) new List<PropertyMetadata>();
      foreach (PropertyInfo property in type.GetProperties())
      {
        if (!(property.Name == "Item"))
          propertyMetadataList.Add(new PropertyMetadata()
          {
            Info = (MemberInfo) property,
            IsField = false
          });
      }
      foreach (FieldInfo field in type.GetFields())
        propertyMetadataList.Add(new PropertyMetadata()
        {
          Info = (MemberInfo) field,
          IsField = true
        });
      lock (JsonMapper.type_properties_lock)
      {
        try
        {
          JsonMapper.type_properties.Add(type, propertyMetadataList);
        }
        catch (ArgumentException ex)
        {
        }
      }
    }

    private static MethodInfo GetConvOp(Type t1, Type t2)
    {
      lock (JsonMapper.conv_ops_lock)
      {
        if (!JsonMapper.conv_ops.ContainsKey(t1))
          JsonMapper.conv_ops.Add(t1, (IDictionary<Type, MethodInfo>) new Dictionary<Type, MethodInfo>());
      }
      if (JsonMapper.conv_ops[t1].ContainsKey(t2))
        return JsonMapper.conv_ops[t1][t2];
      MethodInfo method = t1.GetMethod("op_Implicit", new Type[1]
      {
        t2
      });
      lock (JsonMapper.conv_ops_lock)
      {
        try
        {
          JsonMapper.conv_ops[t1].Add(t2, method);
        }
        catch (ArgumentException ex)
        {
          return JsonMapper.conv_ops[t1][t2];
        }
      }
      return method;
    }

    private static object ReadValue(Type inst_type, JsonReader reader)
    {
      reader.Read();
      if (reader.Token == JsonToken.ArrayEnd)
        return (object) null;
      if (reader.Token == JsonToken.Null)
      {
        if (!inst_type.IsClass)
          throw new JsonException(string.Format("Can't assign null to an instance of type {0}", (object) inst_type));
        return (object) null;
      }
      if (reader.Token == JsonToken.Double || reader.Token == JsonToken.Int || reader.Token == JsonToken.Long || reader.Token == JsonToken.String || reader.Token == JsonToken.Boolean)
      {
        Type type = reader.Value.GetType();
        if (inst_type.IsAssignableFrom(type))
          return reader.Value;
        if (JsonMapper.custom_importers_table.ContainsKey(type) && JsonMapper.custom_importers_table[type].ContainsKey(inst_type))
          return JsonMapper.custom_importers_table[type][inst_type](reader.Value);
        if (JsonMapper.base_importers_table.ContainsKey(type) && JsonMapper.base_importers_table[type].ContainsKey(inst_type))
          return JsonMapper.base_importers_table[type][inst_type](reader.Value);
        if (inst_type.IsEnum)
          return Enum.ToObject(inst_type, reader.Value);
        MethodInfo convOp = JsonMapper.GetConvOp(inst_type, type);
        if ((object) convOp != null)
          return convOp.Invoke((object) null, new object[1]
          {
            reader.Value
          });
        if ((object) type == (object) typeof (int) && (object) inst_type == (object) typeof (long))
          return reader.Value;
        if ((object) type == (object) typeof (int) || (object) type == (object) typeof (long))
        {
          if ((int) reader.Value == 0)
            return (object) false;
          if ((int) reader.Value == 1)
            return (object) true;
        }
        throw new JsonException(string.Format("Can't assign value '{0}' (type {1}) to type {2}", reader.Value, (object) type, (object) inst_type));
      }
      object obj1 = (object) null;
      if (reader.Token == JsonToken.ArrayStart)
      {
        JsonMapper.AddArrayMetadata(inst_type);
        ArrayMetadata arrayMetadata = JsonMapper.array_metadata[inst_type];
        if (!arrayMetadata.IsArray && !arrayMetadata.IsList)
          throw new JsonException(string.Format("Type {0} can't act as an array", (object) inst_type));
        IList list;
        Type elementType;
        if (!arrayMetadata.IsArray)
        {
          list = (IList) Activator.CreateInstance(inst_type);
          elementType = arrayMetadata.ElementType;
        }
        else
        {
          list = (IList) new ArrayList();
          elementType = inst_type.GetElementType();
        }
        while (true)
        {
          object obj2 = JsonMapper.ReadValue(elementType, reader);
          if (obj2 != null || reader.Token != JsonToken.ArrayEnd)
            list.Add(obj2);
          else
            break;
        }
        if (arrayMetadata.IsArray)
        {
          int count = list.Count;
          obj1 = (object) Array.CreateInstance(elementType, count);
          for (int index = 0; index < count; ++index)
            ((Array) obj1).SetValue(list[index], index);
        }
        else
          obj1 = (object) list;
      }
      else if (reader.Token == JsonToken.ObjectStart)
      {
        JsonMapper.AddObjectMetadata(inst_type);
        ObjectMetadata objectMetadata = JsonMapper.object_metadata[inst_type];
        obj1 = Activator.CreateInstance(inst_type);
        string key;
        while (true)
        {
          reader.Read();
          if (reader.Token != JsonToken.ObjectEnd)
          {
            key = (string) reader.Value;
            if (objectMetadata.Properties.ContainsKey(key))
            {
              PropertyMetadata property = objectMetadata.Properties[key];
              if (property.IsField)
              {
                ((FieldInfo) property.Info).SetValue(obj1, JsonMapper.ReadValue(property.Type, reader));
              }
              else
              {
                PropertyInfo info = (PropertyInfo) property.Info;
                if (info.CanWrite)
                  info.SetValue(obj1, JsonMapper.ReadValue(property.Type, reader), (object[]) null);
                else
                  JsonMapper.ReadValue(property.Type, reader);
              }
            }
            else if (!objectMetadata.IsDictionary)
            {
              if (reader.SkipNonMembers)
                JsonMapper.ReadSkip(reader);
              else
                break;
            }
            else
              ((IDictionary) obj1).Add((object) key, JsonMapper.ReadValue(objectMetadata.ElementType, reader));
          }
          else
            goto label_52;
        }
        throw new JsonException(string.Format("The type {0} doesn't have the property '{1}'", (object) inst_type, (object) key));
      }
label_52:
      return obj1;
    }

    private static IJsonWrapper ReadValue(WrapperFactory factory, JsonReader reader)
    {
      reader.Read();
      if (reader.Token == JsonToken.ArrayEnd || reader.Token == JsonToken.Null)
        return (IJsonWrapper) null;
      IJsonWrapper jsonWrapper1 = factory();
      if (reader.Token == JsonToken.String)
      {
        jsonWrapper1.SetString((string) reader.Value);
        return jsonWrapper1;
      }
      if (reader.Token == JsonToken.Double)
      {
        jsonWrapper1.SetDouble((double) reader.Value);
        return jsonWrapper1;
      }
      if (reader.Token == JsonToken.Int)
      {
        jsonWrapper1.SetInt((int) reader.Value);
        return jsonWrapper1;
      }
      if (reader.Token == JsonToken.Long)
      {
        jsonWrapper1.SetLong((long) reader.Value);
        return jsonWrapper1;
      }
      if (reader.Token == JsonToken.Boolean)
      {
        jsonWrapper1.SetBoolean((bool) reader.Value);
        return jsonWrapper1;
      }
      if (reader.Token == JsonToken.ArrayStart)
      {
        jsonWrapper1.SetJsonType(JsonType.Array);
        while (true)
        {
          IJsonWrapper jsonWrapper2 = JsonMapper.ReadValue(factory, reader);
          if (jsonWrapper2 != null || reader.Token != JsonToken.ArrayEnd)
            jsonWrapper1.Add((object) jsonWrapper2);
          else
            break;
        }
      }
      else if (reader.Token == JsonToken.ObjectStart)
      {
        jsonWrapper1.SetJsonType(JsonType.Object);
        while (true)
        {
          reader.Read();
          if (reader.Token != JsonToken.ObjectEnd)
          {
            string key = (string) reader.Value;
            jsonWrapper1[(object) key] = (object) JsonMapper.ReadValue(factory, reader);
          }
          else
            break;
        }
      }
      return jsonWrapper1;
    }

    private static void ReadSkip(JsonReader reader)
    {
      JsonMapper.ToWrapper((WrapperFactory) (() => (IJsonWrapper) new JsonMockWrapper()), reader);
    }

    private static void RegisterBaseExporters()
    {
      JsonMapper.base_exporters_table[typeof (byte)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToInt32((byte) obj)));
      JsonMapper.base_exporters_table[typeof (char)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToString((char) obj)));
      JsonMapper.base_exporters_table[typeof (DateTime)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToString((DateTime) obj, JsonMapper.datetime_format)));
      JsonMapper.base_exporters_table[typeof (Decimal)] = (ExporterFunc) ((obj, writer) => writer.Write((Decimal) obj));
      JsonMapper.base_exporters_table[typeof (sbyte)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToInt32((sbyte) obj)));
      JsonMapper.base_exporters_table[typeof (short)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToInt32((short) obj)));
      JsonMapper.base_exporters_table[typeof (ushort)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToInt32((ushort) obj)));
      JsonMapper.base_exporters_table[typeof (uint)] = (ExporterFunc) ((obj, writer) => writer.Write(Convert.ToUInt64((uint) obj)));
      JsonMapper.base_exporters_table[typeof (ulong)] = (ExporterFunc) ((obj, writer) => writer.Write((ulong) obj));
    }

    private static void RegisterBaseImporters()
    {
      ImporterFunc importer1 = (ImporterFunc) (input => (object) Convert.ToByte((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (byte), importer1);
      ImporterFunc importer2 = (ImporterFunc) (input => (object) Convert.ToUInt64((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (ulong), importer2);
      ImporterFunc importer3 = (ImporterFunc) (input => (object) Convert.ToSByte((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (sbyte), importer3);
      ImporterFunc importer4 = (ImporterFunc) (input => (object) Convert.ToInt16((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (short), importer4);
      ImporterFunc importer5 = (ImporterFunc) (input => (object) Convert.ToUInt16((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (ushort), importer5);
      ImporterFunc importer6 = (ImporterFunc) (input => (object) Convert.ToUInt32((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (uint), importer6);
      ImporterFunc importer7 = (ImporterFunc) (input => (object) Convert.ToSingle((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (float), importer7);
      ImporterFunc importer8 = (ImporterFunc) (input => (object) Convert.ToDouble((int) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (int), typeof (double), importer8);
      ImporterFunc importer9 = (ImporterFunc) (input => (object) Convert.ToDecimal((double) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (double), typeof (Decimal), importer9);
      ImporterFunc importer10 = (ImporterFunc) (input => (object) Convert.ToUInt32((long) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (long), typeof (uint), importer10);
      ImporterFunc importer11 = (ImporterFunc) (input => (object) Convert.ToChar((string) input));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (string), typeof (char), importer11);
      ImporterFunc importer12 = (ImporterFunc) (input => (object) Convert.ToDateTime((string) input, JsonMapper.datetime_format));
      JsonMapper.RegisterImporter(JsonMapper.base_importers_table, typeof (string), typeof (DateTime), importer12);
    }

    private static void RegisterImporter(
      IDictionary<Type, IDictionary<Type, ImporterFunc>> table,
      Type json_type,
      Type value_type,
      ImporterFunc importer)
    {
      if (!table.ContainsKey(json_type))
        table.Add(json_type, (IDictionary<Type, ImporterFunc>) new Dictionary<Type, ImporterFunc>());
      table[json_type][value_type] = importer;
    }

    private static void WriteValue(
      object obj,
      JsonWriter writer,
      bool writer_is_private,
      int depth)
    {
      if (depth > JsonMapper.max_nesting_depth)
        throw new JsonException(string.Format("Max allowed object depth reached while trying to export from type {0}", (object) obj.GetType()));
      switch (obj)
      {
        case null:
          writer.Write((string) null);
          break;
        case IJsonWrapper _:
          if (writer_is_private)
          {
            writer.TextWriter.Write(((IJsonWrapper) obj).ToJson());
            break;
          }
          ((IJsonWrapper) obj).ToJson(writer);
          break;
        case string _:
          writer.Write((string) obj);
          break;
        case double number1:
          writer.Write(number1);
          break;
        case int number2:
          writer.Write(number2);
          break;
        case bool boolean:
          writer.Write(boolean);
          break;
        case long number3:
          writer.Write(number3);
          break;
        case Array _:
          writer.WriteArrayStart();
          foreach (object obj1 in (Array) obj)
            JsonMapper.WriteValue(obj1, writer, writer_is_private, depth + 1);
          writer.WriteArrayEnd();
          break;
        case IList _:
          writer.WriteArrayStart();
          foreach (object obj2 in (IEnumerable) obj)
            JsonMapper.WriteValue(obj2, writer, writer_is_private, depth + 1);
          writer.WriteArrayEnd();
          break;
        case IDictionary _:
          writer.WriteObjectStart();
          foreach (DictionaryEntry dictionaryEntry in (IDictionary) obj)
          {
            writer.WritePropertyName((string) dictionaryEntry.Key);
            JsonMapper.WriteValue(dictionaryEntry.Value, writer, writer_is_private, depth + 1);
          }
          writer.WriteObjectEnd();
          break;
        default:
          Type type = obj.GetType();
          if (JsonMapper.custom_exporters_table.ContainsKey(type))
          {
            JsonMapper.custom_exporters_table[type](obj, writer);
            break;
          }
          if (JsonMapper.base_exporters_table.ContainsKey(type))
          {
            JsonMapper.base_exporters_table[type](obj, writer);
            break;
          }
          if (obj is Enum)
          {
            Type underlyingType = Enum.GetUnderlyingType(type);
            if ((object) underlyingType == (object) typeof (long) || (object) underlyingType == (object) typeof (uint) || (object) underlyingType == (object) typeof (ulong))
            {
              writer.Write((ulong) obj);
              break;
            }
            writer.Write((int) obj);
            break;
          }
          JsonMapper.AddTypeProperties(type);
          IList<PropertyMetadata> typeProperty = JsonMapper.type_properties[type];
          writer.WriteObjectStart();
          foreach (PropertyMetadata propertyMetadata in (IEnumerable<PropertyMetadata>) typeProperty)
          {
            if (propertyMetadata.IsField)
            {
              if (!((FieldInfo) propertyMetadata.Info).IsStatic)
              {
                writer.WritePropertyName(propertyMetadata.Info.Name);
                JsonMapper.WriteValue(((FieldInfo) propertyMetadata.Info).GetValue(obj), writer, writer_is_private, depth + 1);
              }
            }
            else
            {
              PropertyInfo info = (PropertyInfo) propertyMetadata.Info;
              if (info.CanRead)
              {
                writer.WritePropertyName(propertyMetadata.Info.Name);
                JsonMapper.WriteValue(info.GetValue(obj, (object[]) null), writer, writer_is_private, depth + 1);
              }
            }
          }
          writer.WriteObjectEnd();
          break;
      }
    }

    public static string ToJson(object obj)
    {
      lock (JsonMapper.static_writer_lock)
      {
        JsonMapper.static_writer.Reset();
        JsonMapper.WriteValue(obj, JsonMapper.static_writer, true, 0);
        return JsonMapper.static_writer.ToString();
      }
    }

    public static void ToJson(object obj, JsonWriter writer)
    {
      JsonMapper.WriteValue(obj, writer, false, 0);
    }

    public static JsonData ToObject(JsonReader reader)
    {
      return (JsonData) JsonMapper.ToWrapper((WrapperFactory) (() => (IJsonWrapper) new JsonData()), reader);
    }

    public static JsonData ToObject(TextReader reader)
    {
      return (JsonData) JsonMapper.ToWrapper((WrapperFactory) (() => (IJsonWrapper) new JsonData()), new JsonReader(reader));
    }

    public static JsonData ToObject(string json)
    {
      return (JsonData) JsonMapper.ToWrapper((WrapperFactory) (() => (IJsonWrapper) new JsonData()), json);
    }

    public static T ToObject<T>(JsonReader reader) => (T) JsonMapper.ReadValue(typeof (T), reader);

    public static T ToObject<T>(TextReader reader)
    {
      return (T) JsonMapper.ReadValue(typeof (T), new JsonReader(reader));
    }

    public static T ToObject<T>(string json)
    {
      return (T) JsonMapper.ReadValue(typeof (T), new JsonReader(json));
    }

    public static IJsonWrapper ToWrapper(WrapperFactory factory, JsonReader reader)
    {
      return JsonMapper.ReadValue(factory, reader);
    }

    public static IJsonWrapper ToWrapper(WrapperFactory factory, string json)
    {
      JsonReader reader = new JsonReader(json);
      return JsonMapper.ReadValue(factory, reader);
    }

    public static void RegisterExporter<T>(ExporterFunc<T> exporter)
    {
      ExporterFunc exporterFunc = (ExporterFunc) ((obj, writer) => exporter((T) obj, writer));
      JsonMapper.custom_exporters_table[typeof (T)] = exporterFunc;
    }

    public static void RegisterImporter<TJson, TValue>(ImporterFunc<TJson, TValue> importer)
    {
      ImporterFunc importer1 = (ImporterFunc) (input => (object) importer((TJson) input));
      JsonMapper.RegisterImporter(JsonMapper.custom_importers_table, typeof (TJson), typeof (TValue), importer1);
    }

    public static void UnregisterExporters() => JsonMapper.custom_exporters_table.Clear();

    public static void UnregisterImporters() => JsonMapper.custom_importers_table.Clear();

    public static Type JsonDataToObject<Type>(JsonData jd)
    {
      if (jd == null)
        return default (Type);
      if (!jd.IsObject && !jd.IsArray)
        throw new PLitJsonException("given JsonData must be a JsonObject or JsonArrary, but got '" + (object) jd.GetJsonType() + "', print:'" + JsonMapper.ToString((object) jd) + "'");
      return JsonMapper.ToObject<Type>(JsonMapper.ToJson((object) jd));
    }

    public static JsonData ObjectToJsonData(object obj)
    {
      return obj == null ? (JsonData) null : JsonMapper.ToObject(JsonMapper.ToJson(obj));
    }

    public static string ToString(object obj)
    {
      switch (obj)
      {
        case null:
          return "null";
        case int _:
        case string _:
        case bool _:
        case double _:
        case long _:
          return obj.ToString();
        default:
          return JsonMapper.ToJson(obj);
      }
    }
  }
}
