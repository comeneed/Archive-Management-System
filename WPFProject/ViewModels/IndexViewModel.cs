using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProject.Common.Models;

namespace WPFProject.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();
            CreateTestData();
        }
        /// <summary>
        /// 列表
        /// </summary>
        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        private void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar() { Icon = "ClockFast", Title = "汇总", Content = "27", Color = "#0CA0FF", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "ClockCheckOutLine", Title = "已完成", Content = "24", Color = "#1ECA3A", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "ChartLineVariant", Title = "完成比例", Content = "89%", Color = "#02C6DC", Target = "" });
            TaskBars.Add(new TaskBar() { Icon = "PlaylistStar", Title = "备忘录", Content = "13", Color = "#FFA000", Target = "" });
        }


        /// <summary>
        /// 代办事项
        /// </summary>
        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 备忘录
        /// </summary>
        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }
        private void CreateTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();
            for (int i = 1; i < 15; i++)
            {
                ToDoDtos.Add(new ToDoDto() { Title = "代办" + i, Content = "正在处理中..." });
                MemoDtos.Add(new MemoDto() { Title = "备忘" + i, Content = "我的密码..." });
            }
        }


    }
}
