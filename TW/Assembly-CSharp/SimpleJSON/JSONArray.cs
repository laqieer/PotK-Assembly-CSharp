// Decompiled with JetBrains decompiler
// Type: SimpleJSON.JSONArray
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

#nullable disable
namespace SimpleJSON
{
  public class JSONArray : JSONNode, IEnumerable
  {
    private List<JSONNode> m_List = new List<JSONNode>();

    public override JSONNode this[int aIndex]
    {
      get
      {
        return aIndex < 0 || aIndex >= this.m_List.Count ? (JSONNode) new JSONLazyCreator((JSONNode) this) : this.m_List[aIndex];
      }
      set
      {
        if (aIndex < 0 || aIndex >= this.m_List.Count)
          this.m_List.Add(value);
        else
          this.m_List[aIndex] = value;
      }
    }

    public override JSONNode this[string aKey]
    {
      get => (JSONNode) new JSONLazyCreator((JSONNode) this);
      set => this.m_List.Add(value);
    }

    public override int Count => this.m_List.Count;

    public override void Add(string aKey, JSONNode aItem) => this.m_List.Add(aItem);

    public override JSONNode Remove(int aIndex)
    {
      if (aIndex < 0 || aIndex >= this.m_List.Count)
        return (JSONNode) null;
      JSONNode jsonNode = this.m_List[aIndex];
      this.m_List.RemoveAt(aIndex);
      return jsonNode;
    }

    public override JSONNode Remove(JSONNode aNode)
    {
      this.m_List.Remove(aNode);
      return aNode;
    }

    public override IEnumerable<JSONNode> Childs
    {
      get
      {
        JSONArray.\u003C\u003Ec__Iterator185 childs = new JSONArray.\u003C\u003Ec__Iterator185()
        {
          \u003C\u003Ef__this = this
        };
        childs.\u0024PC = -2;
        return (IEnumerable<JSONNode>) childs;
      }
    }

    [DebuggerHidden]
    public IEnumerator GetEnumerator()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new JSONArray.\u003CGetEnumerator\u003Ec__Iterator186()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override string ToString()
    {
      string str = "[ ";
      foreach (JSONNode jsonNode in this.m_List)
      {
        if (str.Length > 2)
          str += ", ";
        str += jsonNode.ToString();
      }
      return str + " ]";
    }

    public override string ToString(string aPrefix)
    {
      string str = "[ ";
      foreach (JSONNode jsonNode in this.m_List)
      {
        if (str.Length > 3)
          str += ", ";
        str = str + "\n" + aPrefix + "   ";
        str += jsonNode.ToString(aPrefix + "   ");
      }
      return str + "\n" + aPrefix + "]";
    }

    public override void Serialize(BinaryWriter aWriter)
    {
      aWriter.Write((byte) 1);
      aWriter.Write(this.m_List.Count);
      for (int index = 0; index < this.m_List.Count; ++index)
        this.m_List[index].Serialize(aWriter);
    }
  }
}
