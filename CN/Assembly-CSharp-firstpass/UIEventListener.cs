// Decompiled with JetBrains decompiler
// Type: UIEventListener
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FC6F22C0-326E-48ED-B5EE-59590337E752
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
  public object parameter;
  public UIEventListener.VoidDelegate onSubmit;
  public UIEventListener.VoidDelegate onClick;
  public UIEventListener.VoidDelegate onDoubleClick;
  public UIEventListener.BoolDelegate onHover;
  public UIEventListener.BoolDelegate onPress;
  public UIEventListener.BoolDelegate onSelect;
  public UIEventListener.FloatDelegate onScroll;
  public UIEventListener.VectorDelegate onDrag;
  public UIEventListener.ObjectDelegate onDrop;
  public UIEventListener.KeyCodeDelegate onKey;

  private void OnSubmit()
  {
    if (this.onSubmit == null)
      return;
    this.onSubmit(((Component) this).gameObject);
  }

  private void OnClick()
  {
    if (this.onClick == null)
      return;
    this.onClick(((Component) this).gameObject);
  }

  private void OnDoubleClick()
  {
    if (this.onDoubleClick == null)
      return;
    this.onDoubleClick(((Component) this).gameObject);
  }

  private void OnHover(bool isOver)
  {
    if (this.onHover == null)
      return;
    this.onHover(((Component) this).gameObject, isOver);
  }

  private void OnPress(bool isPressed)
  {
    if (this.onPress == null)
      return;
    this.onPress(((Component) this).gameObject, isPressed);
  }

  private void OnSelect(bool selected)
  {
    if (this.onSelect == null)
      return;
    this.onSelect(((Component) this).gameObject, selected);
  }

  private void OnScroll(float delta)
  {
    if (this.onScroll == null)
      return;
    this.onScroll(((Component) this).gameObject, delta);
  }

  private void OnDrag(Vector2 delta)
  {
    if (this.onDrag == null)
      return;
    this.onDrag(((Component) this).gameObject, delta);
  }

  private void OnDrop(GameObject go)
  {
    if (this.onDrop == null)
      return;
    this.onDrop(((Component) this).gameObject, go);
  }

  private void OnKey(KeyCode key)
  {
    if (this.onKey == null)
      return;
    this.onKey(((Component) this).gameObject, key);
  }

  public static UIEventListener Get(GameObject go)
  {
    UIEventListener uiEventListener = go.GetComponent<UIEventListener>();
    if (Object.op_Equality((Object) uiEventListener, (Object) null))
      uiEventListener = go.AddComponent<UIEventListener>();
    return uiEventListener;
  }

  public delegate void VoidDelegate(GameObject go);

  public delegate void BoolDelegate(GameObject go, bool state);

  public delegate void FloatDelegate(GameObject go, float delta);

  public delegate void VectorDelegate(GameObject go, Vector2 delta);

  public delegate void ObjectDelegate(GameObject go, GameObject draggedObject);

  public delegate void KeyCodeDelegate(GameObject go, KeyCode key);
}
