using System.ComponentModel.DataAnnotations;

namespace WpfApi.Models
{
    /// <summary>
    /// 待办事项类
    /// </summary>
    public class ToDo : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(50)]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [MaxLength(500)]
        public string Content { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
    }
}
