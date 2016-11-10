using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Architecture.Presentation.Models;

namespace Architecture.Presentation.Helpers
{
    public static class NavigationServiceHepler
    {
        private static NavigationService AppNavigationService;

        static NavigationServiceHepler()
        {
            Configurate();
        }

        private static void Configurate()
        {
            AppNavigationService = new NavigationService();

            var memberInfos = typeof(PageKeys).GetMembers(BindingFlags.Public | BindingFlags.Static);

            foreach (var memberInfo in memberInfos)
            {
                string typePath = memberInfo.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
                Type pageType = Type.GetType(typePath);

                AppNavigationService.Configure(memberInfo.Name, pageType);
            }
        }

        private static PropertyInfo[] GetProperties<T>()
        {
            return typeof(T).GetProperties();
        }

        public static INavigationService GetService => AppNavigationService;
    }
}
