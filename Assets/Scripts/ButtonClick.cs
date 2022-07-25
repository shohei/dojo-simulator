using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.IO;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonHandler()
    {
        // Debug.Log ("hoge");
        ProcessStartInfo processStartInfo = new ProcessStartInfo() {
            FileName = "/Users/shohei/.pyenv/shims/python", //実行するファイル(python)
            UseShellExecute = false,//シェルを使うかどうか
            CreateNoWindow = true, //ウィンドウを開くかどうか
            RedirectStandardOutput = true, //テキスト出力をStandardOutputストリームに書き込むかどうか
            Arguments = "/Users/shohei/ghq/github.com/shohei/dojo-path-planning/planning/planning.py", //実行するスクリプト 引数(複数可)
        };

        //外部プロセスの開始
        Process process = Process.Start(processStartInfo);

        //ストリームから出力を得る
        StreamReader streamReader = process.StandardOutput;
        string str = streamReader.ReadLine();

        //外部プロセスの終了
        process.WaitForExit();
        process.Close();

        //実行
        print(str);    

    }
}
