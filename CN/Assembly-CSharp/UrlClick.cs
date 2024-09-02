// Decompiled with JetBrains decompiler
// Type: UrlClick
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using gu3.Device;
using UnityEngine;

#nullable disable
public class UrlClick : MonoBehaviour
{
  private void OnClick()
  {
    string urlAtPosition = ((Component) this).gameObject.GetComponent<UILabel>().GetUrlAtPosition(((RaycastHit) ref UICamera.lastHit).point);
    if (urlAtPosition == null)
      return;
    Debug.Log((object) ("open url " + urlAtPosition));
    DeviceManager.OpenUrl(urlAtPosition);
  }
}
