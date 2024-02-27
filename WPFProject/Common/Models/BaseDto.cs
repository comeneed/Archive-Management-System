using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.Common.Models
{
    /// <summary>
	/// 基础类
	/// </summary>
    public class BaseDto
    {
        /// <summary>
        /// Id
        /// </summary>
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createDate;

        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        private DateTime updateDate;

        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }

    }
}
