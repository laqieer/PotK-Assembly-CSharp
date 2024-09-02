// Decompiled with JetBrains decompiler
// Type: IconPrefabBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

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
