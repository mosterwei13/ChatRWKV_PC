using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Windows;

namespace ChatRWKV_PC.Utils
{
    public class UpdateUtil
    {
        public async void CheckUpdateVersion(string Name)
        {
            string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            int currentVersionInt = int.Parse(currentVersion.Replace(".", ""));
            try
            {
                using (var client = new HttpClient())
                {

                    var response = await client.GetAsync("https://gitee.com/api/v5/repos/{owner}/{repo}/contents(/{path}?access_token={you_access_token}");

                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        try
                        {
                            JObject obj = (JObject)JsonConvert.DeserializeObject(content);
                            if (obj != null)
                            {

                                string info = Encoding.UTF8.GetString(
                                    Convert.FromBase64String(
                                        obj.GetValue("content").ToString()
                                        )
                                    );
                                info = info.Replace("\n", "");
                                info = info.Replace(" ", "");

                                List<JObject> listObj = JsonConvert.DeserializeObject<List<JObject>>(info);

                                if (listObj != null)
                                {
                                    foreach (JObject softObj in listObj)
                                    {
                                        string softName = softObj.GetValue("Name").ToString();
                                        if (softName.Equals(Name))
                                        {
                                            string lastVersion = softObj.GetValue("LastVersion").ToString();
                                            int lastVersionInt = int.Parse(lastVersion.Replace(".", ""));

                                            if (currentVersionInt >= lastVersionInt)
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                string update = softObj.GetValue("Update").ToString();
                                                string desc = softObj.GetValue("Desc").ToString();
                                                string msg = string.Format("{0}有更新，本窗口只做提示，请自行更新\n版本：{1}->{2}\n更新时间：{3}\n更新说明：\n{4}", Name, currentVersion, lastVersion, update, desc);
                                                MessageBox.Show(msg,"有新版本了！");
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        Console.WriteLine("Error getting file: " + response.ReasonPhrase);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
