using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ActionUti
{
    public class ActionUtilities
    {
        public static bool GetAction(int id,ActionHolder ActHolder)
        {
            if(id < ActHolder.ListAction.Count)
            {
                return ActHolder.ListAction[id].Can;
            }else
            {
                return false;
            }
        
        }

        public static void SetAction(int id,bool set, ActionHolder ActHolder)
        {
            if (id < ActHolder.ListAction.Count)
            {
                Action Act;
                Act.Can = set;
                Act.id = id;
                Act.Name = ActHolder.ListAction[id].Name;
                ActHolder.ListAction[id] = Act;
            }
        }
    }
}