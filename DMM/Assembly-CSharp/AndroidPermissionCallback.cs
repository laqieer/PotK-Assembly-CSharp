// Decompiled with JetBrains decompiler
// Type: AndroidPermissionCallback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AndroidPermissionCallback : AndroidJavaProxy
{
  private event System.Action<string> OnPermissionGrantedAction;

  private event System.Action<string> OnPermissionDeniedAction;

  public AndroidPermissionCallback(
    System.Action<string> onGrantedCallback,
    System.Action<string> onDeniedCallback)
    : base("com.unity3d.plugin.UnityAndroidPermissions$IPermissionRequestResult")
  {
    if (onGrantedCallback != null)
      this.OnPermissionGrantedAction += onGrantedCallback;
    if (onDeniedCallback == null)
      return;
    this.OnPermissionDeniedAction += onDeniedCallback;
  }

  public virtual void OnPermissionGranted(string permissionName)
  {
    if (this.OnPermissionGrantedAction == null)
      return;
    this.OnPermissionGrantedAction(permissionName);
  }

  public virtual void OnPermissionDenied(string permissionName)
  {
    if (this.OnPermissionDeniedAction == null)
      return;
    this.OnPermissionDeniedAction(permissionName);
  }
}
