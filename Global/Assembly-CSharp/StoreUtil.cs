// Decompiled with JetBrains decompiler
// Type: StoreUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 501ADDC8-7DC3-4F7C-B343-715E37DE4AA8
// Assembly location: C:\r\PotK-Assembly-CSharp\Global\Assembly-CSharp.dll

using gu3.Device;

#nullable disable
public static class StoreUtil
{
  public static void OpenMyStore() => DeviceManager.OpenStore(DeviceManager.GetBundleIdentifier());
}
