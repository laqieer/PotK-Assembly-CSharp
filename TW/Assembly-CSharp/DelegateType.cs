// Decompiled with JetBrains decompiler
// Type: DelegateType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

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
