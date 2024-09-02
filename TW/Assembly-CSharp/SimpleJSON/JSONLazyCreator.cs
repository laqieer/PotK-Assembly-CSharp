// Decompiled with JetBrains decompiler
// Type: SimpleJSON.JSONLazyCreator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace SimpleJSON
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
        JSONArray aVal = new JSONArray();
        aVal.Add(value);
        this.Set((JSONNode) aVal);
      }
    }

    public override JSONNode this[string aKey]
    {
      get => (JSONNode) new JSONLazyCreator((JSONNode) this, aKey);
      set
      {
        this.Set((JSONNode) new JSONClass()
        {
          {
            aKey,
            value
          }
        });
      }
    }

    public override void Add(JSONNode aItem)
    {
      JSONArray aVal = new JSONArray();
      aVal.Add(aItem);
      this.Set((JSONNode) aVal);
    }

    public override void Add(string aKey, JSONNode aItem)
    {
      this.Set((JSONNode) new JSONClass()
      {
        {
          aKey,
          aItem
        }
      });
    }

    public override bool Equals(object obj)
    {
      return obj == null || object.ReferenceEquals((object) this, obj);
    }

    public override int GetHashCode() => base.GetHashCode();

    public override string ToString() => string.Empty;

    public override string ToString(string aPrefix) => string.Empty;

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
        JSONArray aVal = new JSONArray();
        this.Set((JSONNode) aVal);
        return aVal;
      }
    }

    public override JSONClass AsObject
    {
      get
      {
        JSONClass aVal = new JSONClass();
        this.Set((JSONNode) aVal);
        return aVal;
      }
    }

    public static bool operator ==(JSONLazyCreator a, object b)
    {
      return b == null || object.ReferenceEquals((object) a, b);
    }

    public static bool operator !=(JSONLazyCreator a, object b) => !(a == b);
  }
}
