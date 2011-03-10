﻿//-------------------------------------------------------------------------------
// <copyright file="Program.cs" company="bbv Software Services AG">
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

namespace bbv.Common.EvaluationEngine
{
    using System;

    using log4net.Appender;

    /// <summary>
    /// Main entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        public static void Main(string[] args)
        {
            ConfigureLog4Net();

            var evaluationEngine = new EvaluationEngine();
            evaluationEngine.SetLogExtension(new Extensions.Log4NetExtension());

            var questioner = new Questioner(evaluationEngine);
            var answerer = new Answerer(evaluationEngine);

            answerer.PrepareAnswers();
            questioner.Ask();

            Console.ReadLine();
        }

        private static void ConfigureLog4Net()
        {
            var appender = new ConsoleAppender
                {
                    Layout = new log4net.Layout.SimpleLayout()
                };
            log4net.Config.BasicConfigurator.Configure(appender);
        }
    }
}