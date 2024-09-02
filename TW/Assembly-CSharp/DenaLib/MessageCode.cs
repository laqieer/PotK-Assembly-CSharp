// Decompiled with JetBrains decompiler
// Type: DenaLib.MessageCode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace DenaLib
{
  public class MessageCode
  {
    public static void Register()
    {
      Singleton<Utlity>.Instance.RegisterMsg(0, "Can not create HotUpdate dir.");
      Singleton<Utlity>.Instance.RegisterMsg(1, "Load update meta file error.");
      Singleton<Utlity>.Instance.RegisterMsg(2, "Save update meta file error.");
      Singleton<Utlity>.Instance.RegisterMsg(3, "Download file fail.");
    }
  }
}
