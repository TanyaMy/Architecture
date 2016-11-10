using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Architecture.Presentation.Models;

namespace Arcitecture.Presentation.ViewModels.Common
{
    public static class Extensions
    {
        public static void NavigateTo(this INavigationService navigationService, PageKeys pageKey, params object[] parameters)
        {
            navigationService.NavigateTo(pageKey.ToString(), parameters);
        }
    }
}
