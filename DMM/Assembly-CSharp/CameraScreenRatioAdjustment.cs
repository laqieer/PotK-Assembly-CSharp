// Decompiled with JetBrains decompiler
// Type: CameraScreenRatioAdjustment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 84692B6C-DF14-44E0-9A18-AFF35C631E79
// Assembly location: F:\rd\usr\lib\DMMPlayer\PoK\PotK_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class CameraScreenRatioAdjustment : MonoBehaviour
{
  [SerializeField]
  private Camera viewCamera;
  [Header("サイズ(間のサイズなら線形補完する)")]
  [SerializeField]
  private CameraScreenRatioAdjustment.ratioData ratioSize;
  [Header("画面サイズが可変した場合、自動で計算しなおすか")]
  [SerializeField]
  private bool isAutoUpdate = true;
  private float adjustSize;
  private float[] ratioTable = new float[4];
  private float[] ratioSizeTable = new float[4];

  private void Awake()
  {
    this.ratioTable[0] = 1.333333f;
    this.ratioTable[1] = 1.777778f;
    this.ratioTable[2] = 2.111111f;
    this.ratioTable[3] = 2.333333f;
    this.ratioSizeTable[0] = this.ratioSize.ratio3_4;
    this.ratioSizeTable[1] = this.ratioSize.ratio9_16;
    this.ratioSizeTable[2] = this.ratioSize.ratio9_19;
    this.ratioSizeTable[3] = this.ratioSize.ratio9_21;
    for (int index = 0; index < this.ratioSizeTable.Length; ++index)
    {
      if (Mathf.Approximately(this.ratioSizeTable[index], 0.0f))
        this.ratioSizeTable[index] = !this.viewCamera.orthographic ? this.viewCamera.fieldOfView : this.viewCamera.orthographicSize;
    }
  }

  private void Start()
  {
    this.adjustSize = this.GetAdjustSize();
    if (Mathf.Approximately(this.adjustSize, 0.0f))
      return;
    this.Adjust(this.adjustSize);
  }

  private void Update()
  {
    if (!this.isAutoUpdate)
      return;
    float adjustSize = this.GetAdjustSize();
    if (Mathf.Approximately(adjustSize, this.adjustSize))
      return;
    this.Adjust(adjustSize);
    this.adjustSize = adjustSize;
  }

  private float GetAdjustSize()
  {
    float a = (float) Screen.height / (float) Screen.width;
    float num = 0.0f;
    if ((double) a <= (double) this.ratioTable[0])
      num = this.ratioSizeTable[0];
    else if (Mathf.Approximately(a, this.ratioTable[1]))
      num = this.ratioSizeTable[1];
    else if (Mathf.Approximately(a, this.ratioTable[2]))
      num = this.ratioSizeTable[2];
    else if ((double) a >= (double) this.ratioTable[3])
      num = this.ratioSizeTable[3];
    else if ((double) a >= (double) this.ratioTable[2] && (double) a <= (double) this.ratioTable[3])
      num = (float) (((double) this.ratioSizeTable[3] - (double) this.ratioSizeTable[2]) * ((double) a - (double) this.ratioTable[2]) / ((double) this.ratioTable[3] - (double) this.ratioTable[2])) + this.ratioSizeTable[2];
    else if ((double) a >= (double) this.ratioTable[1] && (double) a <= (double) this.ratioTable[2])
      num = (float) (((double) this.ratioSizeTable[2] - (double) this.ratioSizeTable[1]) * ((double) a - (double) this.ratioTable[1]) / ((double) this.ratioTable[2] - (double) this.ratioTable[1])) + this.ratioSizeTable[1];
    else if ((double) a >= (double) this.ratioTable[0] && (double) a <= (double) this.ratioTable[1])
      num = (float) (((double) this.ratioSizeTable[1] - (double) this.ratioSizeTable[0]) * ((double) a - (double) this.ratioTable[0]) / ((double) this.ratioTable[1] - (double) this.ratioTable[0])) + this.ratioSizeTable[0];
    return num;
  }

  private void Adjust(float size)
  {
    if ((UnityEngine.Object) this.viewCamera == (UnityEngine.Object) null)
      return;
    if (this.viewCamera.orthographic)
      this.viewCamera.orthographicSize = size;
    else
      this.viewCamera.fieldOfView = size;
  }

  [Serializable]
  public class ratioData
  {
    [Header("画面比率9:21のサイズ")]
    public float ratio9_21;
    [Header("画面比率9:19のサイズ")]
    public float ratio9_19;
    [Header("画面比率9:16のサイズ")]
    public float ratio9_16;
    [Header("画面比率3:4のサイズ")]
    public float ratio3_4;
  }
}
