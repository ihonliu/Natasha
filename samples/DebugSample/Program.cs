namespace DebugSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Initialize();
                /*
            NatashaManagement
                .GetInitializer()
                .WithMemoryUsing()
                .WithMemoryReference()
                .Preheating<NatashaDomainCreator>();

            AssemblyCSharpBuilder builder = new();
            builder.GetException();
            builder.UseRandomLoadContext();
            builder.UseSmartMode();
            //builder.WithFileOutput();
            builder.WithDebugCompile(debugger => debugger.ForAssembly());
            //builder.WithDebugCompile(debugger=>debugger.ForStandard());
            builder.Add(@"public static class A{ 
public static long Show(int i,short j,double z){  return (long)(i + j + z + 10); } 
public static long Show2(int i,short j,double z){  return (long)(i + j + z + 10); }
public static long Show3(int i,short j,double z){  return (long)(i + j + z + 10); }
public static long Show4(int i,short j,double z){  return (long)(i + j + z + 10); }
}");
            var action = builder
                .GetAssembly()
                .GetDelegateFromShortName<Func<int, short, double, long>>("A", "Show");
            var a = action(1,2,1.2);

            //CS0104Test();
            Console.ReadKey();*/
        }
        public static void Initialize()
        {
            NatashaManagement
                //获取链式构造器
                .GetInitializer()
                //使用引用程序集中的命名空间
                .WithMemoryUsing()
                //使用内存中的元数据
                .WithMemoryReference()
                //注册域构造器
                .Preheating<NatashaDomainCreator>();

            AssemblyCSharpBuilder assemblyCSharp = new();
            try
            {
                assemblyCSharp
                    //使用随即域承载编译内容
                    .UseRandomLoadContext()
                    //不手动管理元数据
                    .UseSmartMode()
                    //使用优化编译
                    .WithReleaseCompile();

                //将编译的日志输出
                assemblyCSharp.LogCompilationEvent += (log) => { Console.WriteLine(log.ToString()); };
                //编译失败处理失败信息
                assemblyCSharp.CompileFailedEvent += (compilation, diagnostics) => { Console.WriteLine("语法通过，编译却失败了，此时你要做什么"); };
                assemblyCSharp.Add("public class A{}");
                assemblyCSharp.Add("public class B{ public static void Show(){ Console.WriteLine(\"Hello World!\"); }}");
                assemblyCSharp.Add("public class C{ public int Sum(int i,int j){return i+j;} }");

                //体验一下语义错误
                //assemblyCSharp.Add("public class D{ public void Sum(int i,int j){return i+j;} }");
                //体验一下语法错误
                //assemblyCSharp.Add("public class E{ public static void Show(){ Console.WriteLine(\"Hello World!\"); }");

                var newAssembly = assemblyCSharp.GetAssembly();
                Console.WriteLine("=====================结    果===========================");
                var hwAction = newAssembly.GetDelegateFromShortName<Action>("B", "Show");
                hwAction();

                var cType = newAssembly.GetType("C");

                var cModel = Activator.CreateInstance(cType!);
                Console.WriteLine(cType!.GetMethod("Sum") != null);

            }
            catch (Exception ex)
            {

                var natashaEx = assemblyCSharp.GetException();
                
                if (natashaEx.ErrorKind == NatashaExceptionKind.Syntax)
                {
                    //输出格式化代码
                    //语法检测未通过，请检查标点符号等低级错误
                    Console.WriteLine(natashaEx!.Formatter);
                    foreach (var item in natashaEx.Diagnostics)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
        }
        public static void CS0104Test()
        {
            AssemblyCSharpBuilder builder = new();
            builder.UseSmartMode();
            builder.AppendExceptUsings("System.IO");
            builder.WithDebugPlusCompile(debugger => debugger.ForStandard());
            builder.Add("public static class A{ public static void Show(int i,int j){ return i+j; } }");
            var action = builder.GetAssembly().GetDelegateFromShortName<Action>("A", "Show");
            action();
        }
    }
}
