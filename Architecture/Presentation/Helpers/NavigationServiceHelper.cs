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
        private static MemberInfo[] _memberInfos;

        static NavigationServiceHepler()
        {
            Configurate();
        }

        public static Type GetPageTypeByKey(PageKeys pageKey)
        {
            string pageKeyName = pageKey.ToString();
            var pageMemberInfo = _memberInfos.Single(x => x.Name == pageKeyName);

            return GetTypeByMemberInfo(pageMemberInfo);
        }


        private static void Configurate()
        {
            AppNavigationService = new NavigationService();

            _memberInfos = typeof(PageKeys).GetMembers(BindingFlags.Public | BindingFlags.Static);

            foreach (var memberInfo in _memberInfos)
            {
                string typePath = memberInfo.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
                Type pageType = Type.GetType(typePath);

                AppNavigationService.Configure(memberInfo.Name, pageType);
            }
        }


        private static Type GetTypeByMemberInfo(MemberInfo memberInfo)
        {
            string typePath = memberInfo.CustomAttributes.First().ConstructorArguments.First().Value.ToString();
            return Type.GetType(typePath);
        }

        private static PropertyInfo[] GetProperties<T>()
        {
            return typeof(T).GetProperties();
        }

        public static INavigationService GetService => AppNavigationService;
    }
}
