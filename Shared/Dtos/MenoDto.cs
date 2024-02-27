using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    //这个Dtos里面的文件目的就是给数据库实体类进行一层封装
    /// <summary>
    /// 备忘录传输实体
    /// </summary>
    public class MemoDto : BaseDto
    {
        private string title;
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }
        private string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }

    }
}
