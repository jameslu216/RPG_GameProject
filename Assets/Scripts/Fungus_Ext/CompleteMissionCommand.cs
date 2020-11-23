using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Fungus;

namespace Fungus
{
    [CommandInfo("Flow",
             "Complete Mission",
             "Complete Specific Mission")]
    public class CompleteMissionCommand : Command
    {
        [SerializeField] Mission target_mission;
        [VariableProperty(typeof(BooleanVariable))]
        [SerializeField] Variable result_variable;

        public override void OnEnter()
        {
            if(target_mission.cur_state!=Mission.MissionState.OnGoing)
            {
                Debug.Log("mission complete calling with wrong condiction");
                return;
            }
            
            bool result = target_mission.complete_mission();
            result_variable.Apply(SetOperator.Assign, result);
            if(result)
                target_mission.cur_state=Mission.MissionState.Passed;
            else
                Debug.Log("does not complete mission");

            if(target_mission.cur_state!=Mission.MissionState.Passed)
            {
                Debug.Log("failing mission complete");
            }
            Continue();
        }
    }
}
