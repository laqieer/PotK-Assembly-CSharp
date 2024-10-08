﻿// Decompiled with JetBrains decompiler
// Type: com.adjust.sdk.JSONLazyCreator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace com.adjust.sdk
{
  internal class JSONLazyCreator : JSONNode
  {
    private JSONNode m_Node;
    private string m_Key;

    public JSONLazyCreator(JSONNode aNode)
    {
      this.m_Node = aNode;
      this.m_Key = (string) null;
    }

    public JSONLazyCreator(JSONNode aNode, string aKey)
    {
      this.m_Node = aNode;
      this.m_Key = aKey;
    }

    private void Set(JSONNode aVal)
    {
      if (this.m_Key == null)
        this.m_Node.Add(aVal);
      else
        this.m_Node.Add(this.m_Key, aVal);
      this.m_Node = (JSONNode) null;
    }

    public override JSONNode this[int aIndex]
    {
      get => (JSONNode) new JSONLazyCreator((JSONNode) this);
      set
      {
        JSONArray jsonArray = new JSONArray();
        jsonArray.Add(value);
        this.Set((JSONNode) jsonArray);
      }
    }

    public override JSONNode this[string aKey]
    {
      get => (JSONNode) new JSONLazyCreator((JSONNode) this, aKey);
      set
      {
        JSONClass jsonClass = new JSONClass();
        jsonClass.Add(aKey, value);
        this.Set((JSONNode) jsonClass);
      }
    }

    public override void Add(JSONNode aItem)
    {
      JSONArray jsonArray = new JSONArray();
      jsonArray.Add(aItem);
      this.Set((JSONNode) jsonArray);
    }

    public override void Add(string aKey, JSONNode aItem)
    {
      JSONClass jsonClass = new JSONClass();
      jsonClass.Add(aKey, aItem);
      this.Set((JSONNode) jsonClass);
    }

    public static bool operator ==(JSONLazyCreator a, object b) => b == null || (object) a == b;

    public static bool operator !=(JSONLazyCreator a, object b) => !(a == b);

    public override bool Equals(object obj) => obj == null || (object) this == obj;

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => "";

    public override string ToString(string aPrefix) => "";

    public override int AsInt
    {
      get
      {
        this.Set((JSONNode) new JSONData(0));
        return 0;
      }
      set => this.Set((JSONNode) new JSONData(value));
    }

    public override float AsFloat
    {
      get
      {
        this.Set((JSONNode) new JSONData(0.0f));
        return 0.0f;
      }
      set => this.Set((JSONNode) new JSONData(value));
    }

    public override double AsDouble
    {
      get
      {
        this.Set((JSONNode) new JSONData(0.0));
        return 0.0;
      }
      set => this.Set((JSONNode) new JSONData(value));
    }

    public override bool AsBool
    {
      get
      {
        this.Set((JSONNode) new JSONData(false));
        return false;
      }
      set => this.Set((JSONNode) new JSONData(value));
    }

    public override JSONArray AsArray
    {
      get
      {
        JSONArray jsonArray = new JSONArray();
        this.Set((JSONNode) jsonArray);
        return jsonArray;
      }
    }

    public override JSONClass AsObject
    {
      get
      {
        JSONClass jsonClass = new JSONClass();
        this.Set((JSONNode) jsonClass);
        return jsonClass;
      }
    }
  }
}
