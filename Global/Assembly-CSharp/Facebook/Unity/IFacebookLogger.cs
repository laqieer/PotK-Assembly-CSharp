// Decompiled with JetBrains decompiler
// Type: Facebook.Unity.IFacebookLogger
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

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
