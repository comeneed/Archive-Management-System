using DryIoc;
using Prism.Container.DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFProject.ServerInfo;
using WPFProject.Service;
using WPFProject.ViewModels;
using WPFProject.Views;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer().Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            //注册默认服务的地址
            containerRegistry.GetContainer().RegisterInstance(@"http://localhost:7054/", serviceKey: "webUrl");
            //注册服务
            containerRegistry.Register<IToDoService, ToDoService>();



            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<MenuView, MenuViewModel>();
            containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
        }

    }
}
