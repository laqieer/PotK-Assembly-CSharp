// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IFacebookLogger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

#nullable disable
namespace Facebook.Unity
{
  internal interface IFacebookLogger
  {
    void Log(string msg);

    void Info(string msg);

    void Warn(string msg);

    void Error(string msg);
  }
}
