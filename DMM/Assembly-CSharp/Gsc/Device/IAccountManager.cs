// Decompiled with JetBrains decompiler
// Type: Gsc.Device.IAccountManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

namespace Gsc.Device
{
  public interface IAccountManager
  {
    string GetSecretKey(string name);

    string GetDeviceId(string name);

    void SetKeyPair(string name, string secretKey, string deviceId);

    void SetDeviceId(string name, string deviceId);

    void Remove(string name);
  }
}
