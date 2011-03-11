//-------------------------------------------------------------------------------
// <copyright file="IMapper.cs" company="bbv Software Services AG">
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

namespace bbv.Common.MappingEventBrokerExtension
{
    using System;

    /// <summary>
    /// Mapper interface which must be implemented by mapping algorithms.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Determines whether there exists a mapping from the provided
        /// <paramref name="sourceEventArgsType"/> to the 
        /// <paramref name="destinationEventArgsType"/>.
        /// </summary>
        /// <param name="sourceEventArgsType">The source event argument type.</param>
        /// <param name="destinationEventArgsType">The destination event argument type.</param>
        /// <returns><see langword="true"/> if there is a mapping; otherwise <see langword="false"/>.</returns>
        bool HasMapping(Type sourceEventArgsType, Type destinationEventArgsType);

        /// <summary>
        /// Maps the provided event argument from the 
        /// <paramref name="sourceEventArgsType"/> to the 
        /// <paramref name="destinationEventArgsType"/>.
        /// </summary>
        /// <param name="sourceEventArgsType">The source event argument type.</param>
        /// <param name="destinationEventArgsType">The destination event argument type.</param>
        /// <param name="eventArgs">The source event argument.</param>
        /// <returns>The mapped event argument.</returns>
        EventArgs Map(Type sourceEventArgsType, Type destinationEventArgsType, EventArgs eventArgs);
    }
}