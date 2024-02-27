using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Common.Models
{
    /// <summary>
    /// 代办事项类
    /// </summary>
    public class ToDoDto : BaseDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
