using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static List<Tuple<string, string>> tuples = new List<Tuple<string, string>>();
        void Zapis(CustomFolderInfo item)
        {
            for (int i = 0; i < item.objs.Length; ++i)
            {
                if (item.objs[i].GetType() == typeof(FileInfo))
                {
                    if (item.objs[i].Extension == ".txt")
                    {

                        FileInfo d = (FileInfo)item.objs[i];

                        string line;
                        string s = d.FullName;

                        string res = Path.GetFileName(s);
                        StreamReader file = new StreamReader(s);
                        while ((line = file.ReadLine()) != null)
                        {



                            Tuple<string, string> pair = new Tuple<string, string>(res, line);
                            tuples.Add(pair);


                        }
                    }
                }

                else
                {
                    CustomFolderInfo newItem = item.GetNextItem(i);
                    Zapis(newItem);
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<FileSystemInfo> list = new List<FileSystemInfo>();
            var d = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\pois");
            list.AddRange(d.GetDirectories());
            list.AddRange(d.GetFiles());

            CustomFolderInfo test = new CustomFolderInfo(null, list.ToArray());
            Zapis(test);
            string s = textBox1.Text;
            for (int i = 0; i < tuples.Count; i++)
            {
                string[] ss = tuples[i].Item2.Split(' ');
                for (int j = 0; j < ss.Length; j++)
                {
                    if (ss[j] == s)
                    {

                        ///  textBox2.Text += tuples[i].Item1;
                        listBox1.Items.Add((object)tuples[i].Item1);
                        Refresh();
                    }
                }
            }
        }
    }
}
