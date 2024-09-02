// Decompiled with JetBrains decompiler
// Type: DamageNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1057B608-EE69-47D4-8399-FD66F6FD63A9
// Assembly location: C:\r\PotK-Assembly-CSharp\TW\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

#nullable disable
public class DamageNumber : MonoBehaviour
{
  public GameObject[] hyaku_num;
  public GameObject[] ju_num;
  public GameObject[] ichi_num;

  private void Start()
  {
  }

  private void Update()
  {
  }

  public void setDamage(int damage)
  {
    this.DisableNumbers();
    if (damage == 0)
      return;
    int[] array = this.numToArray(damage);
    if (array[0] != 0)
      this.EnableKeta(this.hyaku_num, array[0]);
    if (array[0] != 0 || array[1] != 0)
      this.EnableKeta(this.ju_num, array[1]);
    if (array[0] != 0 || array[1] != 0 || array[2] != 0)
      this.EnableKeta(this.ichi_num, array[2]);
    ((Component) this).gameObject.SetActive(true);
    this.StartCoroutine(this.disActiveSelf(2f));
  }

  [DebuggerHidden]
  private IEnumerator disActiveSelf(float duration)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new DamageNumber.\u003CdisActiveSelf\u003Ec__IteratorAD2()
    {
      duration = duration,
      \u003C\u0024\u003Eduration = duration,
      \u003C\u003Ef__this = this
    };
  }

  private void DisableNumbers()
  {
    this.DisableKeta(this.hyaku_num);
    this.DisableKeta(this.ju_num);
    this.DisableKeta(this.ichi_num);
  }

  private void DisableKeta(GameObject[] keta)
  {
    foreach (GameObject gameObject in keta)
    {
      if (Object.op_Inequality((Object) null, (Object) gameObject))
        gameObject.SetActive(false);
    }
  }

  private void EnableKeta(GameObject[] keta, int num)
  {
    this.DisableKeta(keta);
    if (!Object.op_Inequality((Object) null, (Object) keta[num]))
      return;
    keta[num].SetActive(true);
  }

  private int[] numToArray(int num)
  {
    int[] array = new int[3];
    array[0] = num / 100;
    array[1] = (num - array[0] * 100) / 10;
    array[2] = num - array[0] * 100 - array[1] * 10;
    return array;
  }
}
