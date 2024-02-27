using System.ComponentModel.DataAnnotations;

namespace WpfApi.Models
{
    /// <summary>
    /// 备忘录类
    /// </summary>
    public class Memo : BaseEntity
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
    }
}
