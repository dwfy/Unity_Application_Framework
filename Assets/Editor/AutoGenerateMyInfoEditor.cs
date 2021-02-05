using System.IO;
using System;

public class AutoGenerateMyInfoEditor : UnityEditor.AssetModificationProcessor
{
    static void OnWillCreateAsset(string assetName)
    {
        assetName = assetName.Replace(".meta", "");

        if (assetName.EndsWith(".cs"))
        {
            string allText = File.ReadAllText(assetName);

            allText = allText.Replace("#AuthorName", "第五枫咏").
                Replace("#CreateTime",
                DateTime.Now.Year + "/" +
                DateTime.Now.Month + "/" +
                DateTime.Now.Day);

            File.WriteAllText(assetName,allText);
        }
    }

}
