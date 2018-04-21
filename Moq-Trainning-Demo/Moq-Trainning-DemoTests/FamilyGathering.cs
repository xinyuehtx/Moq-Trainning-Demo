#define Scenes3
using System;
using Moq_Trainning_Demo;

namespace Moq_Trainning_DemoTests
{
    public class FamilyGathering
    {
        #region 场景1

#if Scenes1
        public static string SayHi(IMan man, string relativeName)
        {
            Console.WriteLine($"{man.Name},快叫{relativeName}好");

            var result =  man.SayHi(relativeName);

            return result;
        }
#endif

        #endregion


        #region 场景2

#if Scenes2
        public static string AskAge(IMan man)
        {
            Console.WriteLine($"{man},今年多大了");
            var age = man.Age;
            Console.WriteLine($"我今年{age}");
            var result = $"哟，{age}岁了，";
            if (age > 20)
            {
                result += "该去找个对象了吧。";
            }
            else
            {
                result += "几年不见都长这么大了？";
            }

            return result;
        }

        public static string AskChildAge(IMan man)
        {
            var result = FamilyGathering.AskAge(man.Child);

            return result;
        }

        public static void HappyNewYear(IMan man)
        {
            man.Age++;
        }
#endif

        #endregion


        #region 场景3

#if Scenes3
        public static string SayHi(IMan man, string relativeName)
        {
            Console.WriteLine($"{man.Name},快叫{relativeName}好");

            var result =  man.SayHi(relativeName);

            return result;
        }
#endif

        #endregion


    }
}
