<p align="center">
  <span>中文</span> |  
  <a href="https://github.com/dotnetcore/natasha/tree/main/lang/english">English</a>
</p>
<p align="center"> <span>你们的反馈是我的动力，文档还有很多不足之处；</span> </p>
<p align="center"> <span> 当你看完文档之后仍然不知道如何实现你的需求，您可以查看<a href="https://github.com/dotnetcore/Natasha/blob/main/docs/FAQ.md"> FAQ </a>或者在issue中提出你的需求。</span> </p>
  
<br/>  


# Natasha 
[![Member project of .NET Core Community](https://img.shields.io/badge/member%20project%20of-NCC-9e20c9.svg)](https://github.com/dotnetcore)
[![Gitter](https://badges.gitter.im/dotnetcore/natasha.svg)](https://gitter.im/dotnetcore/Natasha?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
[![Badge](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu/#/zh_CN)
[![GitHub license](https://img.shields.io/github/license/dotnetcore/natasha.svg)](https://github.com/dotnetcore/Natasha/blob/main/LICENSE)
[![wiki](https://img.shields.io/badge/wiki-ch-blue.svg)](https://natasha.dotnetcore.xyz/)
<br/>
![Compile](https://img.shields.io/badge/script-csharp-green.svg)
[![NuGet Badge](https://img.shields.io/nuget/dt/DotNetCore.Natasha.CSharp.Compiler?includePreReleases=true)](https://www.nuget.org/packages/DotNetCore.Natasha.CSharp.Compiler)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/m/dotnetcore/natasha.svg)](https://github.com/dotnetcore/Natasha/commits/main) 
[![Codecov](https://img.shields.io/codecov/c/github/dotnetcore/natasha.svg)](https://codecov.io/gh/dotnetcore/Natasha) 
[![UT Test From PR](https://github.com/dotnetcore/Natasha/actions/workflows/pr_test.yml/badge.svg)](https://github.com/dotnetcore/Natasha/actions/workflows/pr_test.yml)

<br/>
<br/>
&ensp;&ensp;&ensp;&ensp;基于  [Roslyn](https://github.com/dotnet/roslyn)  的 C# 动态程序集构建库，该库允许开发者在运行时使用 C# 代码构建域 / 程序集 / 类 / 结构体 / 枚举 / 接口 / 方法等，使得程序在运行的时候可以增加新的模块及功能。Natasha 集成了域管理/插件管理，可以实现域隔离，域卸载，热拔插等功能。 该库遵循完整的编译流程，提供完整的错误提示， 可自动添加引用，完善的数据结构构建模板让开发者只专注于程序集脚本的编写，兼容 netstandard2.0, 跨平台，统一、简便的链式 API。 且我们会尽快修复您的问题及回复您的 [issue](https://github.com/dotnetcore/Natasha/issues/new) .  [这里有更多的使用文档](https://natasha.dotnetcore.xyz/zh-Hans/docs)

![展示](https://images.gitee.com/uploads/images/2020/1201/161046_e8f52622_1478282.gif)

<br/>

## ClawHub

安装 [Skill](https://clawhub.ai/skills?q=csharp-dotnetcore-natasha)： `npx clawhub install csharp-dotnetcore-natasha`

## 使用

引入包 `DotNetCore.Natasha.CSharp.Compiler` 编译单元主体

<br/>

引入包 `DotNetCore.Natasha.CSharp.Compiler.Domain` 编译域 (netcore3.1+)

#### 初始化（v9）
```cs
NatashaManagement
    //获取链式构造器
    .GetInitializer() 
    //使用引用程序集中的命名空间
    .WithMemoryUsing()
    //使用内存中的元数据
    .WithMemoryReference()
    //注册域构造器
    .Preheating<NatashaDomainCreator>();
```

#### 动态编译
```cs
AssemblyCSharpBuilder assemblyCSharp = new();
assemblyCSharp.ConfigLoadContext(ctx => ctx.AddReferenceAndUsingCode<object>());
assemblyCSharp.Add("public class A{public void Show(){}}");
assemblyCSharp.LogCompilationEvent += (log) => { Console.WriteLine(log.ToString()); };
var newAssembly = assemblyCSharp.GetAssembly();
```
<br/>

## 赞助

关闭打赏

#### 捐助明细  

- L*u 50 元
- 亮 20 元
- 升讯威在线客服系统 5 元
- Json-jh [尊敬的博客园VIP会员] 22 元
- [Newbe俞佬](https://github.com/newbe36524) 90.2 元 
- 崔星星 17 元
- Money 100 元
- [Newbe俞佬](https://github.com/newbe36524) 200 元 
- iNeuOS工业互联网平台 100 元 
- 老萌 30 元
- ****天下 10 元  
- 文航 5 元
- TonyQu 10 元
- Rwing 20 元  

 感谢老铁们的支持，感激不尽 🙏🙏🙏。
  
<br/>  

---------------------  


## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Fdotnetcore%2FNatasha.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Fdotnetcore%2FNatasha?ref=badge_large)          
      

