/// <summary>
/// 待办事项传输实体
/// </summary>
/// 
namespace Shared.Dtos
{
    public class TodoDto : BaseDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 状态
        /// </summary>
        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged(); }
        }

    }
}