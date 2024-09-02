// Decompiled with JetBrains decompiler
// Type: Gsc.Device.AccountManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using DeviceKit;

namespace Gsc.Device
{
  public class AccountManager : IAccountManager
  {
    private string secretKey;
    private string deviceId;

    public static IAccountManager Create(IAccountManager customManager) => customManager ?? (IAccountManager) new AccountManager();

    public string GetSecretKey(string name)
    {
      if (this.secretKey == null)
        App.GetAuthKeys(out this.secretKey, out this.deviceId, name);
      return this.secretKey;
    }

    public string GetDeviceId(string name)
    {
      if (this.deviceId == null)
        App.GetAuthKeys(out this.secretKey, out this.deviceId, name);
      return this.deviceId;
    }

    public void SetKeyPair(string name, string secretKey, string deviceId)
    {
      App.SetAuthKeys(secretKey, deviceId, name);
      App.GetAuthKeys(out this.secretKey, out this.deviceId, name);
    }

    public void SetDeviceId(string name, string deviceId)
    {
      App.SetAuthKeys(this.secretKey, deviceId, name);
      App.GetAuthKeys(out this.secretKey, out this.deviceId, name);
    }

    public void Remove(string name)
    {
      App.DeleteAuthKeys(name);
      this.secretKey = (string) null;
      this.deviceId = (string) null;
    }
  }
}
