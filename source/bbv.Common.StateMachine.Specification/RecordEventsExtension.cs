//-------------------------------------------------------------------------------
// <copyright file="RecordEventsExtension.cs" company="bbv Software Services AG">
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

namespace bbv.Common.StateMachine.Specification
{
    using System.Collections.Generic;
    using Extensions;

    public class RecordEventsExtension : ExtensionBase<int, int>
        {
            public RecordEventsExtension()
            {
                this.RecordedFiredEvents = new List<int>();
                this.RecordedQueuedEvents = new List<int>();
            }

            public IList<int> RecordedFiredEvents { get; private set; }

            public IList<int> RecordedQueuedEvents { get; private set; }

            public override void FiredEvent(IStateMachineInformation<int, int> stateMachine, Internals.ITransitionContext<int, int> context)
            {
                this.RecordedFiredEvents.Add(context.EventId);
            }

            public override void EventQueued(IStateMachineInformation<int, int> stateMachine, int eventId, object[] eventArguments)
            {
                this.RecordedQueuedEvents.Add(eventId);
            }
        }
}