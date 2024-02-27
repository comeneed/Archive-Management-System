using Prism.Commands;
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
    class MenuViewModel : BindableBase
    {
        public MenuViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            CreateMemoList();
            AddCommand = new DelegateCommand(Add);
        }

        private void Add()
        {
            IsIsRightDrawerOpens = true;
        }

        public DelegateCommand AddCommand { get; private set; }
        private bool isIsRightDrawerOpens;

        public bool IsIsRightDrawerOpens
        {
            get { return isIsRightDrawerOpens; }
            set { isIsRightDrawerOpens = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }
        private void CreateMemoList()
        {
            for (int i = 1; i < 36; i++)
            {
                MemoDtos.Add(new MemoDto()
                {
                    Title = "备忘录" + i,
                    Content = "我的密码是..."
                });
            }

        }
    }
}
