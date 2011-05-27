//-------------------------------------------------------------------------------
// <copyright file="CustomExtensionWithBehaviorStrategy.cs" company="bbv Software Services AG">
//   Copyright (c) 2008-2011 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace bbv.Common.Bootstrapper.Specification.Dummies
{
    using System.Collections.Generic;

    using bbv.Common.Bootstrapper.Syntax;

    public class CustomExtensionWithBehaviorStrategy : AbstractStrategy<ICustomExtension>
    {
        public int RunConfigurationInitializerAccessCounter
        {
            get;
            private set;
        }

        public int ShutdownConfigurationInitializerAccessCounter
        {
            get;
            private set;
        }

        protected override void DefineRunSyntax(ISyntaxBuilder<ICustomExtension> builder)
        {
            builder
                    .With(new Behavior("run first beginning"))
                    .With(() => new Behavior("run second beginning"))
                .Execute(extension => extension.Start())
                    .With(new Behavior("run first start"))
                    .With(() => new Behavior("run second start"))
                .Execute(this.RunInitializeConfiguration, (extension, dictionary) => extension.Configure(dictionary))
                    .With(dictionary => new BehaviorWithConfigurationContext(dictionary, "RunFirstValue", "RunTestValue"))
                    .With(dictionary => new BehaviorWithConfigurationContext(dictionary, "RunSecondValue", "RunTestValue"))
                .Execute(extension => extension.Initialize())
                    .With(new Behavior("run first initialize"))
                    .With(() => new Behavior("run second initialize"))
                .Execute(() => "RunTest", (extension, context) => extension.Register(context))
                    .With(context => new BehaviorWithStringContext(context, "RunTestValueFirst"))
                    .With(context => new BehaviorWithStringContext(context, "RunTestValueSecond"));
        }

        protected override void DefineShutdownSyntax(ISyntaxBuilder<ICustomExtension> builder)
        {
            builder
                    .With(new Behavior("shutdown first beginning"))
                    .With(() => new Behavior("shutdown second beginning"))
                .Execute(() => "ShutdownTest", (extension, ctx) => extension.Unregister(ctx))
                    .With(context => new BehaviorWithStringContext(context, "ShutdownTestValueFirst"))
                    .With(context => new BehaviorWithStringContext(context, "ShutdownTestValueSecond"))
                .Execute(this.ShutdownInitializeConfiguration, (extension, dictionary) => extension.DeConfigure(dictionary))
                    .With(dictionary => new BehaviorWithConfigurationContext(dictionary, "ShutdownFirstValue", "ShutdownTestValue"))
                    .With(dictionary => new BehaviorWithConfigurationContext(dictionary, "ShutdownSecondValue", "ShutdownTestValue"))
                .Execute(extension => extension.Stop())
                    .With(new Behavior("shutdown first stop"))
                    .With(() => new Behavior("shutdown second stop"));
        }

        private IDictionary<string, string> RunInitializeConfiguration()
        {
            this.RunConfigurationInitializerAccessCounter++;

            return new Dictionary<string, string> { { "RunTest", "RunTestValue" } };
        }

        private IDictionary<string, string> ShutdownInitializeConfiguration()
        {
            this.ShutdownConfigurationInitializerAccessCounter++;

            return new Dictionary<string, string> { { "ShutdownTest", "ShutdownTestValue" } };
        }
    }
}