//-------------------------------------------------------------------------------
// <copyright file="ILogExtension.cs" company="bbv Software Services AG">
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
    using bbv.Common.EvaluationEngine.Internals;

    /// <summary>
    /// Provides logging.
    /// </summary>
    public interface ILogExtension
    {
        /// <summary>
        /// Logs the found answer together with information how it was found.
        /// </summary>
        /// <param name="context">The context.</param>
        void FoundAnswer(Context context);
    }
}