// Decompiled with JetBrains decompiler
// Type: UIKeyNavigation
// Assembly: Assembly-CSharp-firstpass, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: ECB926DA-6BA5-4E91-81B4-E3750A024FEA
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp-firstpass.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("NGUI/Interaction/Key Navigation")]
public class UIKeyNavigation : MonoBehaviour
{
  public static BetterList<UIKeyNavigation> list = new BetterList<UIKeyNavigation>();
  public UIKeyNavigation.Constraint constraint;
  public GameObject onUp;
  public GameObject onDown;
  public GameObject onLeft;
  public GameObject onRight;
  public GameObject onClick;
  public bool startsSelected;

  protected virtual void OnEnable()
  {
    UIKeyNavigation.list.Add(this);
    if (!this.startsSelected || !Object.op_Equality((Object) UICamera.selectedObject, (Object) null) && NGUITools.GetActive(UICamera.selectedObject))
      return;
    UICamera.currentScheme = UICamera.ControlScheme.Controller;
    UICamera.selectedObject = ((Component) this).gameObject;
  }

  protected virtual void OnDisable() => UIKeyNavigation.list.Remove(this);

  protected GameObject GetLeft()
  {
    if (NGUITools.GetActive(this.onLeft))
      return this.onLeft;
    return this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.left, true);
  }

  private GameObject GetRight()
  {
    if (NGUITools.GetActive(this.onRight))
      return this.onRight;
    return this.constraint == UIKeyNavigation.Constraint.Vertical || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.right, true);
  }

  protected GameObject GetUp()
  {
    if (NGUITools.GetActive(this.onUp))
      return this.onUp;
    return this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.up, false);
  }

  protected GameObject GetDown()
  {
    if (NGUITools.GetActive(this.onDown))
      return this.onDown;
    return this.constraint == UIKeyNavigation.Constraint.Horizontal || this.constraint == UIKeyNavigation.Constraint.Explicit ? (GameObject) null : this.Get(Vector3.down, false);
  }

  protected GameObject Get(Vector3 myDir, bool horizontal)
  {
    Transform transform = ((Component) this).transform;
    myDir = transform.TransformDirection(myDir);
    Vector3 center = UIKeyNavigation.GetCenter(((Component) this).gameObject);
    float num = float.MaxValue;
    GameObject gameObject = (GameObject) null;
    for (int i = 0; i < UIKeyNavigation.list.size; ++i)
    {
      UIKeyNavigation uiKeyNavigation = UIKeyNavigation.list[i];
      if (!Object.op_Equality((Object) uiKeyNavigation, (Object) this))
      {
        Vector3 vector3_1 = Vector3.op_Subtraction(UIKeyNavigation.GetCenter(((Component) uiKeyNavigation).gameObject), center);
        if ((double) Vector3.Dot(myDir, ((Vector3) ref vector3_1).normalized) >= 0.7070000171661377)
        {
          Vector3 vector3_2 = transform.InverseTransformDirection(vector3_1);
          if (horizontal)
            vector3_2.y *= 2f;
          else
            vector3_2.x *= 2f;
          float sqrMagnitude = ((Vector3) ref vector3_2).sqrMagnitude;
          if ((double) sqrMagnitude <= (double) num)
          {
            gameObject = ((Component) uiKeyNavigation).gameObject;
            num = sqrMagnitude;
          }
        }
      }
    }
    return gameObject;
  }

  protected static Vector3 GetCenter(GameObject go)
  {
    UIWidget component = go.GetComponent<UIWidget>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return go.transform.position;
    Vector3[] worldCorners = component.worldCorners;
    return Vector3.op_Multiply(Vector3.op_Addition(worldCorners[0], worldCorners[2]), 0.5f);
  }

  protected virtual void OnKey(KeyCode key)
  {
    if (!NGUITools.GetActive((Behaviour) this))
      return;
    GameObject gameObject = (GameObject) null;
    KeyCode keyCode = key;
    switch (keyCode - 273)
    {
      case 0:
        gameObject = this.GetUp();
        break;
      case 1:
        gameObject = this.GetDown();
        break;
      case 2:
        gameObject = this.GetRight();
        break;
      case 3:
        gameObject = this.GetLeft();
        break;
      default:
        if (keyCode == 9)
        {
          if (Input.GetKey((KeyCode) 304) || Input.GetKey((KeyCode) 303))
          {
            gameObject = this.GetLeft();
            if (Object.op_Equality((Object) gameObject, (Object) null))
              gameObject = this.GetUp();
            if (Object.op_Equality((Object) gameObject, (Object) null))
              gameObject = this.GetDown();
            if (Object.op_Equality((Object) gameObject, (Object) null))
            {
              gameObject = this.GetRight();
              break;
            }
            break;
          }
          gameObject = this.GetRight();
          if (Object.op_Equality((Object) gameObject, (Object) null))
            gameObject = this.GetDown();
          if (Object.op_Equality((Object) gameObject, (Object) null))
            gameObject = this.GetUp();
          if (Object.op_Equality((Object) gameObject, (Object) null))
          {
            gameObject = this.GetLeft();
            break;
          }
          break;
        }
        break;
    }
    if (!Object.op_Inequality((Object) gameObject, (Object) null))
      return;
    UICamera.selectedObject = gameObject;
  }

  protected virtual void OnClick()
  {
    if (!NGUITools.GetActive((Behaviour) this) || !NGUITools.GetActive(this.onClick))
      return;
    UICamera.selectedObject = this.onClick;
  }

  public enum Constraint
  {
    None,
    Vertical,
    Horizontal,
    Explicit,
  }
}
