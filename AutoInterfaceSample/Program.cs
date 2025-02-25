﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace AutoInterfaceSample.Test
{
    public partial record TestRecord(
        [property: BeaKona.AutoInterface(IncludeBaseInterfaces = true)] NLog.ILogger nlog,
    [property: BeaKona.AutoInterface(IncludeBaseInterfaces = true)] Serilog.ILogger slog,
    [property: BeaKona.AutoInterface(IncludeBaseInterfaces = true)] Microsoft.Extensions.Logging.ILogger melog

        ) : NLog.ILogger;

    public class Program
    {
        public static void Main()
        {
            //System.Diagnostics.Debug.WriteLine(BeaKona.Output.Debug_TestRecord.Info);

            //   ITestable p = new TestRecord(new SimpleLogger());

            //  p.Test();

            //p.Log<int?>(LogLevel.Debug, default, 1, null, null);
            //var result = p.BindProperty<int>("test", 1, false, out var property, 1, 2, 3);
        }
    }

    partial record TestObsoleteRecord(
        [property: BeaKona.AutoInterface(IncludeBaseInterfaces = true)]
        ITestInterfaceObsolete Testable) : ITestInterfaceObsolete;
    interface ITestInterfaceObsolete
    {
        [Obsolete]
        [return: System.Diagnostics.CodeAnalysis.MaybeNull]
        [return: NotNullIfNotNullAttribute("test")]
        [return: TestReturnAttribute]
        ResObject? TestObsoleteMethod(string? test);

        [Obsolete]
        [System.Diagnostics.CodeAnalysis.DisallowNull]
        ResObject? TestObsoleteProperty { get; }


    }

    [Obsolete]

    class ResObject;

    [AttributeUsage(AttributeTargets.All)]
    class TestReturnAttribute : Attribute;
}
