// Decompiled with JetBrains decompiler
// Type: HTTP.Headers
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#nullable disable
namespace HTTP
{
  public class Headers
  {
    private static byte[] EOL = new byte[2]
    {
      (byte) 13,
      (byte) 10
    };
    private Dictionary<string, List<string>> headers = new Dictionary<string, List<string>>();

    public void Add(string name, string value) => this.GetAll(name).Add(value);

    public string Get(string name)
    {
      List<string> all = this.GetAll(name);
      return all.Count == 0 ? string.Empty : all[0];
    }

    public bool Contains(string name) => this.GetAll(name).Count != 0;

    public List<string> GetAll(string name)
    {
      foreach (string key in this.headers.Keys)
      {
        if (string.Compare(name, key, true) == 0)
          return this.headers[key];
      }
      List<string> all = new List<string>();
      this.headers.Add(name, all);
      return all;
    }

    public void Set(string name, string value)
    {
      List<string> all = this.GetAll(name);
      all.Clear();
      all.Add(value);
    }

    public void Pop(string name)
    {
      if (!this.headers.ContainsKey(name))
        return;
      this.headers.Remove(name);
    }

    public void Write(BinaryWriter stream)
    {
      foreach (string key in this.headers.Keys)
      {
        foreach (string str in this.headers[key])
        {
          stream.Write(Encoding.ASCII.GetBytes(key + ": " + str));
          stream.Write(Headers.EOL);
        }
      }
    }

    public List<string> Keys => this.headers.Keys.ToList<string>();

    public void Clear() => this.headers.Clear();
  }
}
