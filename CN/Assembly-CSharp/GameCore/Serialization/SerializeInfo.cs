// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.SerializeInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections;

#nullable disable
namespace GameCore.Serialization
{
  internal class SerializeInfo
  {
    private Serializer serializer;
    private Deserializer deserializer;
    private TypeObject typeObj;
    private TreeObject treeObj;
    private Type type;

    internal SerializeInfo(
      Serializer serializer,
      Deserializer deserializer,
      TypeObject typeObj,
      TreeObject treeObj,
      Type type)
    {
      this.serializer = serializer;
      this.deserializer = deserializer;
      this.typeObj = typeObj;
      this.treeObj = treeObj;
      this.type = type;
    }

    public void AddProperty(string name, int treeId) => this.treeObj.fields.Add(name, treeId);

    public int GetProperty(string name) => this.treeObj.fields[name];

    public int Serialize(object obj) => this.serializer.Serialize(obj);

    public object Deserialize(int treeId) => this.deserializer.Deserialize(treeId);

    public TypeObject TypeObject => this.typeObj;

    public TreeObject TreeObject => this.treeObj;

    public Type Type => this.type;

    public Type[] GenericArguments => this.type.GetGenericArguments();

    public Array ToArray(Type elementType, object obj)
    {
      int length;
      switch (obj)
      {
        case ICollection collection:
          length = collection.Count;
          break;
        case Array array:
          length = array.Length;
          break;
        default:
          ArrayList arrayList = new ArrayList();
          foreach (object obj1 in (IEnumerable) obj)
            arrayList.Add(obj1);
          obj = (object) arrayList;
          length = arrayList.Count;
          break;
      }
      Array instance = Array.CreateInstance(elementType, length);
      int num = 0;
      foreach (object obj2 in (IEnumerable) obj)
        instance.SetValue(obj2, num++);
      return instance;
    }
  }
}
