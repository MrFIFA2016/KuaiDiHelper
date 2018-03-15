using KuaiDiHelper.HttpHelper;
using KuaiDiHelper.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace KuaiDiHelper
{
    public partial class FormMain : Form
    {
        private Dictionary<string, string> dictionary = Company.getCompanyDictionary();
        private string path = "Config.ini";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
            if (File.Exists(path))
            {
                string[] arr = File.ReadAllLines(path);
                if (arr != null && arr.Length > 0)
                {
                    foreach (var item in arr)
                    {
                        txtKey.Text = item.ToString();
                        listBox1.Items.Add(item);
                    }
                }
            }
            else
            {
                FileStream stream = new FileStream(path, FileMode.Create);
                StreamWriter writer = new StreamWriter(stream);
                writer.Write("1202528438154");
                writer.Flush();
                writer.Close();
                stream.Close();
                FormMain_Load(null, null);
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
            if (items != null && items.Count == 1)
            {
                MessageBox.Show(items[0].SubItems[0].Text+ items[0].SubItems[1].Text);
            }
        }

        private string Query()
        {
            listView1.Items.Clear();
            string key = dictionary.FirstOrDefault<KeyValuePair<string, string>>(q => (q.Value == cbxComCode.Text)).Key;
            Querier query = JsonToObject<Querier>(getHtml(string.Format("https://www.kuaidi100.com/query?type={0}&postid={1}&id=1", key, listBox1.Text.Trim())));
            if (query.Data != null)
            {
                ImageList list = new ImageList
                {
                    ImageSize = new Size(1, 20)
                };
                listView1.SmallImageList = list;
                foreach (Datum datum in query.Data)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = datum.Time,
                        SubItems = { datum.Context }
                    };
                    listView1.Items.Add(item);
                }
            }
            return query.Message;
        }

        private void cbxComCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = dictionary.FirstOrDefault<KeyValuePair<string, string>>(q => (q.Value == cbxComCode.Text)).Key;
            Querier query = JsonToObject<Querier>(getHtml(string.Format("https://www.kuaidi100.com/query?type={0}&postid={1}&id=1", key, listBox1.Text.Trim())));
            if (Query() != "ok")
                MessageBox.Show("订单号错误，或者快递选择错误！");
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = string.Empty;
            try
            {
                str = getHtml(string.Format("https://www.kuaidi100.com/autonumber/auto?num={0}", listBox1.Text.Trim()));
            }
            catch (Exception)
            {
                throw;
            }
            if (!string.IsNullOrEmpty(str))
            {
                List<AutoNumber> list = JsonToObject<List<AutoNumber>>(str);
                if (list != null)
                {
                    cbxComCode.Items.Clear();
                    foreach (AutoNumber number in list)
                    {
                        string comCode = number.ComCode;
                        if (dictionary.ContainsKey(comCode))
                        {
                            cbxComCode.Items.Add(dictionary[comCode]);
                        }
                        cbxComCode.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("未获取到，有可能是快递100网站打不开！");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("在文本框里输入单号，一行一个，然后在列表框里单击某个单号，即可自动猜测是什么快递，然后在右边显示出来。如果猜测错误的话，请在下拉列表中手动选择快递即可！");
        }


        public static T JsonToObject<T>(string JsonStr)
        {
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<T>(JsonStr);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        private string getHtml(string url)
        {
            Helper helper = new Helper();
            HttpItem item = new HttpItem
            {
                URL = url,
                Method = "get",
                Referer = "https://www.kuaidi100.com/",
                ResultType = ResultType.String
            };
            return helper.GetHtml(item).Html;
        }
        private void 复制本行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = listView1.SelectedItems[0].SubItems[1].Text;
            if (text != string.Empty)
            {
                Clipboard.SetDataObject(text);
            }
            MessageBox.Show("复制成功！");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string[] items = txtKey.Text.Trim().Split(new char[] { '\n' });
            listBox1.Items.AddRange(items);
            if (listBox1.Items.Count > 0)
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            if (checkBox1.Checked)
            {
                SaveDH();
            }
            Query();
        }

        private void SaveDH()
        {
            string DH = "";
            foreach (var item in listBox1.Items)
            {
                DH += item + "\r\n";
            }
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);
            sw.Write(DH);
            sw.Flush();
            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKey.Text = "";
            listView1.Clear();
        }

        private void btn_Auth_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBox1.SelectedItem != null)
                {
                    string DH = listBox1.SelectedItem.ToString();
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    SaveDH();
                }
            }
        }
    }
}
