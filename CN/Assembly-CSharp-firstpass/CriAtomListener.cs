// Decompiled with JetBrains decompiler
// Type: CriAtomListener
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("CRIWARE/CRI Atom Listener")]
public class CriAtomListener : MonoBehaviour
{
  public bool activateListenerOnEnable;
  private Vector3 lastPosition;

  public static CriAtomListener activeListener { get; private set; }

  public static CriAtomEx3dListener sharedNativeListener { get; private set; }

  public static void CreateSharedNativeListener()
  {
    if (CriAtomListener.sharedNativeListener != null)
      return;
    CriAtomListener.sharedNativeListener = new CriAtomEx3dListener();
  }

  public static void DestroySharedNativeListener()
  {
    if (CriAtomListener.sharedNativeListener == null)
      return;
    CriAtomListener.sharedNativeListener.Dispose();
    CriAtomListener.sharedNativeListener = (CriAtomEx3dListener) null;
  }

  private void OnEnable()
  {
    if (!Object.op_Equality((Object) CriAtomListener.activeListener, (Object) null) && !this.activateListenerOnEnable)
      return;
    this.ActivateListener();
  }

  private void OnDisable()
  {
    if (!Object.op_Equality((Object) CriAtomListener.activeListener, (Object) this))
      return;
    if (CriAtomListener.sharedNativeListener != null)
    {
      CriAtomListener.sharedNativeListener.ResetParameters();
      CriAtomListener.sharedNativeListener.Update();
    }
    CriAtomListener.activeListener = (CriAtomListener) null;
  }

  private void LateUpdate()
  {
    if (Object.op_Inequality((Object) CriAtomListener.activeListener, (Object) this))
      return;
    Vector3 position = ((Component) this).transform.position;
    Vector3 vector3 = Vector3.op_Division(Vector3.op_Subtraction(position, this.lastPosition), Time.deltaTime);
    Vector3 forward = ((Component) this).transform.forward;
    Vector3 up = ((Component) this).transform.up;
    this.lastPosition = position;
    if (CriAtomListener.sharedNativeListener == null)
      return;
    CriAtomListener.sharedNativeListener.SetPosition(position.x, position.y, position.z);
    CriAtomListener.sharedNativeListener.SetVelocity(vector3.x, vector3.y, vector3.z);
    CriAtomListener.sharedNativeListener.SetOrientation(forward.x, forward.y, forward.z, up.x, up.y, up.z);
    CriAtomListener.sharedNativeListener.Update();
  }

  public void ActivateListener()
  {
    CriAtomListener.activeListener = this;
    Vector3 position = ((Component) this).transform.position;
    Vector3 forward = ((Component) this).transform.forward;
    Vector3 up = ((Component) this).transform.up;
    this.lastPosition = position;
    if (CriAtomListener.sharedNativeListener == null)
      return;
    CriAtomListener.sharedNativeListener.SetPosition(position.x, position.y, position.z);
    CriAtomListener.sharedNativeListener.SetVelocity(0.0f, 0.0f, 0.0f);
    CriAtomListener.sharedNativeListener.SetOrientation(forward.x, forward.y, forward.z, up.x, up.y, up.z);
    CriAtomListener.sharedNativeListener.Update();
  }
}
