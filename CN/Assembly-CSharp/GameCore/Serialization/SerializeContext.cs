// Decompiled with JetBrains decompiler
// Type: GameCore.Serialization.SerializeContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C8288CC-5112-4EB9-B5CD-8D0227EBD883
// Assembly location: C:\r\PotK-Assembly-CSharp\CN\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UniLinq;

#nullable disable
namespace GameCore.Serialization
{
  public class SerializeContext
  {
    internal Dictionary<object, TypeObject> blobDic = new Dictionary<object, TypeObject>((IEqualityComparer<object>) new BlobEqualityComparer());
    internal int blobCounter = 1;
    internal Dictionary<TreeObject, int> treeDic = new Dictionary<TreeObject, int>();
    internal int treeCounter = 1;
    internal Dictionary<int[], int> internedArrayDic = new Dictionary<int[], int>((IEqualityComparer<int[]>) new IntArrayEqualityComparer());
    internal Dictionary<int, int[]> reverseInternedArrayDic = new Dictionary<int, int[]>();

    public void Clean(int treeId)
    {
      Dictionary<int, TreeObject> treeLookup = new Dictionary<int, TreeObject>();
      foreach (KeyValuePair<TreeObject, int> keyValuePair in this.treeDic)
        treeLookup.Add(keyValuePair.Key.treeId, keyValuePair.Key);
      HashSet<int> usedTree = new HashSet<int>();
      HashSet<int> usedBlob = new HashSet<int>();
      SerializeContext.CleanRec(treeId, (IDictionary<int, TreeObject>) treeLookup, usedTree, usedBlob, (Func<KeyValuePair<string, int>, int[]>) (x => this.reverseInternedArrayDic[x.Value]));
      foreach (TreeObject key in this.treeDic.Keys.ToArray<TreeObject>())
      {
        if (!usedTree.Contains(key.treeId))
          this.treeDic.Remove(key);
      }
      foreach (object key in this.blobDic.Keys.ToArray<object>())
      {
        if (!usedBlob.Contains(this.blobDic[key].objectId))
          this.blobDic.Remove(key);
      }
    }

    internal static void CleanRec(
      int treeId,
      IDictionary<int, TreeObject> treeLookup,
      HashSet<int> usedTree,
      HashSet<int> usedBlob,
      Func<KeyValuePair<string, int>, int[]> getIntArray)
    {
      if (treeId == 0)
        return;
      TreeObject treeObject = treeLookup[treeId];
      usedTree.Add(treeObject.treeId);
      usedBlob.Add(treeObject.objectId);
      foreach (KeyValuePair<string, int> field in treeObject.fields)
      {
        SerializeContext.CleanRec(field.Value, treeLookup, usedTree, usedBlob, getIntArray);
        if (field.Key == "__elems__")
        {
          foreach (int treeId1 in getIntArray(field))
            SerializeContext.CleanRec(treeId1, treeLookup, usedTree, usedBlob, getIntArray);
        }
      }
    }
  }
}
