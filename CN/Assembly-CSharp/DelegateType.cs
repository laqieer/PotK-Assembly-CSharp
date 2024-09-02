// Decompiled with JetBrains decompiler
// Type: DelegateType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

#nullable disable
public class DelegateType
{
  public string name;
  public System.Type type;
  public string strType = string.Empty;

  public DelegateType(System.Type t)
  {
    this.type = t;
    this.strType = ToLuaExport.GetTypeStr(t);
    if (t.IsGenericType)
    {
      this.name = ToLuaExport.GetGenericLibName(t);
    }
    else
    {
      this.name = ToLuaExport.GetTypeStr(t);
      this.name = this.name.Replace(".", "_");
    }
  }

  public DelegateType SetName(string str)
  {
    this.name = str;
    return this;
  }
}
