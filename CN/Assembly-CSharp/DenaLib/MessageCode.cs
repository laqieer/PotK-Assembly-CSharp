// Decompiled with JetBrains decompiler
// Type: DenaLib.MessageCode
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
