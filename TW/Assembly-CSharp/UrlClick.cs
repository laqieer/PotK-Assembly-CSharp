// Decompiled with JetBrains decompiler
// Type: UrlClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using gu3.Device;
using UnityEngine;

#nullable disable
public class UrlClick : MonoBehaviour
{
  [SerializeField]
  private UILabel label;

  private void OnClick()
  {
    string urlAtPosition = this.label.GetUrlAtPosition(((RaycastHit) ref UICamera.lastHit).point);
    if (urlAtPosition == null)
      return;
    Debug.Log((object) ("open url " + urlAtPosition));
    DeviceManager.OpenUrl(urlAtPosition);
  }
}
