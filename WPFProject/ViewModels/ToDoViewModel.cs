using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProject.Common.Models;
using WPFProject.Service;

namespace WPFProject.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        private readonly IToDoService toDoService;
        public ToDoViewModel(IToDoService toDoService)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            AddCommand = new DelegateCommand(Add);
            this.toDoService = toDoService;
            CreateToDoList();
        }


        /// <summary>
        /// 添加待办
        /// </summary>
      
        private void Add()
        {
            IsIsRightDrawerOpens = true;
        }

        public DelegateCommand AddCommand { get; private set; }
        private bool isIsRightDrawerOpens;
        /// <summary>
        /// 右侧新增窗口是否打开
        /// </summary>
        public bool IsIsRightDrawerOpens
        {
            get { return isIsRightDrawerOpens; }
            set { isIsRightDrawerOpens = value; RaisePropertyChanged(); }
        }




        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        private async void CreateToDoList()
        {
            var todoResult = await toDoService.GetAllAsync();

            if (todoResult.Status)
            {
                toDoDtos.Clear();
                foreach (var item in todoResult.Result)
                {
                    toDoDtos.Add(item);
                }
            }
        }

    }
}
