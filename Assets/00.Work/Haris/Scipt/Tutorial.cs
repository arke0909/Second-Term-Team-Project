using UnityEngine;
using System.IO;

public class Tutorial : MonoBehaviour
{
  private string _strFilePath;

  public string strFileName = "튜토리얼.txt";

  void Awake()
  {
   _strFilePath = Application.dataPath;
  }

  void WriteFile()
  {
   StreamWriter sw = new StreamWriter(_strFilePath + strFileName, true, System.Text.Encoding.Default);

   sw.WriteLine("대강 튜토리얼");  //첫째 라인
   sw.WriteLine("대강 튜토리얼2"); //두번째 라인

   sw.Flush();
   sw.Close();
  }

  void ReadFile()
  {
   string[] text = File.ReadAllLines(_strFilePath + strFileName, System.Text.Encoding.Default); // 파일 읽고 저장
   for (int i = 0; i < text.Length; i++)
    Debug.Log(i + " " + text[i]);
  }
}
