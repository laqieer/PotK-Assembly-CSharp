// Decompiled with JetBrains decompiler
// Type: IconPrefabBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class IconPrefabBase : MonoBehaviour
{
  public void SetSize(int width, int height)
  {
    UIWidget component = ((Component) this).GetComponent<UIWidget>();
    ((Component) component).transform.localScale = new Vector3((float) width / (float) component.width, (float) height / (float) component.height);
  }

  public void SetBasedOnHeight(int height)
  {
    UIWidget component = ((Component) this).GetComponent<UIWidget>();
    float num = (float) height / (float) component.height;
    ((Component) component).transform.localScale = new Vector3(num, num);
  }

  public void SetBasedOnWidth(int width)
  {
    UIWidget component = ((Component) this).GetComponent<UIWidget>();
    float num = (float) width / (float) component.width;
    ((Component) component).transform.localScale = new Vector3(num, num);
  }
}
