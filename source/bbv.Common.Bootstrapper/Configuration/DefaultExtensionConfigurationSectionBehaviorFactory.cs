//-------------------------------------------------------------------------------
// <copyright file="DefaultExtensionConfigurationSectionBehaviorFactory.cs" company="bbv Software Services AG">
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

namespace bbv.Common.Bootstrapper.Configuration
{
    using System;

    using bbv.Common.Bootstrapper.Configuration.Internals;

    /// <summary>
    /// Default factory for the <see cref="ExtensionConfigurationSectionBehavior"/>.
    /// </summary>
    public class DefaultExtensionConfigurationSectionBehaviorFactory : IExtensionConfigurationSectionBehaviorFactory
    {
        /// <summary>
        /// Creates the extension property reflector.
        /// </summary>
        /// <returns>The instance.</returns>
        public IReflectExtensionProperties CreateReflectExtensionProperties()
        {
            return new ReflectExtensionPublicProperties();
        }

        /// <summary>
        /// Creates the extension property assigner.
        /// </summary>
        /// <returns>
        /// The instance.
        /// </returns>
        public IAssignExtensionProperties CreateAssignExtensionProperties()
        {
            return new AssignExtensionProperties();
        }

        /// <summary>
        /// Creates the consume configuration instance.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>The instance.</returns>
        public IConsumeConfiguration CreateConsumeConfiguration(IExtension extension)
        {
            return new ConsumeConfiguration(extension);
        }

        /// <summary>
        /// Creates the instance which knows the section name.
        /// </summary>
        /// <param name="extension">The extension.</param>
        /// <returns>The instance.</returns>
        public IHaveConfigurationSectionName CreateHaveConfigurationSectionName(IExtension extension)
        {
            return new HaveConfigurationSectionName(extension);
        }

        /// <summary>
        /// Creates the instance which loads configuration sections.
        /// </summary>
        /// <param name="extension">The extensions.</param>
        /// <returns>The instance.</returns>
        public ILoadConfigurationSection CreateLoadConfigurationSection(IExtension extension)
        {
            return new LoadConfigurationSection(extension);
        }

        /// <summary>
        /// Creates the instance which has conversion callbacks.
        /// </summary>
        /// <param name="extension">The extensions.</param>
        /// <returns>The instance.</returns>
        public IHaveConversionCallbacks CreateHaveConversionCallbacks(IExtension extension)
        {
            return new HaveConversionCallbacks(extension);
        }
    }
}