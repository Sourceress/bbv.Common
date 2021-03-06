//-------------------------------------------------------------------------------
// <copyright file="SyntaxTest.cs" company="bbv Software Services AG">
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

namespace bbv.Common.StateMachine.Internals
{
    using System;

    using Xunit;

    /// <summary>
    /// Tests the syntax.
    /// </summary>
    public class SyntaxTest
    {
        /// <summary>
        /// Simple check whether all possible cases can be defined with the syntax (not an actual test really).
        /// </summary>
        [Fact]
        public void Syntax()
        {
            IEntryActionSyntax<int, int> s = null;

            Action a = () =>
                {
                    s
                        .ExecuteOnEntry(() => { })
                        .ExecuteOnExit(() => { })
                        .On(3)
                            .If(v => true).Goto(4).Execute(() => { })
                            .If(v => true).Goto(4)
                            .If(v => true).Execute(() => { })
                            .Otherwise().Goto(4)
                        .On(5)
                            .If(v => true).Execute(() => { })
                            .Otherwise()
                        .On(2)
                            .If(v => true).Goto(7)
                            .Otherwise().Goto(7)
                        .On(1)
                            .If(v => true).Goto(7).Execute(() => { })
                        .On(1)
                            .If(v => true).Execute(() => { })
                            .Otherwise().Execute(() => { })
                        .On(4)
                            .Goto(5).Execute(() => { })
                        .On(5)
                            .Execute(() => { })
                        .On(7)
                            .Goto(4)
                        .On(8)
                        .On(9);
                };
        }
    }
}