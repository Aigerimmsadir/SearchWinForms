using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWinForms
{

    class CustomFolderInfo
    {
        public CustomFolderInfo prev;
        public FileSystemInfo[] objs;

        public CustomFolderInfo(CustomFolderInfo prev, FileSystemInfo[] list)
        {
            this.prev = prev;
            this.objs = list;
        }

        public CustomFolderInfo GetNextItem(int k)
        {
            FileSystemInfo active = objs[k];
            List<FileSystemInfo> list = new List<FileSystemInfo>();
            DirectoryInfo d = active as DirectoryInfo;
            list.AddRange(d.GetDirectories());
            list.AddRange(d.GetFiles());
            CustomFolderInfo x = new CustomFolderInfo(this, list.ToArray());
            return x;
        }


    }
}