using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AddTexture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var texture = ReadTexture("Assets/suzuka.png");
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    Texture ReadTexture(string path)
    {
        byte[] readBinary = ReadFile(path);

        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(readBinary);

        return texture;
    }

    byte[] ReadFile(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fileStream);
        byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();

        return values;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
